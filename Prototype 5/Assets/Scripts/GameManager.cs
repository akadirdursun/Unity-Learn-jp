using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnTime = 0.5f;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject titleScreen;

    private int score = 0;
    private bool isGameActive = true;

    public bool IsGameActive { get => isGameActive; }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        UpdateScore(0);
        spawnTime /= difficulty;
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
    }
}