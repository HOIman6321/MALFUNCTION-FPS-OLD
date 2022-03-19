//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Bullet : MonoBehaviour
//{
//    public float speed = 8f;
//    public float lifeDuration = 5f;
//    private Rigidbody rb;
//
//    public int damage = 10;
//
//    public LayerMask groundMask;
//
//    private float lifeTimer;
//
//    //bool isHit;
//
//
//    // Start is called before the first frame update
//    void Start()
//    {
//        lifeTimer = lifeDuration;
//        
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//    	
//    	//isHit = Physics.CheckSphere(transform.position, 0.1f, groundMask);
//        //make bullet move
//        transform.position += transform.forward * speed * Time.deltaTime;
//        // check if bullet die
//        lifeTimer -= Time.deltaTime;
//        if (lifeTimer <= 0f) //|| isHit)
//        {
//        	Destroy (gameObject);
//        }
//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//       	Destroy (gameObject);
//    }	
//}
//
//
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 force;
    public float speed = 1000f;
    public int damage = 10;

    public GameObject soundSource;

    //public GameObject player;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            Player player = collision.collider.GetComponent<Player>();
            player.health -= damage;
            Destroy(this.gameObject);
        } else if (collision.collider.GetComponent<Target>() != null)
        {
            Target target = collision.collider.GetComponent<Target>();
            target.TakeDamage(damage);
            Destroy(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Start()
    {
        GameObject soundSourceObject = Instantiate(soundSource, transform.position, transform.rotation);
    	//player = GameObject.Find("Player");
    	transform.GetComponent<Rigidbody>().AddForce(force * speed);//.normalized);
    	// transform.rotation = player.transform.rotation;
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}