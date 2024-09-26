using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private Transform player;
    [SerializeField] private Transform interactionTransform;
    private bool isFocus;
    private bool hasInteracted;

    public Transform InteractionTransform { get => interactionTransform; set => interactionTransform = value; }
    public float Radius { get => radius; set => radius = value; }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    private void Update()
    {
        CheckStatusFocused();
    }
    private void CheckStatusFocused()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, InteractionTransform.position);  
            if (distance <= Radius)
            {
                Interact();
                hasInteracted = true;
            }
            Debug.Log(distance);
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
}
