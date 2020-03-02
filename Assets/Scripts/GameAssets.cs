using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets gameAssets;

    void Awake()
    {
        gameAssets = this;
    }

    public Sprite snakeHeadSprite;
}
