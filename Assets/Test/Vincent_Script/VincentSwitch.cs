using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VincentSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] material;
    private Renderer renderer;
    [SerializeField] private GameObject target;

    private bool turnOff;
    void Start()
    {   
        turnOff =false;
        renderer =GetComponent<Renderer>();
        renderer.enabled =true;
        renderer.sharedMaterial =material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(turnOff==true){
            renderer.sharedMaterial= material[1];
            target.SetActive(false);
        }
        else{
            renderer.sharedMaterial =material[0];
            target.SetActive(true);
        }
    }


    // If player collides with the switch, it will turn on and off
    void OnTriggerEnter(Collider other){
        //set switch color off;
        if(other.tag =="Player"){
            if(turnOff == true){
                turnOff = false;
            }
            else{
                turnOff = true;
            }
            
        }
    }
}
