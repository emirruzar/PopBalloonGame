using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text finalScoreText;

    void Start()
    {
        if (ScoreManager.hasWonLastGame)
            titleText.text = "YOU WIN!";
        else
            titleText.text = "YOU LOST!";
        finalScoreText.text = "Final Score: " + ScoreManager.lastScore;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}