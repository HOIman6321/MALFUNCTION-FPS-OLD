using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunRotate : MonoBehaviour
{
    public float Speed;
    private float _currentTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
        	// transform.Rotate(0, 1200 * Time.deltaTime, 0);
            _currentTime += Time.deltaTime;
            transform.Rotate(0, Speed * _currentTime, 0);
        }
    }
}
