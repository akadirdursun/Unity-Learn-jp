using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour
{
    [SerializeField] private int maxHungerValue = 100;
    [SerializeField] private int currentHungerValue = 0;    

    [Header("UI")]
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private TextMeshProUGUI hungerValueText;

    private float hungerDelay;
    private bool increaseTheHunger = true;

    private void OnEnable()
    {
        StaticEvents.StartTheGame += StartTheHunger;
    }

    private void StartTheHunger(DifficultySettings settings)
    {
        hungerSlider.maxValue = maxHungerValue;
        hungerDelay = 1f / settings.HungryPerSec;
        StartCoroutine(IncreaseHunger());        
    }

    IEnumerator IncreaseHunger()
    {
        while (increaseTheHunger)
        {
            yield return new WaitForSeconds(hungerDelay);
            currentHungerValue++;

            hungerSlider.value = currentHungerValue;
            hungerValueText.text = currentHungerValue + " / " + maxHungerValue;

            if (currentHungerValue == maxHungerValue)
            {                
                StaticEvents.GameOver?.Invoke();
                increaseTheHunger = false;               
            }                
        }
    }

    private void OnDisable()
    {
        StaticEvents.StartTheGame -= StartTheHunger;
    }
}
