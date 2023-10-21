using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRoation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float RotateSpeed =15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,RotateSpeed,0f)* Time.deltaTime);
    }
}
