using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem explosion;

    public GameObject passDoor;
    public bool boss = false;
    public void TakeDamage (float amount)
    {
    	health -= amount;
    	if (health <= 0f)
    	{
            StartCoroutine(Die());
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
    	Destroy(gameObject);
    }
}
