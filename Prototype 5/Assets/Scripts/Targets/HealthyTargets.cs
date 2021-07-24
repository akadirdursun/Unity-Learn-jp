using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyTargets : AbstractTarget
{
    [SerializeField] private int hungerDecreaseValue;
    [SerializeField] [Range(0,1)] private float healPoint;
    [SerializeField] private GameObject popUpPrefab;

    private bool isHealed = false;

    protected override void TargetActions()
    {
        isHealed = playerData.AddHealPoints(healPoint);
        playerData.Eat(hungerDecreaseValue);

        if (isHealed)
            Instantiate(popUpPrefab, transform.position, Quaternion.identity);
    }
}