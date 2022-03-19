using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMenu : MonoBehaviour
{
	public GameObject CrosshairUi;
	public GameObject NextMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
    	CrosshairUi.SetActive(true);
    	Time.timeScale = 1f;
    	Cursor.lockState = CursorLockMode.Locked;
        NextMenuUi.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
