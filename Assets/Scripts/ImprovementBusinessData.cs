using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Improvement Business Data", menuName = "Improvement Business Data", order = 51)]
public class ImprovementBusinessData : ScriptableObject
{
    [SerializeField] private float _improvementCost;
    [SerializeField] private float _improvement�oefficient;

    public float ImprovementCost => _improvementCost;
    public float Improvement�oefficient => _improvement�oefficient;
}
