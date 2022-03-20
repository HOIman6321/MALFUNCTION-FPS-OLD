using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform player;
    public Transform top;

    public float viewDistance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= viewDistance)
        {
            FaceTarget();
            //Aim();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // void Aim()
    // {
    //     Vector3 topDirection = (player.transform.position - top.transform.position).normalized;
    //     Quaternion topLookRotation = Quaternion.LookRotation(new Vector3(0, topDirection.x, topDirection.z));
    //     top.transform.rotation = Quaternion.Slerp(top.transform.rotation, topLookRotation, Time.deltaTime * 5f);
    // }

    void OnDrawGizmosSelected()
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, viewDistance);
    }
}
