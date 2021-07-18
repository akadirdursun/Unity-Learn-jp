using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] private float difficulty;

    private Button difficultyButton; 

    private void Start()
    {
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        StaticEvents.StartTheGame?.Invoke(difficulty);
    }
}
