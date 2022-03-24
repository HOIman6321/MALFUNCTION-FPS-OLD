using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public float lookRadius = 10f;

    public Vector3 velocity;

    public Animator animator;
    
    public bool isDroneEnemy = false;
    public int droneStoppingDistance = 1;

    public float speed = 20f;


	Transform target;
	NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
    	target = PlayerManager.instance.player.transform;
        if(!isDroneEnemy)
        {
        	agent = GetComponent<NavMeshAgent>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

    	if(distance <= lookRadius)
    	{
            if(isDroneEnemy)
            {
                if(distance >= droneStoppingDistance)
                {
                    Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y - 2f, target.transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed / 20f);
                }
            }
            else
            {
                agent.SetDestination(target.position);
            }
    	}
        if(!isDroneEnemy)
        {
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                agent.velocity = Vector3.zero;
            }
        }
        else
        {
            FaceTarget();
        }

        if(!isDroneEnemy)
        {
            if(animator != null && agent.velocity != Vector3.zero)
            {
                animator.SetBool("IsInMotion", true);
            }
            if(animator != null && agent.velocity == Vector3.zero)
            {
                animator.SetBool("IsInMotion", false);
            }
        }
        else
        {
            if(animator != null)
            {
                animator.SetBool("IsInMotion", true);
            }
            if(animator != null)
            {
                animator.SetBool("IsInMotion", false);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
