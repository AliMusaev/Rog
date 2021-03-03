using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


// Item Eff id: 0-hp; 1-atk; 2-def; 3-block 4-dodge; 5-crit rate; 6-crit chance; 7-gold multi; 8-drop rate; 
public class ItemData : ICloneable
{ 
    public int ObjectId { get; private set; }
    public int ItemId { get; private set; }
    public int IconId { get; private set; }
    public int ItemType { get; private set; }
    public int ItemSubType { get; private set; }
    public string ItemName { get; private set; }
    public int ItemGrade { get; private set; }
    // item effects [id,value]
    public int[,] MainEffect;
    public int[,] SpecialEffects;

    public ItemData(string[] inputData, int objectId)
    {
        MainEffect = new int[2, 1];
        SpecialEffects = new int[3,2];

        ItemId = Int32.Parse(inputData[0]);
        IconId = Int32.Parse(inputData[1]);
        ItemType = Int32.Parse(inputData[2]);
        ItemSubType = Int32.Parse(inputData[3]);
        ItemName = inputData[4];
        MainEffect [0,0] = Int32.Parse(inputData[6]);
        MainEffect [1,0]= Int32.Parse(inputData[7]);
        
        ItemGrade = Int32.Parse(inputData[8]);

        SpecialEffects[0, 0] = Int32.Parse(inputData[9]);
        SpecialEffects[0, 1] = Int32.Parse(inputData[10]);
        SpecialEffects[1, 0] = Int32.Parse(inputData[11]);
        SpecialEffects[1, 1] = Int32.Parse(inputData[12]);
        SpecialEffects[2, 0] = Int32.Parse(inputData[13]);
        SpecialEffects[2, 1] = Int32.Parse(inputData[14]);

        this.ObjectId = objectId;
    }
   
    private ItemData(ItemData item)
    {

        this.ItemId = item.ItemId;
        this.IconId = item.IconId;
        this.ItemType = item.ItemType;
        this.ItemSubType = item.ItemSubType;
        this.ItemName = item.ItemName;
        this.MainEffect = (int[,])item.MainEffect.Clone();
        ItemGrade = item.ItemGrade;
        this.SpecialEffects = (int[,])item.SpecialEffects.Clone();
        this.ObjectId = item.ObjectId;
    }
    public object Clone()
    {
        return new ItemData(this);
    }
}