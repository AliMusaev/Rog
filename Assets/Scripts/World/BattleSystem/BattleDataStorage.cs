using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDataStorage
{
    private static readonly BattleDataStorage instance = new BattleDataStorage();
    private static RegularEnemyCreator eCreator;

    public static List<double> EnemyAttacksCounter { get => enemyAttacksCounter; set => enemyAttacksCounter = value; }
    private static List<double> enemyAttacksCounter;
    public static List<double> PlayerAttacksCounter { get => playerAttacksCounter; set => playerAttacksCounter = value; }
    public static Zone ActualZone { get => actualZone;}
    public static double[] PlayerStats { get => playerStats;}
    public static IEnemy Enemy { get => eCreator.CloneEnemy(enemy);}
    public static bool LastBattleResult { get => lastBattleResult; set => lastBattleResult = value; }
    public static bool BattleRepresentIsFinished { get => battleRepresentIsFinished; set => battleRepresentIsFinished = value; }

    private static List<double> playerAttacksCounter;
    private static Zone actualZone;
    private static IEnemy enemy;
    private static double[] playerStats;
    private static bool lastBattleResult = false;
    private static bool battleRepresentIsFinished = false;


    private BattleDataStorage()
    {
        playerAttacksCounter = new List<double>();
        enemyAttacksCounter = new List<double>();
        eCreator = new RegularEnemyCreator();
    }
    public static void LoadActualDataBeforeBattle()
    {
        playerAttacksCounter.Clear();
        enemyAttacksCounter.Clear();
        battleRepresentIsFinished = false;
        actualZone = PlayerMainController.ActualZone;
        playerStats = (double[])PlayerMainController.PlayerStats.Clone();
        enemy = eCreator.CreateEnemy(BattleDataStorage.ActualZone.ZoneLvl);
    }

   
}
