using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessPresenter
{
    private Business _model;
    private BusinessView _view;
    public BusinessPresenter(Business model, BusinessView view)
    {
        _model = model;
        _view = view;
    }
}
