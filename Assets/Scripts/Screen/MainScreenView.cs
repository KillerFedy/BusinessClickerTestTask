using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenView : MonoBehaviour
{
    [SerializeField] private GameObject _scrollContent;
    [SerializeField] private TMP_Text _balanceText;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public BusinessView AddBusinessView(BusinessView view)
    {
        BusinessView obj = Instantiate(view, _scrollContent.transform);
        return obj;
    }

    public void UpdateBalance(float balance)
    {
        _balanceText.text = $"Баланс: {balance}";
    }
}
