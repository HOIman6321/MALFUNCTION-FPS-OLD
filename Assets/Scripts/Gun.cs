using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Recoil recoil;
    public float damage = 10f;
    public float range = 1000;
    public float fireRate = 15f;
    public float impactForce = 200f;

    public Transform[] origins;
    public ParticleSystem muzzleFlash;
    //public GameObject impactEffect;
    //public GameObject explosion;
    public GameObject grenade;
    public GameObject bulletPrefab;


    public bool flashOn = false;

    public float nextTimeToFire = 0f;

    public float grenadeThrowForce = 250f;

    public Rigidbody playerRb;

    public float thrust;

    // float curFov;

    void Start()
    {
        // curFov = origins.fieldOfView;
        // origins = transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
        	nextTimeToFire = Time.time + 1f/fireRate;
        	Shoot();
        	flashOn = true;
        }

    }


    void Shoot()
    {
    	muzzleFlash.Play();
        recoil.Fire();

    	// RaycastHit hit;
        foreach (Transform _transform in origins)
        {
            GameObject bulletObject = Instantiate(bulletPrefab, _transform.position, _transform.rotation);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.force = _transform.forward;
        }

    	// if (Physics.Raycast(origins.transform.position, origins.transform.forward, out hit, range))
    	// {
        //     Target target = hit.transform.GetComponent<Target>();
        //     if (target != null)
        //     {
        //         target.TakeDamage(damage);
        //     }

    	// }

        if (playerRb != null)
        {
            playerRb.AddForce(-origins[0].transform.forward * thrust * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
}
