using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInitializer : MonoBehaviour
{
    [SerializeField] private BusinessModelsList _modelsList;
    [SerializeField] private MainScreenView _mainScreenView;
    private MainScreenPresenter _mainScreenPresenter;
    private MainScreen _mainScreenModel;

    private void Awake()
    {
        _modelsList.OnConverted += InitMainScreen;
    }

    private void InitMainScreen(List<Business> list)
    {
        _mainScreenModel = new MainScreen();
        _mainScreenPresenter = new MainScreenPresenter(_mainScreenView, _mainScreenModel, list, Resources.Load<BusinessView>("BusinessPanelView"));
    }
}
