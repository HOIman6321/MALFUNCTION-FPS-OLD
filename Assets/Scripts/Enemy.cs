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

    public float speed = 20;


	Transform target;
	NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
    	target = PlayerManager.instance.player.transform;
    	agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target, Vector3.up);

        float distance = Vector3.Distance(target.position, transform.position);

    	if (distance <= lookRadius)
    	{
    		agent.SetDestination(target.position);

            if (isDroneEnemy)
            {
                // if (target.transform.position.z != transform.position.z)
                // {
                //     transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                // }
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
            }
    	}

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            agent.velocity = Vector3.zero;
        }

        if (animator != null && agent.velocity != Vector3.zero)
        {
            animator.SetBool("IsInMotion", true);
        }
        if (animator != null && agent.velocity == Vector3.zero)
        {
           animator.SetBool("IsInMotion", false);
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
