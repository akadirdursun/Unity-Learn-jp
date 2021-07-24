using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int score;
    [Header("Health")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [Header("Hunger")]
    [SerializeField] private int maxHunger;
    [SerializeField] private int currentHunger;

    private float healPoints = 0;

    private UIManager uiManager;

    #region Properties
    public int MaxHealth { get => maxHealth; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHunger { get => maxHunger; }
    public int CurrentHunger { get => currentHunger; set => currentHunger = value; }
    public int Score { get => score; }
    public UIManager UiManager { set => uiManager = value; }
    #endregion

    private void OnEnable()
    {
        StaticEvents.StartTheGame += ResetPlayerData;
    }

    private void OnDisable()
    {
        StaticEvents.StartTheGame -= ResetPlayerData;
    }

    private void ResetPlayerData(DifficultySettingsData d)
    {
        currentHealth = maxHealth;
        currentHunger = 0;
        healPoints = 0;
        score = 0;
    }

    public bool AddHealPoints(float hp)
    {
        if (currentHealth >= maxHealth)
            return false;

        healPoints += hp;
        if (healPoints >= 1)
        {
            currentHealth++;
            healPoints--;
            return true;
        }
        return false;
    }

    public void AddScore(int value)
    {
        score += value;

        if (uiManager != null)
            uiManager.UpdateScoreUI();
    }

    public void Eat(int value)
    {
        currentHunger -= value;
        StaticEvents.Hungry?.Invoke(false);
        if (currentHunger < 0)
            currentHunger = 0;
    }
}