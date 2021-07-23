using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject titleScreen;

    private int score;

    private void OnEnable()
    {
        StaticEvents.AddScore += UpdateScore;
        StaticEvents.StartTheGame += CloseTitleScreen;
        StaticEvents.GameOver += OpenGameOverUI;
    }

    private void OnDisable()
    {
        StaticEvents.AddScore -= UpdateScore;
        StaticEvents.StartTheGame -= CloseTitleScreen;
        StaticEvents.GameOver -= OpenGameOverUI;
    }

    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    private void OpenGameOverUI()
    {
        gameOverScreen.SetActive(true);
    }

    private void CloseTitleScreen(DifficultySettings settings)
    {
        titleScreen.SetActive(false);
    }
}
