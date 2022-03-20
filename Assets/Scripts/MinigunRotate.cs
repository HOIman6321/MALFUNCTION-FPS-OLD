using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunRotate : MonoBehaviour
{
    public float maxSpeed;
    float speed;
    public float acceleration;
    public float deceleration;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.timeScale > 0f && speed < maxSpeed)
        {
            speed = speed + acceleration * Time.deltaTime;
        }
        else
        {
            if(speed > deceleration * Time.deltaTime)
            {
                speed = speed - deceleration * Time.deltaTime;
            }
            else
            {
                speed = 0f;
            }
        }
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
