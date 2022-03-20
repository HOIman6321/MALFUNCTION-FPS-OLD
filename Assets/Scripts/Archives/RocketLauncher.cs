using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject explosion;
    public GameObject grenade;

    public bool flashOn = false;

    public float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
        	nextTimeToFire = Time.time + 1f/fireRate;
        	Shoot();
        	flashOn = true;
        }

    }

    void Shoot ()
    {
    	muzzleFlash.Play();
   //  	RaycastHit hit;
   //  	if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
   //  	{
    		

   //          Target target = hit.transform.GetComponent<Target>();
   //          if (target != null)
   //          {
   //              target.TakeDamage(damage);
   //          }

   //          if (hit.rigidbody != null)
   //          {
   //          	GameObject explosion = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
   //          	Destroy(explosion, 5f);
   //          }

			// GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
   //          Destroy(impactGO, 5f);

   //  	}
    	//GameObject grenadeObject
    }
}
