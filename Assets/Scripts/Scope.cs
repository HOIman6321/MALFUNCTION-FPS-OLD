using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    
	public Animator animator;

	//public GameObject scopeOverlay;
	public GameObject weaponCamera;
	public Camera mainCamera;

	public float scopedFOV = 15f;
	private float normalFOV;

	public bool isScoped = false;

	void Start ()
	{
		normalFOV = mainCamera.fieldOfView;
	}

	void Update ()
	{
		// if (Input.GetButtonDown("Fire2"))
		// {
		// 	isScoped = !isScoped;
		// 	animator.SetBool("IsScoped", isScoped);

		// 	if (isScoped)
		// 	{
		// 		StartCoroutine(OnScoped());
		// 	} else if (Input.GetKeyDown(KeyCode.Escape))
		// 	{
		// 		OnUnscoped();
		// 	} else
		// 	{
		// 		OnUnscoped();
		// 	}

		// }
	}

	void OnUnscoped ()
	{
		//scopeOverlay.SetActive(false);
		weaponCamera.SetActive(true);

		mainCamera.fieldOfView = normalFOV;
	}

	IEnumerator OnScoped ()
	{
		yield return new WaitForSeconds(.15f);

		//scopeOverlay.SetActive(true);
		weaponCamera.SetActive(false);

		mainCamera.fieldOfView = scopedFOV;

	}

}
