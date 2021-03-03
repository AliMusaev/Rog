using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPresentationController : MonoBehaviour
{

    public GameObject[] ItemFields;
    private Sprite[] _ItemSprites;
    private Sprite[] _DefaultImages;  // Set default sprite when player takes off item from slot
    void Start()
    {

        OldPlayerItemsController.ItemIsEquipped += DrawEquippedItemInItemField;
        _ItemSprites = Resources.LoadAll<Sprite>("Sprites/ItemsSprites");
        _DefaultImages = new Sprite[ItemFields.Length];
        for (int i = 0; i < ItemFields.Length; i++)
        {
            _DefaultImages[i] = ItemFields[i].GetComponentInChildren<Button>().GetComponent<Image>().sprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Draw equipped item icon in appropriate item field
    void DrawEquippedItemInItemField(int value)
    {
        ItemFields[value].GetComponentInChildren<Button>().GetComponent<Image>().sprite = _ItemSprites[OldPlayerItemsController.EquippedItems[value].IconId];
    }
}
