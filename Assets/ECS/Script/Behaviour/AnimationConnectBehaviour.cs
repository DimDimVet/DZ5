using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationConnectBehaviour : MonoBehaviour, IBehaviour
{
    //навигация
    private NavMeshAgent agent;
    private Animator animator;
    private float currentVelocity;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    public void Behaver()
    {
        if (currentVelocity>0.1)
        {
            animator.SetFloat("SpeedEnemy", 1);
        }
        else
        {
            animator.SetFloat("SpeedEnemy", 0);
        }
        
    }

    public float Evaluete()
    {
        currentVelocity = Mathf.Abs(agent.velocity.magnitude);
        return currentVelocity;
    }

}
