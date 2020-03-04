using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2Int gridMoveDirection;
    Vector2Int gridPosition;
    float gridMoveTimer;
    float gridMoveTimerMax;

    void Awake()
    {
        gridPosition = new Vector2Int(25, 25);
        gridMoveDirection = new Vector2Int(1, 0);
        gridMoveTimerMax = 0.5f;
        gridMoveTimer = gridMoveTimerMax;
    }

    void Update()
    {
        GetInput();
        GridMovement();
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
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection)-270);
        }
    }

    float GetAngleFromVector (Vector2Int vector)
    {
        float n = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        if (n<0)
        {
            n += 360;
        }
        return n;
    }
}

