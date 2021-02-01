using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    private double[] _playerStats;
    private double[] _enemyParams;
    private Zone zone;
    public FightController(double[] _playerStats, double[] _enemyParams, Zone zone)
    {
        this._playerStats = _playerStats;
        this._enemyParams = _enemyParams;
        this.zone = zone;
    }
    public bool Fight()
    {
        while (_playerStats[0] > 0 && _enemyParams[0] > 0)
        {
            PlayerAttacking();
            if (_enemyParams[0] > 0)
                EnemyAttacking();
        }
        if (_playerStats[0] > 0)
            return true;
        else
            return false;
    }
    void PlayerAttacking()
    {
        _enemyParams[0] -= DmgCalculate(_playerStats[1], _enemyParams[2]);
        if (_enemyParams[0] < 0)
            _enemyParams[0] = 0;
    }
    void EnemyAttacking()
    {
        _playerStats[0] -= DmgCalculate(_enemyParams[1], _playerStats[2]);
        if (_playerStats[0] < 0)
            _playerStats[0] = 0;
    }

    double DmgCalculate(double atk, double def)
    {
        if (atk <= def)
            return 0;
        return atk - def;
    }
}
