using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldItem : MonoBehaviour
{
    public Image ItemIcon;
    public Text Name;
    public Button Buy;
    public Button EquipButton;
    public Text Value;
    public Image ValueIcon;
    public GameObject [] AddValueFields;

    private ItemData _Item;
   

   
    private int cellNumber;

    private void Start()
    {
        EquipButton.onClick.AddListener(EquipItem);
    }
    public void SetItemData(ItemData item, Sprite [] sprites, Sprite [] itemIcons ,int cellNumber)
    {
        _Item = (ItemData)item.Clone();
        ItemIcon.sprite = itemIcons[_Item.IconId];
        Name.text = _Item.ItemName;
        ValueIcon.sprite = sprites[_Item.MainEffect[0,0]];
        Value.text = _Item.MainEffect[1, 0].ToString();
        this.cellNumber = cellNumber;
        DrawAdditionalValues(sprites);
    }
    public void SetEquippedItemData(ItemData item, Sprite[] sprites, Sprite[] itemIcons, int cellNumber)
    {
        SetItemData(item, sprites,itemIcons,cellNumber);
        this.GetComponent<Image>().color = Color.green;
    }

    private void  DrawAdditionalValues(Sprite [] sprites)
    {
        
        //for (int i = 0; i < AddValueFields.Length; i++)
        //{
        //    if (_Item.ItemAdditionalsId[i] == -1)
        //        AddValueFields[i].SetActive(false);
        //    else
        //    {
        //        foreach (var item in AddValueFields[i].GetComponentsInChildren<Image>())
        //        {
        //            if (item.name == "StatIcon")
        //                item.sprite = sprites[_Item.ItemAdditionalsId[i]];
        //        }
        //        AddValueFields[i].GetComponentInChildren<Text>().text = _Item.ItemAdditionalsValues[i].ToString();
        //    }
        //}
    }


    private void LoadItemInformation()
    {
        
        
        

    }
    private void DrawGradeBorder()
    {
    }

    private void EquipItem()
    {
        OldPlayerItemsController.EquipItemOnPlayer(_Item, cellNumber);

    }
}
