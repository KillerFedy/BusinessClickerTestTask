using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenPresenter
{
    private MainScreenView _screenView;
    private MainScreen _screenModel;
    private BusinessView _businessView;
    private List<BusinessPresenter> _businessPresenterList = new List<BusinessPresenter>();

    public MainScreenPresenter(MainScreenView view, MainScreen model, List<Business> businessModelsList, BusinessView businessView)
    {
        _screenView = view;
        _screenModel = model;
        _businessView = businessView;
        InitScreen();
        InitBusinesses(businessModelsList, businessView, _screenView);
    }

    private void InitBusinesses(List<Business> businessModelsList, BusinessView businessView, MainScreenView mainScreenView)
    {
        foreach (var model in businessModelsList)
        {
            BusinessView view = mainScreenView.AddBusinessView(businessView);
            BusinessPresenter presenter = new BusinessPresenter(model, view);
            _businessPresenterList.Add(presenter);
        }
    }

    private void InitScreen()
    {
        _screenView.UpdateBalance(_screenModel.Balance);
    }
}
