using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Business
{
    public UnityAction<int> OnUpLevel;
    public UnityAction<float> OnUpDateLevelCost;
    public UnityAction<float> OnUpDateIncome;
    public UnityAction OnBuyFirstImprovement;
    public UnityAction OnBuySecondImprovement;

    private bool _isFirstImprovementBought = false;
    private bool _isSecondImprovementBought = false;

    public string BusinessName { get; private set; }
    public int Level { get; private set; }
    public float IncomeDelay { get; private set; }
    public float BaseCost { get; private set; }
    public float BaseIncome { get; private set; }
    public float FirstImprovementCost { get; private set; }
    public float FirstImprovementCoefficient { get; private set; }
    public float SecondImprovementCost { get; private set; }
    public float SecondImprovementCoefficient { get; private set; }
    public float Income => (Level * BaseCost * (1 + (_isFirstImprovementBought ? FirstImprovementCoefficient : 0) + 
        (_isSecondImprovementBought ? SecondImprovementCoefficient : 0)));
    public float LevelCost => (Level + 1) * BaseCost;

    public int LevelToStartBusinessProcess => 1;

    public bool IsFirstImprovementBought => _isFirstImprovementBought;
    public bool IsSecondImprovementBought => _isSecondImprovementBought;

    public Business(string name, int level, float delay, float basecost, 
        float firstImprovementCost, float firstImprovementCoefficient, float secondImprovementCost, float secondImprovementCoefficient)
    {
        BusinessName= name;
        Level = level;
        IncomeDelay = delay;
        BaseCost = basecost;
        FirstImprovementCost = firstImprovementCost;
        FirstImprovementCoefficient = firstImprovementCoefficient;
        SecondImprovementCost = secondImprovementCost;
        SecondImprovementCoefficient = secondImprovementCoefficient;
    }

    public void UpLevel()
    {
        Level++;
        OnUpLevel?.Invoke(Level);
        OnUpDateLevelCost?.Invoke(LevelCost);
        OnUpDateIncome?.Invoke(Income);
    }

    public void BuyFirstImprovement()
    {
        _isFirstImprovementBought = true;
        OnUpDateIncome?.Invoke(Income);
        OnBuyFirstImprovement?.Invoke();
    }

    public void BuySecondImprovement()
    {
        _isSecondImprovementBought = true;
        OnUpDateIncome?.Invoke(Income);
        OnBuySecondImprovement?.Invoke();
    }
}