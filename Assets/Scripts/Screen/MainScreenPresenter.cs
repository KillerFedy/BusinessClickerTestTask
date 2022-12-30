using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenPresenter
{
    private MainScreenView _screenView;
    private MainScreen _screenModel;
    private List<BusinessPresenter> _businessPresenterList = new List<BusinessPresenter>();

    public MainScreenPresenter(MainScreenView view, MainScreen model, List<Business> businessModelsList)
    {
        _screenView = view;
        _screenModel = model;
        _screenModel.OnUpdateBalance += UpdateBalance;
        InitBusinesses(businessModelsList, Resources.Load<BusinessView>("BusinessPanelView"), _screenView);
    }

    private void InitBusinesses(List<Business> businessModelsList, BusinessView businessView, MainScreenView mainScreenView)
    {
        foreach (var model in businessModelsList)
        {
            BusinessView view = mainScreenView.AddBusinessView(businessView);
            BusinessPresenter presenter = new BusinessPresenter(model, view);
            presenter.OnIncomeGet += AddMoneyToBalance;
            _businessPresenterList.Add(presenter);
        }
    }

    private void UpdateBalance(float value)
    {
        _screenView.UpdateBalance(value);
    }

    private void AddMoneyToBalance(float money)
    {
        _screenModel.IncreaseBalance(money);
    }
}
