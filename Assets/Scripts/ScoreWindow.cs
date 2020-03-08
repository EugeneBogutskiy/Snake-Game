using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    Text scoreText;

    void Awake()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = GameHandler.GetScore().ToString();
    }
}
