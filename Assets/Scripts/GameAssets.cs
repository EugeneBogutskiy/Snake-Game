﻿using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets gameAssets;

    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
    public Sprite snakeBody;

    public AudioClip snakeMove;

    void Awake()
    {
        gameAssets = this;
    }

}
