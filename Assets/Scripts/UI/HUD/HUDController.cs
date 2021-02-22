using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Button StatsMenuButton;
    [SerializeField] private Button InventoryMenuButton;
    [SerializeField] private Button SettingsMenuButton;

    private void Start()
    {
        //
        HudHandler.Controller = this;
    }
}
   
