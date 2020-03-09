using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void SetWindowActive()
    {
        this.gameObject.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
