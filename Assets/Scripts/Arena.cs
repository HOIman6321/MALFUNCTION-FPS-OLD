using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
	public float time = 1f;

	bool isSlow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
        	if (!isSlow)
        	{
        		time = time / 4;
        		isSlow = true;
        	} else
        	{
        		time = time * 4;
        		isSlow = false;
        	}
        	Time.timeScale = time;
        }
    }
}
