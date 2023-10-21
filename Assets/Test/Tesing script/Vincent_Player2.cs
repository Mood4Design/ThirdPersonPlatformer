using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player2 : MonoBehaviour
{
    public float moveSpeed; 
    public Rigidbody rigi;
    public float jumpForce;
// Use this for initialization
    void start () 
    {
        rigi = GetComponent<Rigidbody>();
    }
    //Update is called once per frame
     void Update () 
     {
        if(Input.GetButtonDown("Jump"))
        {
            rigi.velocity = new Vector3(rigi.velocity.x, jumpForce, rigi.velocity.z);
        }
     }
    
    void FixedUpdate()
    {
        rigi.velocity = new Vector3(Input.GetAxis ("Horizontal") * moveSpeed, rigi.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        
    } 
}
