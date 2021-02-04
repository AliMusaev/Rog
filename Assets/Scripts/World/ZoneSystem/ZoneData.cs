using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneData
{
    public int ValueId { get; private set; }
    public string Name { get; private set; }
    public double ProcChance { get; private set; }
    public int Value { get; private set; }
    public List<int> valueVariants { get; private set; }
    public ZoneData(string[] inputData)
    {
        valueVariants = new List<int>();
        ValueId = Int32.Parse(inputData[0]);
        Name = inputData[1];
        ProcChance = double.Parse(inputData[2]);
        for (int i = 3; i < inputData.Length -1; i++)   //-1 baecause last element is empty (need to fix)
        {
            valueVariants.Add(Int32.Parse(inputData[i]));
        }
    }
}
