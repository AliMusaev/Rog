using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGameController : MonoBehaviour
{
    private void Start()
    {
    }

    public void NewGameButtonPressed()
    { 
        PlayerMainController.InitializeNewPlayer();
        PlayerItemsController.InitializePlayerInventory();
        PlayerExpController.InitializeNewExpInfo();
        PlayerMainController.UpdatePlayerStats();
    }
}
