using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider ExpSlider;
    public Slider TrigerSlider;
    public Text CurrentExp;
    public Text RequiredExp;
    public Text PlayerLevel;
    public Text PlayerSteps;
    void Start()
    {
        PlayerExpController.UpdateExpInfo += UpdateCurrentExpInformation;
        PlayerExpController.UpdateLevelAndReqiredExp += UpdateLevelAndRequiredExpInfo;
        EnemyTrigger.UpdateTraveledDistance += UpdateEnemyTrigger;
        PlayerMainController.PlayerMoves += PlyerSteps;
        
        UpdateLevelAndRequiredExpInfo(PlayerExpController.ExpParams[PlayerExpController.Exp.Level], PlayerExpController.ExpParams[PlayerExpController.Exp.RequiredExp]);
    }

    private void UpdateCurrentExpInformation(int curExp)
    {
        ExpSlider.value = curExp;
        CurrentExp.text = curExp.ToString();
    }
    private void UpdateLevelAndRequiredExpInfo(int level, int reqExp)
    {
        PlayerLevel.text = level.ToString();
        ExpSlider.maxValue = reqExp;
        ExpSlider.value = 0;
        RequiredExp.text = reqExp.ToString();
        PlyerSteps();

    }
    private void UpdateEnemyTrigger(float distTraveled)
    {
        TrigerSlider.value = distTraveled;
    }
    private void PlyerSteps()
    {
        PlayerSteps.text = PlayerMainController.Steps.ToString();
    }

}
