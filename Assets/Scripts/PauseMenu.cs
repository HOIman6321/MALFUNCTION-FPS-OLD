using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool hideatstart = true;

    public GameObject PausemenuUi;
    public GameObject CrosshairUi;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        	if (GameIsPaused)
        	{
        		Resume();

        	} else
        	{
        		Pause();
        	}
        }

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("LEVEL 1") && (hideatstart == true))
        {
                Resume();
                hideatstart = false;
        }
    }

    public void Resume()
    {
    	CrosshairUi.SetActive(true);
    	PausemenuUi.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    	Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
    	CrosshairUi.SetActive(false);
        PausemenuUi.SetActive(true);
	    Time.timeScale = 0f;
   	    GameIsPaused = true;
	    Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
    	Application.Quit();
    }
}
