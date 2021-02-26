using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleRepresenter : MonoBehaviour
{
    [SerializeField] GameObject BattleLogContent;
    [SerializeField] ScrollRect ScrollRect;
    [SerializeField] GameObject BattleLogTextPrefab;
    [SerializeField] Slider EnemyHpSlider;
    [SerializeField] Slider PlayerHpSlider;
    // Contains the player and enemy attacks
    private List<double> playerAttacks;
    private List<double> enemyAttacks;
    // If false - attack player, if true - enemy;
    private bool sideSwitcher = false;
    // Delay before display new message into log
    private float timeRemaining = 0.1f;
    // Starts battle representer
    private bool StartSwitcher = false;
    // Counts the number of lines entered into the log
    private int itterCounter; 
    // Needed to represet hp sliders
    private double playerHp; 
    private double enemyHp;

    void Update()
    {

        if (StartSwitcher && !BattleDataStorage.BattleRepresentIsFinished)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("TimerIsEnd");
                GenerateMessageToBattleLog();
                timeRemaining = 0.1f;
                if (itterCounter == playerAttacks.Count - 1) 
                {
                    timeRemaining = 0;
                    StartSwitcher = false;
                    BattleDataStorage.BattleRepresentIsFinished = true;
                }
                
            }
        }
    }
    public void StartReperesent()
    {
        PrepareToStartRepresent();
        
        playerAttacks = BattleDataStorage.PlayerAttacksCounter;
        enemyAttacks = BattleDataStorage.EnemyAttacksCounter;
        playerHp = BattleDataStorage.PlayerStats[0];
        enemyHp = BattleDataStorage.Enemy.EnemyHealth;
        EnemyHpSlider.maxValue = (float)enemyHp;
        EnemyHpSlider.value = (float)enemyHp;
        PlayerHpSlider.maxValue = (float)playerHp;
        PlayerHpSlider.value = (float)playerHp;
        StartSwitcher = true;
    }
    private void PrepareToStartRepresent()
    {
        // Cleaning the battlelog if it is contained old lines;
        RectTransform[] oldObjects = BattleLogContent.GetComponentsInChildren<RectTransform>();
        if (oldObjects.Length > 1)
        {
            for (int i = 1; i < oldObjects.Length; i++)
                GameObject.Destroy(oldObjects[i].gameObject);
        }
        // Reset Itteration counter
        itterCounter = 0;

    }
    void GenerateMessageToBattleLog()
    {
        if (!sideSwitcher)
        {
            if (itterCounter <= playerAttacks.Count - 1)
            {
                BattleLogTextPrefab.GetComponent<Text>().text = $"Player attack: {playerAttacks[itterCounter]}";
                Instantiate<GameObject>(BattleLogTextPrefab, BattleLogContent.transform);
                sideSwitcher = true;
            }
        }
        else if (sideSwitcher)
        {
            if (itterCounter <= enemyAttacks.Count - 1)
            {
                BattleLogTextPrefab.GetComponent<Text>().text = $"Enemy attack: {enemyAttacks[itterCounter]}";
                Instantiate<GameObject>(BattleLogTextPrefab, BattleLogContent.transform);
                sideSwitcher = false;
                itterCounter++;
            }
        }
        ScrollRect.velocity = new Vector2(0f, 100000f);
        UpdateHpSlider();

    }
    void UpdateHpSlider()
    {
        if (!sideSwitcher)
        {
            EnemyHpSlider.value -= (float)playerAttacks[itterCounter];
        }
        if (sideSwitcher)
        {
            PlayerHpSlider.value -= (float)enemyAttacks[itterCounter];
        }
    }
}
