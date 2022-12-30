using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BusinessPresenter
{
    private Business _model;
    private BusinessView _view;
    private MainScreenPresenter _mainScreenPresenter;

    public BusinessPresenter(Business model, BusinessView view, MainScreenPresenter screenPresenter)
    {
        _model = model;
        _view = view;
        _mainScreenPresenter = screenPresenter;
        _view.OnInñomeAdd += AddIncomeToBalance;
        _view.OnLevelUp += UpLevel;
        _model.OnUpLevel += UpdateLevel;
        _model.OnUpDateLevelCost += UpdatelevelCost;
        _model.OnUpDateIncome += UpdateIncome;
        _view.Init(model.BusinessName, model.Level, model.Income, model.LevelCost, model.FirstImprovementCost, 
            model.FirstImprovementCoefficient, model.SecondImprovementCost, model.SecondImprovementCoefficient);
        SetIncomeSlider(model.IncomeDelay, model.Level);
    }

    private void SetIncomeSlider(float delay, int level)
    {
        if(level > 0)
        {
            _view.SetIncomeSlider(delay);
        }
    }

    private void AddIncomeToBalance()
    {
        _mainScreenPresenter.AddMoneyToBalance(_model.Income);
    }

    private void UpLevel()
    {
        if(_mainScreenPresenter.CheckBalance(_model.LevelCost))
        {
            _mainScreenPresenter.LostMoneyFromBalance(_model.LevelCost);
            _model.UpLevel();
            if(_model.Level == _model.LevelToStartBusinessProcess)
            {
                SetIncomeSlider(_model.IncomeDelay, _model.Level);
            }
        }
    }

    private void UpdateLevel(int level)
    {
        _view.UpdateLevel(level);
    }

    private void UpdatelevelCost(float cost)
    {
        _view.UpdateLevelCost(cost);
    }

    private void UpdateIncome(float income)
    {
        _view.UpdateIncome(income);
    }
}
