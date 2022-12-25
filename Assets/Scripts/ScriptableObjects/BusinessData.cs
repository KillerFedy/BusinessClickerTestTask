using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Business Data", menuName = "Business Data", order = 51)]
public class BusinessData : ScriptableObject
{
    [SerializeField] private string _businessName;
    [SerializeField] private int _businessLevel;
    [SerializeField] private float _incomeDelay;
    [SerializeField] private float _baseCost;
    [SerializeField] private float _baseIncome;
    [SerializeField] private ImprovementBusinessData _firstImprovement;
    [SerializeField] private ImprovementBusinessData _secondImprovement;

    public string BusinessName => _businessName;
    public int BusinessLevel => _businessLevel;
    public float IncomeDelay => _incomeDelay;
    public float BaseCost => _baseCost;
    public float BaseIncome => _baseIncome;
    public ImprovementBusinessData FirstImprovement => _firstImprovement;
    public ImprovementBusinessData SecondImprovement => _secondImprovement;
}
