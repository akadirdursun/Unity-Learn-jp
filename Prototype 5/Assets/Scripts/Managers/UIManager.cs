using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject titleScreen;

    private void Awake()
    {
        playerData.UiManager = this;
    }

    private void OnEnable()
    {
        StaticEvents.StartTheGame += CloseTitleScreen;
        StaticEvents.GameOver += OpenGameOverUI;
    }

    private void OnDisable()
    {
        StaticEvents.StartTheGame -= CloseTitleScreen;
        StaticEvents.GameOver -= OpenGameOverUI;
    }

    private void OpenGameOverUI()
    {
        gameOverScreen.SetActive(true);
    }

    private void CloseTitleScreen(DifficultySettingsData settings)
    {
        titleScreen.SetActive(false);
    }

    public void UpdateScoreUI()
    {
        scoreText.text = playerData.Score.ToString();
    }
}
