using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.Reset();
        }

        Time.timeScale = 1;

        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}