using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDataCalculator
{
    private readonly int zoneLvl;
    private readonly int maxMulti = 5;
    private readonly int maxRepeat = 5;
    // without mod - 85; EXP - 5; Gold - 5; Loot Drop - 5;
    private readonly int[] chance = new int[4] {85, 90, 95, 100};
    private static System.Random rand = new System.Random();
    public ZoneDataCalculator(int zoneLvl)
    {
        this.zoneLvl = zoneLvl;
    }
    public ZoneData GetNewZone()
    {
        return CalculateModType();
    }
   
    // 0 - without mod; 1 - EXP; 2 - Gold; 3 - Loot Drop;
    private ZoneData CalculateModType()
    {
        ZoneData actualZone = new ZoneData();
        actualZone.Level = zoneLvl;
        actualZone.SetpsLeft = CalculateRepeatValue();
        var a = rand.Next(0, 100);
        if (a <= chance[0])
        {

        }
        else if(a > chance[0] && a <= chance[1])
        {
            actualZone.ExpMulti = CalculateAttributeValue();
        }
        else if(a > chance[1] && a <= chance[2])
        {
            actualZone.GoldMulti = CalculateAttributeValue();
        }
        else if(a> chance[2]&& a <= chance[3])
        {
            actualZone.DropMulti = CalculateAttributeValue();
        }
        else
        {
            Debug.Log("ZoneDataHandler CalculateZoneId Error");
        }
        return actualZone;
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
