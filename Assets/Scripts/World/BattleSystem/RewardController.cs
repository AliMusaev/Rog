using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardController : MonoBehaviour
{
    //[SerializeField] Text ResultAttention;
    //[SerializeField] Text EarnedExp;
    //[SerializeField] Text EarnedGold;
    //[SerializeField] Text AddedLvls;
    //[SerializeField] Text AddedStatPoints;
    //[SerializeField] Text ItemField;
    //private int playerLvlBeforeReward;
    //private int playerLvlAfterReward;
    //private int playerFreePointsBeforeReward;
    //private int playerFreePointsAfterReward;
    //private RewardMath rMath;

    //public void StartRewarding()
    //{
    //    if (BattleDataStorage.LastBattleResult)
    //    {
    //        LoadInfoBeforeReward();
    //        rMath = new RewardMath();
    //        rMath.CalculateReward();
    //        LoadInfoAfterReward();
    //        OldPlayerMainController.UpdateSteps(1);
    //        ResultAttention.text = "YOU WIN";
    //        EarnedExp.text = rMath.CalculatedExp.ToString();
    //        EarnedGold.text = rMath.CalculatedGold.ToString();
    //        AddedLvls.text = (playerLvlAfterReward - playerLvlBeforeReward).ToString();
    //        AddedStatPoints.text = (playerFreePointsAfterReward - playerFreePointsBeforeReward).ToString();
    //        if (rMath.item != null)
    //        {
    //            ItemField.text = $"EARNED: {rMath.item.ItemName}";
    //        }
    //    }
    //    else
    //    {
    //        OldPlayerMainController.UpdateSteps(5);
    //    }
    //}
    //private void LoadInfoBeforeReward()
    //{
    //    playerLvlBeforeReward = OldPlayerExpController.ExpParams[OldPlayerExpController.Exp.Level];
    //    playerFreePointsBeforeReward = OldPlayerExpController.ExpParams[OldPlayerExpController.Exp.FreePoints];
    //}
    //private void LoadInfoAfterReward()
    //{
    //    playerLvlAfterReward = OldPlayerExpController.ExpParams[OldPlayerExpController.Exp.Level];
    //    playerFreePointsAfterReward = OldPlayerExpController.ExpParams[OldPlayerExpController.Exp.FreePoints];
    //}
}   

