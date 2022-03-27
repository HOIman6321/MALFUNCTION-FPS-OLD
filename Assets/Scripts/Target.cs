using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem explosion;
    public Transform ragdoll;

    public GameObject passDoor;
    public bool boss = false;
    bool hasDied = false;

    public void TakeDamage (float amount)
    {
    	health -= amount;
    	if (health <= 0f)
    	{
            if(!hasDied)
            {
                hasDied = true;
                StartCoroutine(Die());
            }
    	}
    }

    IEnumerator Die ()
    {
        explosion.Play();
        if (boss)
        {
            Destroy(passDoor);
        }
        yield return new WaitForSeconds(0.2f);
        if(ragdoll != null)
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
        }
    	Destroy(gameObject);
    }
}
