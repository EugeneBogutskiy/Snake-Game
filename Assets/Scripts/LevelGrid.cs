using UnityEngine;

public class LevelGrid
{
    Vector2Int foodGridPosition; // позиция еды на поле
    GameObject foodGameObject; // еда для змейки
    int width; // ширина игрового поля
    int height; // высота игрового поля

    Snake snake; // получаем ссылку на  змейку

    public void Setup(Snake snake)
    {
        this.snake = snake;

        SpawnFood(); // сразу инициализируем еду на поле
    }

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    // создание еды
    void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionLIst().IndexOf(foodGridPosition) != -1); // пока не найдем свободное место для еды

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.gameAssets.foodSprite;

        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    // проверяем если ли змейка еду
    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            GameHandler.AddScore();
            return true;
        }
        else
        {
            return false;
        }
    }

    // функция движения змейки по бесконечному полю
    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if (gridPosition.x < 0)
        {
            gridPosition.x = width - 1;
        }
        if (gridPosition.x > width - 1)
        {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0)
        {
            gridPosition.y = height - 1;
        }
        if (gridPosition.y > height - 1)
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
}
