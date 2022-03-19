// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyBullet : MonoBehaviour
// {
//     public float speed = 8f;
//     public float lifeDuration = 5f;
//     private Rigidbody rb;

//     public int damage = 10;

//     private float lifeTimer;

//     private bool shotByPlayer;
//     public bool ShotByPlayer { get { return shotByPlayer; } set { shotByPlayer = value; } }


//     // Start is called before the first frame update
//     void Start()
//     {
//         lifeTimer = lifeDuration;
//         //GetComponent<Rigidbody>().AddForce(0, 0, 10000000000);
//         rb = GetComponent<Rigidbody>();
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         //make bullet move
//         //transform.position += transform.forward * speed * Time.deltaTime;
//         rb.AddForce(transform.forward * speed * Time.deltaTime);
//         // check if bullet die
//         lifeTimer -= Time.deltaTime;
//         if (lifeTimer <= 0f)
//         {
//          Destroy (gameObject);
//         }
//     }
// }


