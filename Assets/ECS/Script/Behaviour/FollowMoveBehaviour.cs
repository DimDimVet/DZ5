using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMoveBehaviour : MonoBehaviour, IBehaviour
{
    public HealtComponent HealtComponent;
    [SerializeField] private float stopDistance = 1;
    [SerializeField] private float activDistance = 5;
    //���������
    private NavMeshAgent agent;
    private Vector3 pointDefault;
    private float controlDistance;
    private float currentVelocity;

    private Animator animator;
    private void Start()
    {
        HealtComponent = FindObjectOfType<HealtComponent>();//������ ������ � ������ �����������
        //Nav
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        pointDefault = this.gameObject.transform.position;
    }
    public void Behaver()
    {
        agent.stoppingDistance = stopDistance;
        currentVelocity=Mathf.Abs(agent.velocity.magnitude);

        if (controlDistance <= activDistance)
        {
            agent.destination = HealtComponent.transform.position;//Player ������� � ����

        }
        else
        {
            agent.destination = pointDefault;
        }

        if (currentVelocity > 0.1f)
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
        if (HealtComponent == null)
        {
            return 0;
        }

        //return 1 / (this.gameObject.transform.position - HealtComponent.transform.position).magnitude;//��� ����� �������� ����
        controlDistance = (this.gameObject.transform.position - HealtComponent.transform.position).magnitude;
        return controlDistance;
    }

}
