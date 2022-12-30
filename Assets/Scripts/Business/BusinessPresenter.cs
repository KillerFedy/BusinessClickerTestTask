using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BusinessPresenter
{
    private Business _model;
    private BusinessView _view;

    public UnityAction<float> OnIncomeGet;

    public BusinessPresenter(Business model, BusinessView view)
    {
        _model = model;
        _view = view;
        _view.OnInñomeGet += GetIncome;
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

    private void GetIncome()
    {
        OnIncomeGet?.Invoke(_model.Income);
    }
}
