using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BusinessModelsList : MonoBehaviour
{
    [SerializeField] private List<BusinessData> _businessDataList = new List<BusinessData>();

    private List<Business> _businessModelsList = new List<Business>();

    public UnityAction<List<Business>> OnConverted;

    private void Start()
    {
        ConvertDataListToModelList();
    }

    private void ConvertDataListToModelList()
    {
        foreach (var data in _businessDataList)
        {
            Business model = new Business(data.BusinessName, data.BusinessLevel, data.IncomeDelay, data.BaseCost, data.FirstImprovement.ImprovementCost,
                data.FirstImprovement.ImprovementCoefficient, data.SecondImprovement.ImprovementCost, data.SecondImprovement.ImprovementCoefficient);
            _businessModelsList.Add(model);
        }
        OnConverted?.Invoke(_businessModelsList);
    }
}
