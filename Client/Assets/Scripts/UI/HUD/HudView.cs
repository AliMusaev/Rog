using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudView : MonoBehaviour
{
    [Header("Value Fields")]
    [SerializeField] private Text level;
    [SerializeField] private Text gold;
    [SerializeField] private Text steps;
    [Header("Exp Slider")]
    [SerializeField] private Slider expSlider;
    [SerializeField] private Text currentExp;
    [SerializeField] private Text reqExp;
    [Header("Zone Info")]
    [SerializeField] private Text zoneLevel;
    [SerializeField] private Text zoneInfo;
    [SerializeField] private Slider enemyGaugeSlider;

    private void Start()
    {
        HudHandler.View = this;
    }
    public void RepresentExpData(ExpData input)
    {
        this.currentExp.text = input.CurrentExp.ToString();
        this.reqExp.text = input.ReqExp.ToString();
        this.level.text = input.Level.ToString();

        expSliderControl(input);
    }
    public void RepresentCurrencyData(CurrencyData input)
    {
        this.gold.text = input.Gold.ToString();
    }
    public void RepresentStepsData(StepsData input)
    {
        this.steps.text = input.Value.ToString();
    }
    public void RepresentZoneData(ZoneData input)
    {
        this.zoneLevel.text = input.Level.ToString();
        zoneInfoBuilder(input);
    }
    public void RepresentGaugeData(GaugeData input)
    {
        enemyGaugeSlider.minValue = 0;
        enemyGaugeSlider.maxValue = input.maxDist;
        enemyGaugeSlider.value = input.CurrentDist;
    }
    private void zoneInfoBuilder(ZoneData input)
    {
        string value = null;
        if (input.ExpMulti != 0)
        {
            value += $"Increase gained Exp : {input.ExpMulti}. ";
        }
        if (input.GoldMulti != 0)
        {
            value += $"Increase gained Gold : {input.GoldMulti}. ";
        }
        if (input.DropMulti != 0)
        {
            value += $"Increase drop chance : {input.DropMulti}. ";
        }
        if (value != null)
        {
            value += $"On {input.SetpsLeft}";
        }
        else
        {
            value = "Zone without effects";
        }
        this.zoneInfo.text = value;
    }
    private void expSliderControl(ExpData input)
    {
        expSlider.minValue = 0;
        expSlider.maxValue = input.ReqExp;
        expSlider.value = input.CurrentExp;
    }

}
