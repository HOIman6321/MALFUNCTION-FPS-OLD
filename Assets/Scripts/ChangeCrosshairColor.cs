using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrosshairColor : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    public Image[] crosshairImages; // Define an array of our crosshair images in order to change their colors
    public float regularFOV = 60f; // Standard camera field of view
    public float aimingFOV = 50f; // Aiming field of view. Creates zoom in effect
    public float currentFOV = 60f; // Set the current FOV to 60 in order to prevent field of view change at game start
    public float aimingSpeed = 10f; // Speed at which we change the field of view

    private void Update() // Called once per frame
    {
        if (crosshair.GetComponent<CrosshairScript>().Aiming) // If the "Aiming" boolean of the "CrosshiarScript" is equal to true
        {
            currentFOV = Mathf.Lerp(currentFOV, aimingFOV, Time.deltaTime * aimingSpeed); // Lerp the "CurrentFOV" float to "aimingFOV" float
        }
        else // If the "Aiming" boolean of the "CrosshiarScript" is equal to false
        {
            currentFOV = Mathf.Lerp(currentFOV, regularFOV, Time.deltaTime * aimingSpeed); // Lerp the "CurrentFOV" float to "regularFOV" float
        }

        this.gameObject.GetComponentInParent<Camera>().fieldOfView = currentFOV; // Set the field of view of our FPS camera to the currentFOV float

        RaycastHit hit; // Define our Raycast
        if (Physics.Raycast(transform.position, transform.forward, out hit, 200f)) // Set our Raycast from our FPS camera's position to 200 units forward
        {
            if (hit.transform.gameObject.CompareTag("Enemy")) // If our Raycast is hitting an object that is tagged as "Enemy"
            {
                foreach(Image crosshairImage in crosshairImages) // For each one of our crosshair images
                {
                    crosshairImage.color = new Color(1f, 141/255f, 0f, 1f); // Set the color of our crosshair images to red
                }
            }
            else // If our Raycast is not hitting an object that is tagged as "Enemy"
            {
                foreach (Image crosshairImage in crosshairImages) // For each one of our crosshair images
                {
                    crosshairImage.color = new Color(0f, 0f, 0f, 1f); // Set the color of our crosshair images to a light gray
                }
            }
        }
        else
        {
            foreach (Image crosshairImage in crosshairImages) // For each one of our crosshair images
            {
                crosshairImage.color = new Color(0f, 0f, 0f, 1f); // Set the color of our crosshair images to a light gray
            }
        }
    }
}
