using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deflector : MonoBehaviour
{


    public float threshold = 300;
    
    public float forceModifier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        
        GameObject collidee = collision.gameObject;
        Vector3 force = forceModifier * collision.impulse / (float)Time.fixedDeltaTime;
        if(force.magnitude == 0)
        {
            return;
        }

        if(collision.gameObject.name=="Terrain" && force.magnitude<threshold && force.magnitude> -threshold)
        {

            force *= threshold/force.magnitude;
        }
        
        this.GetComponent<Rigidbody>().AddForce(force);
        
       
    }



}
