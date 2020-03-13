using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedWindow : MonoBehaviour
{
    bool isPaused;

    void Start()
    {
        transform.Find("PauseWindow").gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                transform.Find("PauseWindow").gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                transform.Find("PauseWindow").gameObject.SetActive(false);
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        transform.Find("PauseWindow").gameObject.SetActive(false);
    }

    public void PushMainMenuBtn()
    {
        SceneManager.LoadScene("MainMenuScene");
        GameHandler.ResetScore();
    }
}
