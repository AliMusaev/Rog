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
        Hud.View = this.view;
        Hud.Controller = this.controller;
        hud.SetActive(false);
    }
}
