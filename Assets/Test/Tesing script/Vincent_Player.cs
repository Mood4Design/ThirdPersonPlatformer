using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float moveSpeed =10; 
    public Rigidbody rb;
    public float jumpForce =5;

// Use this for initialization
    void start () 
    {   
        rb = GetComponent<Rigidbody>();    
    }
    //Update is called once per frame
    void Update () 
    {   
        rb.velocity = new Vector3(Input.GetAxis ("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        if(Input. GetButtonDown("Jump")){
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
        
}