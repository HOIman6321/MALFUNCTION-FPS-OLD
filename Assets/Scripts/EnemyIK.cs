using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIK : MonoBehaviour
{
	public Vector3 velocity;
    public ProceduralLegPlacement[] legs;
    private int index;
    //public bool dynamicGait = false;
    public float timeBetweenSteps = 0.25f;
    //[Tooltip ("Used if dynamicGait is true to calculate timeBetweenSteps")] public float maxTargetDistance = 1f;
    public float lastStep = 0;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        velocity = enemy.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastStep + (timeBetweenSteps / legs.Length) && legs != null) {
            if (legs[index] == null) return;

            Vector3 legPoint = (legs[index].restingPosition + velocity);
            Vector3 legDirection = legPoint - transform.position;
            Vector3 rotationalPoint = ((Quaternion.Euler (0, 0, 0) * legDirection) + transform.position) - legPoint;
            Debug.DrawRay (legPoint, rotationalPoint, Color.black, 1f);
            Vector3 rVelocity = rotationalPoint + velocity;

            legs[index].stepDuration = Mathf.Min (0.5f, timeBetweenSteps / 2f);
            legs[index].worldVelocity = rVelocity;
            legs[index].Step ();
            lastStep = Time.time;
            index = (index + 1) % legs.Length;
        }
    }
}
