﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject playMenu;
	
	public void PlayGame ()
	{
		playMenu.SetActive(true);
		gameObject.SetActive(false);
	}
	public void QuitGame ()
	{
	  	Application.Quit();
	}
}
