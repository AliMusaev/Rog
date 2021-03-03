using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenuInitializer : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private StatsMenuView statsMenuView;
    [SerializeField] private StatsMenuControl statsMenuControl;
    void Start()
    {
        StatsMenuHandler.View = this.statsMenuView;
        StatsMenuHandler.Control = this.statsMenuControl;
        Menu.SetActive(false);
    }
}
