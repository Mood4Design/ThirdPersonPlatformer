using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    //Movement Paramaters
    [SerializeField] float movementSpeed =5f;
    [SerializeField] float jumpHigh =5f;
    [SerializeField] int degree = 360;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask Ground;
    [SerializeField] LayerMask Trampoline;
    
    //Inputs
    private float h;
    private float v;
    private bool jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Assign the rigidbody
    }

    void Update()
    {   
        //Get movement input
        h = Input.GetAxis(InputAxes.Horizontal);
        v = Input.GetAxis(InputAxes.Vertical);
        
        jump = jump || Input.GetButtonDown(InputAxes.Jump); //"jump ||" to counter non-synchronisation between Update and FixedUpdate

        //Make jump if player is onGround
        if (jump )
        {   
            if(IsGrounded()){
                rb.AddForce(Vector3.up * jumpHigh, ForceMode.Impulse);
                jump =false;
            }

            if(IsTrampolined()){
                rb.AddForce(Vector3.up * jumpHigh, ForceMode.Impulse);
                jump =false;
            }
        }
    }

    void FixedUpdate()
    {
        //Move the player
        Vector3 movement = new Vector3(h, 0, v).normalized;
        Quaternion targetRoation =Quaternion.LookRotation(movement);
        targetRoation =Quaternion.RotateTowards(transform.rotation,targetRoation, degree*Time.fixedDeltaTime);
        if (movement ==Vector3.zero)
        {
            return;
        }
        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime * movementSpeed);
        rb.MoveRotation(targetRoation);
    }

    bool IsGrounded()
    {   
        return Physics.CheckSphere(groundCheck.position,.1f, Ground);
    }

        bool IsTrampolined()
    {   
        return Physics.CheckSphere(groundCheck.position,.1f, Trampoline);
    }
}
