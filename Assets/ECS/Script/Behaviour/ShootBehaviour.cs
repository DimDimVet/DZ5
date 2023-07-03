using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBehaviour : MonoBehaviour, IBehaviour
{
    //навигация
    public HealtComponent HealtComponent;
    [SerializeField] private float activDistance = 5f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform outBullet;
    public float ShootDelay;
    private float shootTime = float.MinValue;

    private NavMeshAgent agent;
    //private Animator animator;
    private float currentVelocity;
    private float controlDistance;
    //private Vector3 pointDefault;
    private void Start()
    {
        HealtComponent = FindObjectOfType<HealtComponent>();//найдем объект с данным компонентом
        //Nav
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        //pointDefault = this.gameObject.transform.position;
    }
    public void Behaver()
    {
        if (controlDistance <= activDistance)
        {
            if (Time.time < shootTime + ShootDelay)
            {
                return;
            }
            else
            {
                shootTime = Time.time;
            }

            Instantiate(bullet, outBullet.position, outBullet.rotation);
            Debug.Log("pusk");
        }
        else
        {
            Debug.Log("Stoppusk");

        }

    }

    public float Evaluete()
    {
        if (HealtComponent == null)
        {
            return 0;
        }

        currentVelocity = Mathf.Abs(agent.velocity.magnitude);
        controlDistance = (this.gameObject.transform.position - HealtComponent.transform.position).magnitude;

        if (currentVelocity < 0.1f && (controlDistance <= activDistance))
        {
            return activDistance;
        }
        else
        {
            return 0;
        }

    }
}
