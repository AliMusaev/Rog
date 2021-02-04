using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDataHandler
{
    private readonly int maxMulti = 5;
    private readonly int maxRepeat = 5;
    // without mod - 85; EXP - 5; Gold - 5; Loot Drop - 5;
    private readonly int[] modsProcChances = new int[4] {5, 50, 80, 100 };
    private static System.Random rand = new System.Random();
    public  int[] GetNewZone()
    {
        return new int[3] { CalculateModType(), CalculateAttributeValue(), CalculateRepeatValue() };
    }
   
    // 0 - without mod; 1 - EXP; 2 - Gold; 3 - Loot Drop;
    private  int CalculateModType()
    {
        
        var a = rand.NextDouble() * 100;
        for (int i = 0; i < modsProcChances.Length; i++)
        {
            if (i > 0 && i + 1 != modsProcChances.Length)
            {
                if (a > modsProcChances[i - 1] && a < modsProcChances[i + 1])
                    return i;
            }
            else if(i == 0)
            {
                if (a < modsProcChances[i + 1])
                    return i;
            }
            else if(i + 1 == modsProcChances.Length)
            {
                if (a > modsProcChances[i - 1])
                    return i;
            }
        }
        Debug.Log("ZoneDataHandler CalculateZoneId Error");
        return -1;
    }
    private int CalculateAttributeValue()
    {
        return rand.Next(1, maxMulti);
    }
    private int CalculateRepeatValue()
    {
        return rand.Next(1, maxRepeat);
    }

}
