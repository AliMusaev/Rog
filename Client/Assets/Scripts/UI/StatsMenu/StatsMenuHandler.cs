using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenuHandler 
{
    public static event Action<MainStatsData> SavingChanges;
    public static event Action ResetingValues;

    private MainStatsData mainStatsData;

    public static StatsMenuView View;
    public static StatsMenuControl Control;
    public StatsMenuHandler()
    {
        StatsMenuControl.ChangingStats += ChangeStats;
        StatsMenuControl.SavingChanges += OnSavingChanges;
        StatsMenuControl.RequestingValues += OnRequestingValues;
    }

    // This method called from UIController
    public void UpdatePlayerStatsFrom(MainStatsData dataFromModel)
    {
        this.mainStatsData = dataFromModel;
        View.UpdateValues(mainStatsData);
    }

    private void OnRequestingValues()
    {
        View.ResetBackgroundsColorToDefault();
        ResetingValues.Invoke();
    }
    private void OnSavingChanges()
    {
        View.ResetBackgroundsColorToDefault();
        SavingChanges.Invoke(mainStatsData);
        
    }
    // Methods intended to communticate betwen statsMenu, statsMenuControl and statsMenuView
    // valueType 1 - 1 point; 2 - half points; 3 - all points;
    // fieldNumber 0 - hp; 1 - ap; 2 - dp;
    private void ChangeStats(int requestValueType, int fieldNumber)
    {
        int requestedPoints = CalculcateRequestedPoints(requestValueType);
        bool CheckAvailabilityResult = CheckAvailability(requestedPoints);

        if (CheckAvailabilityResult)
        {
            switch (fieldNumber)
            {
                case 0:
                    mainStatsData.Health += requestedPoints;
                    break;
                case 1:
                    mainStatsData.Attack += requestedPoints;
                    break;
                case 2:
                    mainStatsData.Defence += requestedPoints;
                    break;
                default:
                    break;
            }
            mainStatsData.Points -= requestedPoints;
            // Send values to update in view
            View.UpdateValues(mainStatsData);
            // Colored choosen stat field
            View.ChangeBackgroundColor(fieldNumber);
        }
        else
        {
            Debug.LogWarning("Points has not assigned");
        }
       
    }
    private bool CheckAvailability(int requestedPoints)
    {
        bool result;
        if (mainStatsData.Points != 0)
        {
            if (mainStatsData.Points >= requestedPoints)
            {
                result = true;
            }
            else
            {
                Debug.LogWarning("Wrong Free points value");
                result = false;
            }
        }
        else
        {
            Debug.LogWarning("Free points = 0");
            result = false;
        }
           
        return result;
    }
    private int CalculcateRequestedPoints(int requestType)
    {
        int result = 0;
        switch (requestType)
        {
            case 1:
                result = 1;
                break;
            case 2:
                result = mainStatsData.Points / 2;
                break;
            case 3:
                result = mainStatsData.Points;
                break;
        }
        return result;
    }
}

