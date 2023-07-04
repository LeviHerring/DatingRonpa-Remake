using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1f;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;


    [Header("Keybinds")]
    public KeyCode jump = KeyCode.Space; 


    [Header("Ground Check")]
    public float height;
    public LayerMask whatIsGround;
   [SerializeField] bool grounded; 
    
    Rigidbody rb;

    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;


   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
        
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.2f, whatIsGround); 

        MyInput();
        SpeedControl(); 

        //handle Drag

        if(grounded)
        {
            rb.drag = groundDrag; 
        }
        else
        {
            rb.drag = 0; 
        }


       
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 

        //when to jump
        if(Input.GetKey(jump) && readyToJump && grounded)
        {
            readyToJump = false; 
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown); 
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        if(grounded)
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        else if(!grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVelocity.magnitude > speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * speed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z); 
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); 

    }

    private void ResetJump()
    {
        readyToJump = true; 
    }
}
