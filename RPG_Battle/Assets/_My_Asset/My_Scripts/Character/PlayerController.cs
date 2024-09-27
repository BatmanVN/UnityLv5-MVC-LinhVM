using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMove))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Interactable forcus;
    [SerializeField] private LayerMask moventMask;
    [SerializeField] private PlayerMove move;
    [SerializeField] private Camera cam;
    //private bool isMoving;

    //public bool IsMoving
    //{
    //    get => isMoving;
    //    set
    //    {
    //        if (isMoving == value) return;
    //        isMoving = value;
    //    }
    //} 
        

    private void Start()
    {
        cam = Camera.main;
        move = GetComponent<PlayerMove>();
    }
    private void Move()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, moventMask))
            {
                    move.MoveToPoint(hit.point);
                    RemoveForuc();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void RemoveForuc()
    {
        if (forcus != null)
            forcus.OnDeFocused();
        forcus = null;
        move.StopFollowTarget();
    }

    private void SetFocus(Interactable newForcus)
    {
        if (newForcus != forcus)
        {
            if(forcus != null)
                forcus.OnDeFocused();
            forcus = newForcus;
            move.FollowTargert(newForcus);
        }
        newForcus.OnFocused(transform);
    }

    private void Update()
    {
        Move();
    }
}
