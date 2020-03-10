using UnityEngine;

public class GameHandler : MonoBehaviour
{
    static GameHandler instance;
    LevelGrid levelGrid;
    [SerializeField]
    Snake snake;
    static int score;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        levelGrid = new LevelGrid(30, 30);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }

    public static int GetScore()
    {
        return score;
    }

    public static int AddScore()
    {
        return score++;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
