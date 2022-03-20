using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOld : MonoBehaviour
{
   public float speed = 8f;
   public float lifeDuration = 5f;
   private Rigidbody rb;

   public int damage = 10;

   public LayerMask groundMask;

   private float lifeTimer;

   //bool isHit;


   // Start is called before the first frame update
   void Start()
   {
       lifeTimer = lifeDuration;
       
   }

   // Update is called once per frame
   void Update()
   {
   	
   	//isHit = Physics.CheckSphere(transform.position, 0.1f, groundMask);
       //make bullet move
       transform.position += transform.forward * speed * Time.deltaTime;
       // check if bullet die
       lifeTimer -= Time.deltaTime;
       if (lifeTimer <= 0f) //|| isHit)
       {
       	Destroy (gameObject);
       }
   }
   private void OnCollisionEnter(Collision collision)
   {
      	Destroy (gameObject);
   }	
}


