using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudInitializer : MonoBehaviour
{
    [SerializeField] GameObject hud;
    [SerializeField] private HudView view;
    [SerializeField] private HudController controller;
    void Start()
    {
        HudHandler.View = this.view;
        HudHandler.Controller = this.controller;
        hud.SetActive(false);
    }
}
