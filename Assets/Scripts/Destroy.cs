using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	public float lifeDuration = 15f;

	private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // check if bullet die
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
        	Destroy (gameObject);
        }
    }
}
