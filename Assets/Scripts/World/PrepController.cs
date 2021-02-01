using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepController
{
    private double[] _playerStats;
    private double[] _enemyParams;
    private Zone zone;
    public double[] _rewardMultipliers { get; private set; }
    public PrepController(double [] _playerStats, double[] _enemyParams, Zone zone)
    {
        this._playerStats = _playerStats;
        this._enemyParams = _enemyParams;
        this.zone = zone;
        _rewardMultipliers = new double[3];
        for (int i = 0; i < _rewardMultipliers.Length; i++)
        {
            _rewardMultipliers[i] = 1;
        }
        SetPlayerBonus();
    }
    private void SetPlayerBonus()
    {
        switch (zone.Id)
        {
            case 0:
                return;
            case 1:
                _rewardMultipliers[0] = zone.Value;
                break;
            case 2:
                _rewardMultipliers[1] = zone.Value;
                break;
            case 3:
                _rewardMultipliers[2] = zone.Value;
                break;
        }
    }
}
