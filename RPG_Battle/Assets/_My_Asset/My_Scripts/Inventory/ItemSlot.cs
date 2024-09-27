using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Button removeButton;
    [SerializeField] private Image icon;
    [SerializeField] private Image remove;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.Icon;
        icon.enabled = true;
        remove.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        remove.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory._instance.RemoveItem(item);
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
