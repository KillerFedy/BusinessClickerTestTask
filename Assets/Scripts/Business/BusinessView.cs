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

    public UnityAction OnIn?omeAdd;
    public UnityAction OnLevelUp;
    public UnityAction OnBuyFirstImprovement;
    public UnityAction OnBuySecondImprovement;

    private void Awake()
    {
        _levelUpButton.onClick.AddListener(OnClickLevelUpButton);
        _firstImprovementBuyButton.onClick.AddListener(OnClickFirstImprovementButton);
        _secondImprovementBuyButton.onClick.AddListener(OnClickSecondImprovementButton);
    }

    public void CheckValueSlider(float value)
    {
        if(value == _incomeSlider.maxValue)
        {
            OnIn?omeAdd?.Invoke();
        }
    }

    public void Init(string name, int level, float income, float levelCost, float firstimpcost, 
        float firstimpcoeff, float secondimpcost, float secondimpcoeff)
    {
        _textName.text = name;
        _textLevel.text = $"LVL {level}";
        _textIncome.text = $"????? {income}";
        _levelUpButtonText.text = $"LVL UP ????: {levelCost}";
        _firstImprovementBuyButtonText.text = $"?????: + {firstimpcoeff * 100} % \n ????: {firstimpcost}";
        _secondImprovementBuyButtonText.text = $"?????: + {secondimpcoeff * 100} % \n ????: {secondimpcost}";
    }

    public void SetIncomeSlider(float delay)
    {
        _incomeSlider.DOValue(_incomeSlider.maxValue, delay).SetLoops(-1, LoopType.Restart);
    }

    public void UpdateLevel(int level)
    {
        _textLevel.text = $"LVL {level}";
    }

    public void UpdateLevelCost(float levelCost)
    {
        _levelUpButtonText.text = $"LVL UP ????: {levelCost}";
    }

    public void UpdateIncome(float income)
    {
        _textIncome.text = $"????? {income}";
    }

    public void UpdateFirstImprovementButtonText(float firstimprovementcoeff)
    {
        SetImprovementButtonText(_firstImprovementBuyButtonText, $"?????: + {firstimprovementcoeff * 100} % \n ??????");
    }

    public void UpdateSecondImprovementButtonText(float secondimprovementcoeff)
    {
        SetImprovementButtonText(_secondImprovementBuyButtonText, $"?????: + {secondimprovementcoeff * 100} % \n ??????");
    }

    private void SetImprovementButtonText(TMP_Text improvementButtonText, string text)
    {
        improvementButtonText.text = text;
    }

    private void OnClickLevelUpButton()
    {
        OnLevelUp?.Invoke();
    }

    private void OnClickFirstImprovementButton()
    {
        OnBuyFirstImprovement?.Invoke();
    }

    private void OnClickSecondImprovementButton()
    {
        OnBuySecondImprovement?.Invoke();
    }
}
