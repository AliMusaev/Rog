using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OldBattleController : MonoBehaviour
{
    public UnityEvent BattleCalcIsComplete;
    public UnityEvent CallRewardControll;
    [Header("Battle Window")]
    [SerializeField] GameObject BattleWindow;
    [SerializeField] Button ExitButton;
    [Header("Reward Menu")]
    [SerializeField] GameObject RewardMenu;


    private BattleMath bMath;
    private void Start()
    {
        //EnemyGauge.CallBattle += HandleBattle;
        BattleWindow.SetActive(false);
    }
    private void Update()
    {
        if (BattleDataStorage.BattleRepresentIsFinished)
        {
            BattleDataStorage.BattleRepresentIsFinished = false;
            RewardMenu.SetActive(true);
            CallRewardControll.Invoke();
        }
    }
    public void HandleBattle()
    {
        BattleWindow.SetActive(true);
        BattleDataStorage.LoadActualDataBeforeBattle();
        bMath = new BattleMath();
        if (bMath.Fight())
            BattleDataStorage.LastBattleResult = true;
        else
            BattleDataStorage.LastBattleResult = false;
        BattleCalcIsComplete.Invoke();
    }


   
   
}
