using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemsParent;
    [SerializeField] private ItemSlot[] slots;
    [SerializeField] private Inventory inventory;
    private void Start()
    {
        inventory = Inventory._instance;
        inventory.onItemChangeCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<ItemSlot>();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
                slots[i].ClearSlot();
        }
    }
}
