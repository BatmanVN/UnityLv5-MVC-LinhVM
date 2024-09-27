using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    [SerializeField] private int spaceInventory;
    #region Singleton
    public static Inventory _instance;

    //public static Inventory Instance
    //{
    //    get => _instance;
    //    set
    //    {
    //        if (_instance != null)
    //            return;
    //    }
    //}


    private void Awake()
    {
        if (_instance != null)
        {
            Debug.Log("Warning has more 1 Inventory");
            return;
        }
        _instance = this;
    }
    #endregion
    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;
    public bool AddItem(Item item)
    {
        if (!item.IsDefaultItem)
        {
            if (items.Count >= spaceInventory)
            {
                Debug.Log("FULL INVENTORY");
                return false;
            }
            items.Add(item);
            if(onItemChangeCallback != null)
                onItemChangeCallback.Invoke();
        }
        return true;
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null)
            onItemChangeCallback.Invoke();
    }
}
