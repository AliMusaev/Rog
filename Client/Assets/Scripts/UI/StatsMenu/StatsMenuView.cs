using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenuView : MonoBehaviour
{
    [SerializeField] private Text healthPointsField;
    [SerializeField] private Text attackPointsField;
    [SerializeField] private Text defencePointsField;
    [SerializeField] private Text freePointsField;
    [SerializeField] private Image[] backgrounds;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color colorOfChange;
    private void Start()
    {
        StatsMenuHandler.View = this;
    } 
    public void UpdateValues(MainStatsData newValues)
    {
        freePointsField.text = newValues.Points.ToString();
        healthPointsField.text = newValues.Health.ToString();
        attackPointsField.text = newValues.Attack.ToString();
        defencePointsField.text = newValues.Defence.ToString();
    }
    public void ChangeBackgroundColor(int value)
    {
        backgrounds[value].color = colorOfChange;
    }
    public void ResetBackgroundsColorToDefault()
    {
        foreach (var item in backgrounds)
        {
            item.color = defaultColor;
        }
    }

}
