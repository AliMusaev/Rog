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
        if (OldPlayerItemsController.EquippedItems[_ChosenItemFieldNumber] != null)
        {
            var b = Instantiate<GameObject>(ItemFieldPrefab, ContentParent.transform);
            b.GetComponent<OldItem>().SetEquippedItemData(OldPlayerItemsController.EquippedItems[_ChosenItemFieldNumber], _Icons, _ItemIcons, _ChosenItemFieldNumber);
        }
    }
    private void DisplayNotEquippedItems()
    {
        int type = OldPlayerItemsController.GetItemTypeByCellNumber(_ChosenItemFieldNumber);
        for (int i = 0; i < OldPlayerItemsController.Inventory.Count; i++)
        {
            if (OldPlayerItemsController.Inventory[i].ItemType == type)
            {
                var a = Instantiate<GameObject>(ItemFieldPrefab, ContentParent.transform);
                a.GetComponent<OldItem>().SetItemData(OldPlayerItemsController.Inventory[i], _Icons, _ItemIcons, _ChosenItemFieldNumber);
                _CreatedItems.Add(a);
            }
        }
    }
    private void SortItems()
    {
        int type = OldPlayerItemsController.GetItemTypeByCellNumber(_ChosenItemFieldNumber);
        List<ItemData> temp = new List<ItemData>();
        foreach (var item in OldPlayerItemsController.Inventory)
        {
            if (item.ItemType == type)
            {
                temp.Add(item);
            }
        }
    }

}
