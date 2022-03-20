using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrosshairColor : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    public Image[] crosshairImages;
    public float regularFOV = 60f;
    public float aimingFOV = 50f;
    public float currentFOV = 60f;
    public float aimingSpeed = 10f;

    private void Update()
    {
        if(crosshair.GetComponent<CrosshairScript>().Aiming)
        {
            currentFOV = Mathf.Lerp(currentFOV, aimingFOV, Time.deltaTime * aimingSpeed);
        }
        else
        {
            currentFOV = Mathf.Lerp(currentFOV, regularFOV, Time.deltaTime * aimingSpeed);
        }

        this.gameObject.GetComponentInParent<Camera>().fieldOfView = currentFOV;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 200f))
        {
            if(hit.transform.gameObject.CompareTag("Enemy"))
            {
                foreach(Image crosshairImage in crosshairImages)
                {
                    crosshairImage.color = new Color(1f, 141/255f, 0f, 1f);
                }
            }
            else
            {
                foreach(Image crosshairImage in crosshairImages)
                {
                    crosshairImage.color = new Color(0f, 0f, 0f, 1f);
                }
            }
        }
        else
        {
            foreach(Image crosshairImage in crosshairImages)
            {
                crosshairImage.color = new Color(0f, 0f, 0f, 1f);
            }
        }
    }
}
