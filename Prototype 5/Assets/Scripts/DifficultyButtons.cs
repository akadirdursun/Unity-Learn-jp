using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] private float difficulty;

    private Button difficultyButton;
    private GameManager gameManager;    

    private void Start()
    {
        difficultyButton = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
