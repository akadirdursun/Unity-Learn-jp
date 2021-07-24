using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //[SerializeField] private int maxHealth = 50;
    //[SerializeField] private int currentHealth;
    [SerializeField] private PlayerData playerData;

    [Header("UI")]
    [SerializeField] private GameObject healthUIParent;
    [SerializeField] private TextMeshProUGUI healthValueText;
    [SerializeField] private Slider healthSlider;

    private int damageTakenPerSec = 1;

    private bool isHungry;

    private Coroutine takeDamageCoroutine;

    private void Start()
    {
        playerData.CurrentHealth = playerData.MaxHealth;
        healthSlider.maxValue = playerData.MaxHealth;
        healthSlider.value = playerData.CurrentHealth;
    }

    private void OnEnable()
    {
        StaticEvents.Hungry += TakeDamage;
        StaticEvents.StartTheGame += SetDifficulty;
    }

    private void OnDisable()
    {
        StaticEvents.Hungry -= TakeDamage;
        StaticEvents.StartTheGame -= SetDifficulty;
    }

    private void SetDifficulty(DifficultySettingsData difficulty)
    {
        damageTakenPerSec = difficulty.DamageTakenPerSec;
    }

    private void TakeDamage(bool IsHungry)
    {
        isHungry = IsHungry;

        if (IsHungry)
            takeDamageCoroutine = StartCoroutine(TakeDamageOverTime());
    }

    IEnumerator TakeDamageOverTime()
    {
        healthUIParent.SetActive(true);
        while (isHungry)
        {
            yield return new WaitForSeconds(1f / damageTakenPerSec);
            playerData.CurrentHealth--;
            healthValueText.text = playerData.CurrentHealth + " / " + playerData.MaxHealth;
            healthSlider.value = playerData.CurrentHealth;

            if (playerData.CurrentHealth <= 0)
            {
                StaticEvents.GameOver?.Invoke();
                StopCoroutine(takeDamageCoroutine);
            }
        }
        healthUIParent.SetActive(false);
    }
}