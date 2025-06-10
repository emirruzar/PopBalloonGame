using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int totalScore = 0;
    public TMP_Text scoreText;

    public int winScore = 50;
    public int loseScore = 0;

    private bool isGameOver = false;

    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void AddScore(int score, string balloonName)
    {
        if (isGameOver) return;

        totalScore += score;
        UpdateScoreUI();
        CheckGameOver();
    }

    public void SubtractScore(int score)
    {
        if (isGameOver) return;
        totalScore -= score;
        UpdateScoreUI();
        CheckGameOver();
    }


    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }

    private void CheckGameOver()
    {
        if (totalScore >= winScore)
        {
            GameOver(true);
        }
        else if (totalScore < loseScore)
        {
            GameOver(false);
        }
    }

    public static int lastScore = 0;

    public static bool hasWonLastGame = false;

    private void GameOver(bool hasWon)
    {
        isGameOver = true;
        lastScore = totalScore;
        hasWonLastGame = hasWon;

        if (audioSource != null)
        {
            AudioClip clip = hasWon ? winSound : loseSound;
            if (clip != null)
            {
                StartCoroutine(PlayEndAndLoadScene(clip));
                return;
            }
        }
        SceneManager.LoadScene("GameOverScene");
        Time.timeScale = 0;
    }

    private System.Collections.IEnumerator PlayEndAndLoadScene(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("GameOverScene");
        Time.timeScale = 0;
    }

    public void Reset()
    {
        Debug.Log("ScoreManager sýfýrlanýyor...");
        totalScore = 0;
        UpdateScoreUI();
        isGameOver = false;
    }
}
