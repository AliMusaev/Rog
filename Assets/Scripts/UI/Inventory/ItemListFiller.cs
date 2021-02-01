using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListFiller : MonoBehaviour
{
    public GameObject ItemFieldPrefab;
    public GameObject ContentParent;
    private List<GameObject> _CreatedItems;
    private Sprite[] _Icons;
    private Sprite[] _ItemIcons;
    private int _ChosenItemFieldNumber;
    public void Fill(int fieldNum)
    {
        _CreatedItems = new List<GameObject>();
        _ChosenItemFieldNumber = fieldNum; 
        _Icons = Resources.LoadAll<Sprite>("Sprites/StatIcons");
        _ItemIcons = Resources.LoadAll<Sprite>("Sprites/ItemsSprites");
        DisplayEquippedItem();
        DisplayNotEquippedItems();
    }
    
    private void DisplayEquippedItem()
    {
        if (PlayerItemsController.EquippedItems[_ChosenItemFieldNumber] != null)
        {
            var b = Instantiate<GameObject>(ItemFieldPrefab, ContentParent.transform);
            b.GetComponent<Item>().SetEquippedItemData(PlayerItemsController.EquippedItems[_ChosenItemFieldNumber], _Icons, _ItemIcons, _ChosenItemFieldNumber);
        }
    }
    private void DisplayNotEquippedItems()
    {
        int type = PlayerItemsController.GetItemTypeByCellNumber(_ChosenItemFieldNumber);
        for (int i = 0; i < PlayerItemsController.Inventory.Count; i++)
        {
            if (PlayerItemsController.Inventory[i].ItemType == type)
            {
                var a = Instantiate<GameObject>(ItemFieldPrefab, ContentParent.transform);
                a.GetComponent<Item>().SetItemData(PlayerItemsController.Inventory[i], _Icons, _ItemIcons, _ChosenItemFieldNumber);
                _CreatedItems.Add(a);
            }
        }
    }
    private void SortItems()
    {
        int type = PlayerItemsController.GetItemTypeByCellNumber(_ChosenItemFieldNumber);
        List<ItemData> temp = new List<ItemData>();
        foreach (var item in PlayerItemsController.Inventory)
        {
            if (item.ItemType == type)
            {
                temp.Add(item);
            }
        }
    }

}
