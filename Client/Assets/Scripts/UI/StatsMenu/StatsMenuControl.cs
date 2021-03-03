using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenuControl : MonoBehaviour
{
    public static event Action<int,int> ChangingStats;
    public static event Action SavingChanges;
    public static event Action RequestingValues;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button resetButton;
    // 0 - hp; 1 - ap; 2 - dp;
    [SerializeField] private int currentFieldSwitcher;
    private void Start()
    {
        StatsMenuHandler.Control = this;
        saveButton.onClick.AddListener(OnSavingChanges);
        resetButton.onClick.AddListener(OnRequestingValues);
    }
    public void SwitchField(int value)
    {
        currentFieldSwitcher = value;
    }

    // 1 - 1 point; 2 - half points; 3 - all points;
    public void OnChangingValue(int value)
    {
        switch (currentFieldSwitcher)
        {
            case 0:
                ChangingStats.Invoke(value, currentFieldSwitcher);
                break;
            case 1:
                ChangingStats.Invoke(value, currentFieldSwitcher);
                break;
            case 2:
                ChangingStats.Invoke(value, currentFieldSwitcher);
                break;
        }
    }
    private void OnSavingChanges()
    {
        SavingChanges.Invoke();
    }
    private void OnRequestingValues()
    {
        RequestingValues.Invoke();
    }
}
