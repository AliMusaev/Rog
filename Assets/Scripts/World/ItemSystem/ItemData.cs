using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{ 
    public int ItemId { get; private set; }
    public int IconId { get; private set; }
    public int ItemType { get; private set; }
    public int ItemSubType { get; private set; }
    public string ItemName { get; private set; }
    public bool ItemIsExist { get; private set; } 
    public int ItemValueId { get; private set; } 
    public int ItemValue { get; private set; } 
    public int ItemGrade { get; private set; }
    public int[] ItemAdditionalsId { get; private set; } 
    public int[] ItemAdditionalsValues { get; private set; }

    

    public readonly int Id;

    public ItemData(string[] inputData, int itemId)
    {
        ItemAdditionalsId = new int[3];
        ItemAdditionalsValues = new int[3];
        ItemId = Int32.Parse(inputData[0]);
        IconId = Int32.Parse(inputData[1]);
        ItemType = Int32.Parse(inputData[2]);
        ItemSubType = Int32.Parse(inputData[3]);
        ItemName = inputData[4];
        if (inputData[5] == "1")
            ItemIsExist = true;
        else
            ItemIsExist = false;
        ItemValueId = Int32.Parse(inputData[6]);
        ItemValue = Int32.Parse(inputData[7]);
        ItemGrade = Int32.Parse(inputData[8]);
        ItemAdditionalsId[0] = Int32.Parse(inputData[9]);
        ItemAdditionalsValues[0] = Int32.Parse(inputData[10]);
        ItemAdditionalsId[1] = Int32.Parse(inputData[11]);
        ItemAdditionalsValues[1] = Int32.Parse(inputData[12]);
        ItemAdditionalsId[2] = Int32.Parse(inputData[13]);
        ItemAdditionalsValues[2] = Int32.Parse(inputData[14]);
        this.Id = itemId;
    }
   
    private ItemData(ItemData item)
    {

        ItemId = item.ItemId;
        IconId = item.IconId;
        ItemType = item.ItemType;
        ItemSubType = item.ItemSubType;
        ItemName = item.ItemName;
        ItemIsExist = item.ItemIsExist;
        ItemValueId = item.ItemValueId;
        ItemValue = item.ItemValue;
        ItemGrade = item.ItemGrade;
        ItemAdditionalsId = item.ItemAdditionalsId;
        ItemAdditionalsValues = item.ItemAdditionalsValues;
        Id = item.Id;
    }
    public ItemData Clone()
    {
        return new ItemData(this);
    }
}