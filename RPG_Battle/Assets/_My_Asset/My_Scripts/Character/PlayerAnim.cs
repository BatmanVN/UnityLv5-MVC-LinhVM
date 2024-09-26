using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnim : MonoBehaviour
{
    private const string speedParaname = "speed";
    [SerializeField] private Animator playerAnim;
    [SerializeField] private NavMeshAgent playerNav;
    [SerializeField] private float animSmoothTime;
    private void OnValidate()
    {
        playerAnim = GetComponent<Animator>();
        playerNav = GetComponent<NavMeshAgent>();
    }

    private void CalculatorSpeed()
    {
        float speedPercent = playerNav.velocity.magnitude / playerNav.speed;
        playerAnim.SetFloat(speedParaname, speedPercent, animSmoothTime, Time.deltaTime);
    }
    private void Update()
    {
        CalculatorSpeed();
    }
}
