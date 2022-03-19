using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;

	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;
    public float lavaJumpHeight = 10f;

    public int lavaDamage = 1;

	public Transform groundCheck;
    public GameObject nextMenuUi;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
    public LayerMask lavaMask;
    public LayerMask doorMask;

    private float Xorigin;
    private float Zorigin;
    private float Height;

	Vector3 velocity;
	bool isGrounded;
    bool isFellInLava;
    bool isAtDoor;

    private Player player = null;


    void Awake()
    {
        Xorigin = transform.position.x;
        Zorigin = transform.position.z;
        Height = transform.position.y;
        player = transform.GetComponent<Player>();
        Application.targetFrameRate = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
        // check and set bools
    	isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isFellInLava = Physics.CheckSphere(groundCheck.position, groundDistance, lavaMask);
        isAtDoor = Physics.CheckSphere(groundCheck.position, groundDistance, doorMask);


    	if(isGrounded && velocity.y < 0)
    	{
    		velocity.y = -2f;
    	}

        if ( player != null && isFellInLava)
        {
            //transform.GetComponent<Rigidbody>().AddForce(0, 3000, 0);
            player.health -= lavaDamage;
            velocity.y = Mathf.Sqrt(lavaJumpHeight * -2f * gravity);
        }

        if (isAtDoor)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            nextMenuUi.SetActive(true);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
        	velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if ( player != null && player.health < 0)
        {
            player.health = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
     {
        if (collision.gameObject.layer == 12)
        {
        }
     }

    

}