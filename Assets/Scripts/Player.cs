using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int health = 100;

	public GameObject CrosshairUi;
	public GameObject DieMenuUi;
    public GameObject nextMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
    	if (health <= 0)
    	{
    		Die();
    	}
    }

    void OnControllerColliderHit (ControllerColliderHit hit)
    {
    	if (hit.collider.GetComponent<Bullet>() != null)
        {
    		Bullet bullet = hit.collider.GetComponent<Bullet>();
        	health -= bullet.damage;
        }
    }

    public void Die()
    {
    	CrosshairUi.SetActive(false);
    	DieMenuUi.SetActive(true);
    	Time.timeScale = 0f;
    	Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Win()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        nextMenuUi.SetActive(true);
        CrosshairUi.SetActive(false);
    }
}
