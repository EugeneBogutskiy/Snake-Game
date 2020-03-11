using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2Int gridMoveDirection;
    Vector2Int gridPosition;
    float gridMoveTimer;
    float gridMoveTimerMax;
    LevelGrid levelGrid;
    [SerializeField]
    GameOverWindow gameOver;
    int snakeBodySize;
    List<Vector2Int> snakeMovePositionList;
    List<Transform> snakeBodyTransformList;
    State state;

    enum State
    {
        Alive,
        Dead
    }

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

    void Awake()
    {
        gridPosition = new Vector2Int(15, 15);
        gridMoveDirection = new Vector2Int(Random.Range(-1,1), Random.Range(-1,1));
        gridMoveTimerMax = 0.2f;
        gridMoveTimer = gridMoveTimerMax;
        snakeMovePositionList = new List<Vector2Int>();
        snakeBodySize = 0;
        snakeBodyTransformList = new List<Transform>();
        state = State.Alive;
    }

    void Update()
    {
        switch (state)
        {
            case State.Alive:
                GetInput();
                GridMovement();
                break;
            case State.Dead:
                break;
        }
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.y = 1;
                gridMoveDirection.x = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection.y = -1;
                gridMoveDirection.x = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection.y = 0;
                gridMoveDirection.x = -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.y = 0;
                gridMoveDirection.x = 1;
            }
        }
    }

    void GridMovement()
    {
        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;
            snakeMovePositionList.Insert(0, gridPosition);
            gridPosition += gridMoveDirection;

            SoundManager.PlaySound();

            gridPosition = levelGrid.ValidateGridPosition(gridPosition);
            bool snakeAteFood = levelGrid.TrySnakeEatFood(gridPosition);

            if (snakeAteFood)
            {
                snakeBodySize++;
                CreateSnakeBody();
            }

            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 270);

            for (int i = 0; i < snakeBodyTransformList.Count; i++)
            {
                Vector3 snakeBodyPosition = new Vector3(snakeMovePositionList[i].x, snakeMovePositionList[i].y);
                snakeBodyTransformList[i].position = snakeBodyPosition;
            }

            for (int i = 0; i < snakeBodyTransformList.Count; i++)
            {
                if (snakeBodyTransformList[i].position == transform.position)
                {
                    state = State.Dead;
                    gameOver.SetWindowActive();
                }
            }

        }
    }

    float GetAngleFromVector(Vector2Int vector)
    {
        float n = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

    public List<Vector2Int> GetFullSnakeGridPositionLIst()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPosition };
        gridPositionList.AddRange(snakeMovePositionList);
        return gridPositionList;
    }

    void CreateSnakeBody()
    {
        GameObject snakeBodyGameObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
        snakeBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.gameAssets.snakeBody;
        snakeBodyTransformList.Add(snakeBodyGameObject.transform);
        snakeBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -snakeBodyTransformList.Count;
    }
}

