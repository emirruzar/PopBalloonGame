using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text finalScoreText;

    void Start()
    {
        Destroy(ScoreManager.Instance.gameObject);

        if (ScoreManager.hasWonLastGame)
            titleText.text = "YOU WIN!";
        else
            titleText.text = "YOU LOST!";
        finalScoreText.text = "Final Score: " + ScoreManager.lastScore;
    }
    public void RestartGame()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.Reset();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.Reset();
            Destroy(ScoreManager.Instance.gameObject);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}