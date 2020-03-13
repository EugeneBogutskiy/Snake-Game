using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    Text scoreText;

    void Awake()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        int highScore = Score.GetHighScore();
        transform.Find("HighScoreText").GetComponent<Text>().text = "HIGH SCORE\n" + highScore.ToString();
    }

    void Update()
    {
        scoreText.text = GameHandler.GetScore().ToString();
    }
}
