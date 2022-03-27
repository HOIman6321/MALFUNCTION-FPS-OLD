using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 force;
    public float speed = 1000f;
    public int damage = 10;
    public ParticleSystem muzzleFlash;

    public GameObject soundSource;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Player>() != null)
        {
            Player player = collision.collider.GetComponent<Player>();
            player.health -= damage;
            Destroy(this.gameObject);
        } else if(collision.collider.GetComponent<Target>() != null)
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
        muzzleFlash.Play();
        muzzleFlash.transform.parent = null;
        GameObject soundSourceObject = Instantiate(soundSource, transform.position, transform.rotation);
    	transform.GetComponent<Rigidbody>().AddForce(force * speed);
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}