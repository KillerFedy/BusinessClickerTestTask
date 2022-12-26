using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenPresenter
{
    private MainScreenView _screenView;
    private MainScreen _screenModel;

    public MainScreenPresenter(MainScreenView view, MainScreen model, List<Business> _businessModelsList)
    {
        _screenView = view;
        _screenModel = model;
    }
}
