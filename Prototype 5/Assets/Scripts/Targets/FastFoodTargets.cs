using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoodTargets : AbstractTarget
{
    [SerializeField] private int nutritiveValue;
    [SerializeField] [Range(0, 0.5f)] private float hungerSpeedBoost;
}
