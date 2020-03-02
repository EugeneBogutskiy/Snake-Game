using UnityEngine;

public class GameHandler : MonoBehaviour
{
    void Start()
    {
        GameObject snakeHeadGameObject = new GameObject();
        SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
        snakeSpriteRenderer.sprite = GameAssets.gameAssets.snakeHeadSprite;
    }

    void Update()
    {
        
    }
}
