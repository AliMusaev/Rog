using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowerPanelController : MonoBehaviour
{
    public Text[] Values;

    private void Start()
    {
        PlayerMainController.PlayerStatsUpdated += UpdateStatsField;
    }
    private void OnEnable()
    {
        UpdateStatsField();
    }
    void UpdateStatsField()
    {
        for (int i = 0; i < Values.Length; i++)
        {
            Values[i].text = PlayerMainController.PlayerStats[i].ToString();
        }
    }

}
