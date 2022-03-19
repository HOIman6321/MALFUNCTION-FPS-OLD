using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	GameObject button;
	bool isToggled = false;
	public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isToggled)
        {
        	button.transform.localPosition = Vector3.MoveTowards(button.transform.localPosition, new Vector3(button.transform.localPosition.x * -1, button.transform.localPosition.y, button.transform.localPosition.z), Time.deltaTime * speed);
        	isToggled = false;
        }
    }

    public void Toggle()
    {
    	isToggled = true;
    }
}
