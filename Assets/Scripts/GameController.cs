using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Player player;
    public Transform playerTransform;
    public GameObject boss;

	//public Text healthText;
    public Slider healthSlider;
    public Text bossHealthText;
    
    public LayerMask playerMask;

    public float bossTextDis = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if(bossHealthText != null)
        {
            bossHealthText.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = "HEALTH: " + player.health;
        healthSlider.value = player.health;
        if (boss != null && bossHealthText != null)
        {
            bossHealthText.text = "BOSS HEALTH: " + boss.GetComponent<Target>().health;
            if (boss.GetComponent<Target>().health < 0)
            {
                boss.GetComponent<Target>().health = 0;
            }
            if (Physics.CheckSphere(boss.transform.position, bossTextDis, playerMask))
            {
                bossHealthText.enabled = true;
            }
            else
            {
                bossHealthText.enabled = false;
            }
        }

        if(playerTransform.position.y < -50)
        {
            player.Die();
        }
        if(player.health < 0)
        {
            player.Die();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (boss != null && bossHealthText != null)
        {
            Gizmos.color = Color.red;
    	    Gizmos.DrawWireSphere(boss.transform.position, bossTextDis);
        }
    }
}
