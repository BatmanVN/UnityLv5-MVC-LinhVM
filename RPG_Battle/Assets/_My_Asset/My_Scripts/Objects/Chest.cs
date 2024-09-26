using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private GameObject[] statusBox;
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
    }
}
