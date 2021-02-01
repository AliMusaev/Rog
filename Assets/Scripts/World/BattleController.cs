using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattleController
{
    private double[] _playerStats;
    private double[] _enemyParams;
    PrepController prep;
    public BattleController(int _zonelvl, Zone zone)
    {
        _playerStats = PlayerMainController.PlayerStats;
        _enemyParams = new Enemy(_zonelvl).EnemyParams;
        prep = new PrepController(_playerStats, _enemyParams, zone);
        FightController fight = new FightController(_playerStats, _enemyParams, zone);
        if (fight.Fight())
        {
            RewardController reward = new RewardController(_zonelvl, prep._rewardMultipliers);
            reward.GetReward();
            PlayerMainController.UpdateSteps(1);
            Debug.Log("Win");
        }
        else
        {
            PlayerMainController.UpdateSteps(5);
            Debug.Log("Lose");
        }
    }
   
   
}
