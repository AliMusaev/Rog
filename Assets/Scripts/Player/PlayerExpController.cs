using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerExpController
{
    public static event Action<int> UpdateExpInfo;
    public static event Action<int, int> UpdateLevelAndReqiredExp;
    public enum Exp
    {
        Level,
        CurrentExp,
        RequiredExp,
        FreePoints,
    }
    public static Dictionary<Exp, int> ExpParams { get => m_expParams; }
    private static Dictionary<Exp, int> m_expParams;

    public static void InitializeNewExpInfo()
    {
        m_expParams = new Dictionary<Exp, int>();
        m_expParams.Add(Exp.Level, 1);
        m_expParams.Add(Exp.CurrentExp, 0);
        m_expParams.Add(Exp.RequiredExp, 10);
        m_expParams.Add(Exp.FreePoints, 10);
    }
    public static void UpdateFreePoints(int value)
    {
        ExpParams[Exp.FreePoints] = value;
    }
    public static void AddExpForBattle(int addedExp)
    {
        m_expParams[Exp.CurrentExp] += addedExp;
        while (m_expParams[Exp.CurrentExp] > m_expParams[Exp.RequiredExp])
        {
            m_expParams[Exp.CurrentExp] -= m_expParams[Exp.RequiredExp];
            LvlUp();
            
        }
        UpdateExpInfo.Invoke(m_expParams[Exp.CurrentExp]);

    }
    private static void LvlUp()
    {
        m_expParams[Exp.FreePoints] += 25;
        m_expParams[Exp.Level] += 1;
        m_expParams[Exp.RequiredExp] = (int)(m_expParams[Exp.RequiredExp] * Math.Pow(1.01, m_expParams[Exp.Level]));
        UpdateLevelAndReqiredExp.Invoke(m_expParams[Exp.Level], m_expParams[Exp.RequiredExp]);
    }
   
}
