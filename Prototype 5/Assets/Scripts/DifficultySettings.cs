using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDifficultySetting",menuName ="Settings/Difficulty Setting")]
public class DifficultySettings : ScriptableObject
{
    [SerializeField] private float spawnTime;
    [SerializeField] private int hungryPerSec;

    public float SpawnTime { get => spawnTime; }
    public int HungryPerSec { get => hungryPerSec; }
}
