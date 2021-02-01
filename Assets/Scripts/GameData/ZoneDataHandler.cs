using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDataHandler
{
    private static readonly ZoneDataHandler instance = new ZoneDataHandler();
    private static List<ZoneData> zoneDatas;
    private static readonly int repeatMax = 5;
    public static Zone GetNewZone()
    {
        Debug.Log("dsa");
        var i = CalculateZoneId();
        return new Zone(zoneDatas[i].ValueId, zoneDatas[i].valueVariants[CalculateAttributeValue(i)], CalculateRepeatValue());
    }
    private ZoneDataHandler()
    {
        zoneDatas = new DataLoader().LoadZoneInfoFromFile();
    }

    private static int CalculateZoneId()
    {
        System.Random rand = new System.Random();
        double[] chanceValues = new double[zoneDatas.Count];
        for (int i = 0; i < chanceValues.Length; i++)
        {
            if (i > 0)
                chanceValues[i] = zoneDatas[i].ProcChance + zoneDatas[i-1].ProcChance;
            else
                chanceValues[i] = zoneDatas[i].ProcChance;
        }
        var a = rand.NextDouble() * 100;
        for (int i = 0; i < chanceValues.Length; i++)
        {
            if (i > 0 && i + 1 != chanceValues.Length)
            {
                if (a > chanceValues[i - 1] && a < chanceValues[i + 1])
                    return i;
            }
            else if(i == 0)
            {
                if (a < chanceValues[i + 1])
                    return i;
            }
            else if(i + 1 == chanceValues.Length)
            {
                if (a > chanceValues[i - 1])
                    return i;
            }
        }
        Debug.Log("ZoneDataHandler CalculateZoneId Error");
        return -1;
    }
    private static int CalculateAttributeValue(int i)
    {
        System.Random rand = new System.Random();
        return rand.Next(i, zoneDatas[i].valueVariants.Count);
    }
    private static int CalculateRepeatValue()
    {
        System.Random rand = new System.Random();
        return rand.Next(1, repeatMax);
    }

}
