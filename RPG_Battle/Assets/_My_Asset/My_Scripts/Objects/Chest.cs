using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Item item;
    [SerializeField] private GameObject[] statusBox;
    [SerializeField] private GameObject dropItem;
    public override void Interact()
    {
        base.Interact();
        StartCoroutine(Unchest());
    }
    private IEnumerator Unchest()
    {
        yield return new WaitForEndOfFrame();
        statusBox[0].SetActive(false);
        statusBox[1].SetActive(true);
        bool wasPickUp = Inventory._instance.AddItem(item);
        if (wasPickUp)
        {
            Destroy(statusBox[0]);
        }
        //Instantiate(dropItem, statusBox[1].transform.position, Quaternion.identity);
        Debug.Log("Unbox: " + item.name);
    }
}
