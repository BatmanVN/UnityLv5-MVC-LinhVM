using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent playerNav;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private void OnValidate() => playerNav = GetComponent<NavMeshAgent>();
    
    public void MoveToPoint(Vector3 point)
    {
        playerNav.SetDestination(point);
    }
    private void Update()
    {
        UpdateDestination();
    }
    private void UpdateDestination()
    {
        if (target != null)
        {
            playerNav.SetDestination(target.position);
            FaceTarget();
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
    }

    public void FollowTargert(Interactable newTarget)
    {
        target = newTarget.InteractionTransform;
        playerNav.stoppingDistance = newTarget.Radius * .8f;
        playerNav.updateRotation = false;
    }
    public void StopFollowTarget()
    {
        playerNav.stoppingDistance = 0f;
        playerNav.updateRotation = true;
        target = null;
    }
    private void Start()
    {
        playerNav.speed = speed;
    }
}
