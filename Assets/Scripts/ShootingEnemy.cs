using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{

	public float shootingInterval = 7f;
	public GameObject bulletPrefab;
	public float shootingDistance = 3f;

    public bool isDrone = false;
    //public Vector3 shootingOffset = new Vector3(1f, 0f, 0f);
	

	private Transform player;
	private float shootingTimer;



    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = Random.Range(2, shootingInterval);
        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrone)
        {
            transform.LookAt(player);
        }
        shootingTimer -= Time.deltaTime;
        if (shootingTimer  <= 0 && Vector3.Distance(transform.position, player.transform.position) <= shootingDistance)
        {
        	shootingTimer = shootingInterval;

        	//GameObject bulletObject = Instantiate(bulletPrefab);
            //bulletObject.transform.position = transform.position; //+ shootingOffset;
            //bulletObject.transform.forward = (player.transform.position - transform.position).normalized;
            GameObject bulletObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.force = transform.forward;
            
        }
    }
}
