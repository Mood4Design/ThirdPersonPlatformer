using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vincent_Player3 : MonoBehaviour
{
    public float moveSpeed; 
    public Rigidbody rb;
    public float jumpForce;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis ("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical"));
        if(Input.GetButtonDown("Jump"))
        {
           rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    void FixedUpdate()
    {
        movePlayer(movement);
    }
    void movePlayer(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
