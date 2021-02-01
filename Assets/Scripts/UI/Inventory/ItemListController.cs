using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListController : MonoBehaviour
{
    public GameObject ScrollView;
    private GameObject _TempScroll;
    public Button CloseItemsListButton;

    private void Start()
    {
        CloseItemsListButton.onClick.AddListener(DestroyItemsList);
        PlayerItemsController.ItemIsEquipped += ReloadItemsList;
    }
    public void CreateItemsListScrollview(int chosenItemFieldNumber)
    {
        _TempScroll = Instantiate<GameObject>(ScrollView, this.transform);
        _TempScroll.GetComponent<ItemListFiller>().Fill(chosenItemFieldNumber);
    }
    public void DestroyItemsList()
    {
        Destroy(_TempScroll);
    }
    public void ReloadItemsList(int chosenItemFieldNumber)
    {
        DestroyItemsList();
        CreateItemsListScrollview(chosenItemFieldNumber);
    }
}
