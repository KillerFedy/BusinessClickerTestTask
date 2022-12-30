using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class BusinessView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private TMP_Text _textLevel;
    [SerializeField] private TMP_Text _textIncome;
    [SerializeField] private Button _levelUpButton;
    [SerializeField] private TMP_Text _levelUpButtonText;
    [SerializeField] private Button _firstImprovementBuyButton;
    [SerializeField] private TMP_Text _firstImprovementBuyButtonText;
    [SerializeField] private Button _secondImprovementBuyButton;
    [SerializeField] private TMP_Text _secondImprovementBuyButtonText;
    [SerializeField] private Slider _incomeSlider;

    public UnityAction OnInсomeGet;

    public void CheckValueSlider(float value)
    {
        if(value == _incomeSlider.maxValue)
        {
            OnInсomeGet?.Invoke();
        }
    }

    public void Init(string name, int level, float income, float levelCost, float firstimpcost, 
        float firstimpcoeff, float secondimpcost, float secondimpcoeff)
    {
        _textName.text = name;
        _textLevel.text = $"LVL {level}";
        _textIncome.text = $"Доход {income}";
        _levelUpButtonText.text = $"LVL UP Цена: {levelCost}";
        _firstImprovementBuyButtonText.text = $"Доход: + {firstimpcoeff * 100} % \n Цена: {firstimpcost}";
        _secondImprovementBuyButtonText.text = $"Доход: + {secondimpcoeff * 100} % \n Цена: {secondimpcost}";
    }

    public void SetIncomeSlider(float delay)
    {
        _incomeSlider.DOValue(_incomeSlider.maxValue, delay).SetLoops(-1, LoopType.Restart);
    }
}
