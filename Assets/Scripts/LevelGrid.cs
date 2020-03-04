using UnityEngine;

public class LevelGrid
{
    Vector2Int foodGridPosition;
    int width;
    int height;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        SpawnFood();
    }
    void SpawnFood()
    {
        foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        GameObject foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.gameAssets.foodSprite;

        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }
}
