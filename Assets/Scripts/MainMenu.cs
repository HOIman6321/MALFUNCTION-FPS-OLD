using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject playMenu;
	
	public void PlayGame ()
	{
		// SceneManager.LoadScene("LEVEL1");
		// Time.timeScale = 1f;
		playMenu.SetActive(true);
		gameObject.SetActive(false);
	}
	public void QuitGame ()
	{
	  	Application.Quit();
	}
}
