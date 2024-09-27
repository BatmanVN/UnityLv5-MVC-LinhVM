using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string nameItem;
    [SerializeField] private Sprite icon = null;
    private bool isDefaultItem = false;

    public bool IsDefaultItem { get => isDefaultItem; set => isDefaultItem = value; }
    public Sprite Icon { get => icon; set => icon = value; }

    public virtual void Use()
    {
        Debug.Log("Using " + nameItem);
    }
}
