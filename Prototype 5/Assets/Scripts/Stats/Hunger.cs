using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [Header("UI")]
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private TextMeshProUGUI hungerValueText;

    private float hungerDelay;
    private bool isHungry = false;

    private void OnEnable()
    {
        StaticEvents.StartTheGame += StartTheHunger;
    }

    private void OnDisable()
    {
        StaticEvents.StartTheGame -= StartTheHunger;
    }

    private void StartTheHunger(DifficultySettingsData settings)
    {
        hungerSlider.maxValue = playerData.MaxHunger;
        hungerDelay = 1f / settings.HungryPerSec;
        StartCoroutine(IncreaseHunger());
    }

    IEnumerator IncreaseHunger()
    {
        while (!isHungry)
        {
            yield return new WaitForSeconds(hungerDelay);
            playerData.CurrentHunger++;
            hungerSlider.value = playerData.CurrentHunger;
            hungerValueText.text = playerData.CurrentHunger + " / " + playerData.MaxHunger;
            if (playerData.CurrentHunger == playerData.MaxHunger)
            {
                StaticEvents.Hungry?.Invoke(true);
                isHungry = true;
            }
        }
    }
}