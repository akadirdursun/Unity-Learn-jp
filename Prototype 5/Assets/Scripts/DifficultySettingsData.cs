using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDifficultySetting",menuName ="Settings/Difficulty Setting")]
public class DifficultySettingsData : ScriptableObject
{
    [SerializeField] private float spawnTime;
    [SerializeField] private int hungryPerSec;
    [SerializeField] private int damageTakenPerSec;

    public float SpawnTime { get => spawnTime; }
    public int HungryPerSec { get => hungryPerSec; }
    public int DamageTakenPerSec { get => damageTakenPerSec; }
}
