using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBehaviour : MonoBehaviour, IBehaviour
{
    //навигация
    public HealtComponent HealtComponent;
    [SerializeField] private float activDistance = 5f;
    //private NavMeshAgent agent;
    //private Animator animator;
    //private float currentVelocity;
    private float controlDistance1;
    //private Vector3 pointDefault;
    private void Start()
    {
        HealtComponent = FindObjectOfType<HealtComponent>();//найдем объект с данным компонентом
        //Nav
        //agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        //pointDefault = this.gameObject.transform.position;
    }
    public void Behaver()
    {
        if (controlDistance1 <= activDistance)
        {
            Debug.Log("pusk");
            //agent.destination = HealtComponent.transform.position;//Player запишем в цель

        }
        else
        {
            Debug.Log("Stoppusk");
            //agent.destination = pointDefault;
        }

    }

    public float Evaluete()
    {
        if (HealtComponent == null)
        {
            return 0;
        }
        //currentVelocity = Mathf.Abs(agent.velocity.magnitude);
        controlDistance1 = (this.gameObject.transform.position - HealtComponent.transform.position).magnitude;
        return controlDistance1;
    }
}
