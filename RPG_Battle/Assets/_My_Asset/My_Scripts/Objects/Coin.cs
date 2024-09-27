using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    [SerializeField] private Item item;
    public override void Interact()
    {
        base.Interact();
        StartCoroutine(Unchest());
    }
    private IEnumerator Unchest()
    {
        yield return new WaitForEndOfFrame();
        bool wasPickUp = Inventory._instance.AddItem(item);
        Debug.Log("Pick Up: " + item.name);
        if (wasPickUp)
        {
            Destroy(gameObject);
        }
    }
}
