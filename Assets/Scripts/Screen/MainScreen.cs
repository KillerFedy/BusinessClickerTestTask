using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainScreen
{
    public float Balance { get; private set; }

    public UnityAction<float> OnUpdateBalance;

    public MainScreen()
    {
        Balance = 0;
    }

    public void IncreaseBalance(float money)
    {
        Balance += money;
        OnUpdateBalance?.Invoke(Balance);
    }

    public void ReduceBalance(float money)
    {
        Balance -= money;
        OnUpdateBalance?.Invoke(Balance);
    }
}
