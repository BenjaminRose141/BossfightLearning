using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "Boss")]
public class BossScriptableObject : ScriptableObject
{
    [Header("---Stats-------")]
    [SerializeField]
    [Tooltip("Maximum HP of the boss.")]
    private int healthMax;

    [SerializeField]
    [Tooltip("Current HP of the boss.")]
    private int healthCurrent;

    [Space]
    [Header("Meteorite")]
    [Header("---Attacks-------")]
    [Space(10)]
    [SerializeField]
    [Tooltip("Prefab of the Meteorite Attack")]
    GameObject meteoritePrefab;

}
