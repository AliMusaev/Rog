using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommunicationLibrary;
using System;

public class HudController : MonoBehaviour
{
    [SerializeField] private Button StatsMenuButton;
    [SerializeField] private Button InventoryMenuButton;
    [SerializeField] private Button SettingsMenuButton;
    private Communication comm;
    private int val = 111;
    private void Start()
    {
        //
        comm = new Communication();
        HudHandler.Controller = this;
        StatsMenuButton.onClick.AddListener(TestMethod);
    }
    private void TestMethod()
    {
        string msg;

        comm.GoldUpdate($"2 + {DateTime.Now}", 2, val, out msg);
        val++;
        Debug.Log(msg);
    }

}
   
