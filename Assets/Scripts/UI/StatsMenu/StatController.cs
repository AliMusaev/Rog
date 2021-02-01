using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public GameObject[] StatsValueFields;
    public Text FreePointsField;
    public Button SaveButton;
    public Button ResetButton;
    public int FieldSwitcher;
    private int[] _ActualFieldsValue;
    private Text[] _ValueFields;
    private Color _DefaultColor;
    private Image[] _Backgrounds;
    private int _TempFreePoints;
    private int _MainStatsCount;

    private void OnEnable()
    {
        UpdateCurrentValues();
    }
    void Start()
    {
        _MainStatsCount = PlayerMainController.MainStats.Length;
        SaveButton.onClick.AddListener(SaveChanges);
        ResetButton.onClick.AddListener(ResetChanges);
        _ActualFieldsValue = new int[_MainStatsCount];
        _ValueFields = new Text[_MainStatsCount];
        _Backgrounds = new Image[_MainStatsCount];
        for (int i = 0; i < _MainStatsCount; i++)
        {
            _ValueFields[i] = StatsValueFields[i].GetComponentInChildren<Text>();
            _Backgrounds[i] = StatsValueFields[i].GetComponent<Image>();
        }
        _DefaultColor = new Color();
        _DefaultColor = _Backgrounds[0].color;
        UpdateCurrentValues();
    }
    public void ChangeSwitcher(int value)
    {
        FieldSwitcher = value;
    }
    public void AddValue(int value)
    {
        if (AvailabilityCheck())
        {
            if (value == 1)
            {
                _ActualFieldsValue[FieldSwitcher] += 1;
                _TempFreePoints -= 1;
            }
            if (value == 2)
            {
                _ActualFieldsValue[FieldSwitcher] += _TempFreePoints / 2;
                _TempFreePoints -= _TempFreePoints / 2;
            }
            if (value == 3)
            {
                _ActualFieldsValue[FieldSwitcher] += _TempFreePoints;
                _TempFreePoints -= _TempFreePoints;

            }
            UpdateAddedValue();
            ChangeBackgroundColor(0);
        }
    }
    private void UpdateCurrentValues()
    {
        _TempFreePoints = PlayerExpController.ExpParams[PlayerExpController.Exp.FreePoints];
        FreePointsField.text = _TempFreePoints.ToString();
        for (int i = 0; i < _MainStatsCount; i++)
        {
            _ActualFieldsValue[i] = PlayerMainController.MainStats[i];
            _ValueFields[i].text = _ActualFieldsValue[i].ToString();
        }
    }
    private void UpdateAddedValue()
    {
        _ValueFields[FieldSwitcher].text = _ActualFieldsValue[FieldSwitcher].ToString();
        FreePointsField.text = _TempFreePoints.ToString();
    } // обновление инфоормации в измененных полях
    private bool AvailabilityCheck() // Проверка на не отрицательное значение свободных очков статов
    {
        if (_TempFreePoints > 0)
            return true;
        return false;
    }
    private void ChangeBackgroundColor(int value)
    {
        switch (value)
        {
            case 0:
                _Backgrounds[FieldSwitcher].color = Color.red;
                break;
            case 1:
                for (int i = 0; i < _Backgrounds.Length; i++)
                {
                    _Backgrounds[i].color = _DefaultColor;
                }
                break;

        }
        
    }
    private void SaveChanges()
    {
        PlayerExpController.UpdateFreePoints(_TempFreePoints);
        PlayerMainController.SetNewMainStatsByUserInput(_ActualFieldsValue);
        ChangeBackgroundColor(1);
    }
    private void ResetChanges()
    {
        UpdateCurrentValues();
        ChangeBackgroundColor(1);
    }
}
