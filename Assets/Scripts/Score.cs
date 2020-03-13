using UnityEngine;

public static class Score
{
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    public static bool TrySetNewHighScore(int score)
    {
        int highScore = GetHighScore();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
            return true;
        }
        else return false;
    }
}
