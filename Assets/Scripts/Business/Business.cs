using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Business : IBusiness
{
    public string BusinessName { get; private set; }
    public int Level { get; private set; }
    public float IncomeDelay { get; private set; }
    public float BaseCost { get; private set; }
    public float BaseIncome { get; private set; }
    public float FirstImprovementCost { get; private set; }
    public float FirstImprovementCoefficient { get; private set; }
    public float SecondImprovementCost { get; private set; }
    public float SecondImprovementCoefficient { get; private set; }
    public float Income => (Level * BaseCost * (1 + FirstImprovementCoefficient + SecondImprovementCoefficient));
    public float LevelCost => (Level + 1) * BaseCost;

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
}