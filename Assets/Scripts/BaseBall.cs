using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBall : MonoBehaviour
{
    float time;
    public Rigidbody rb;
    public Vector3 gravDir;
    public bool gravitates = true;


    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        time = Time.time;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {


        if (gravitates)
        {
            getGravity();
        }
        
        if (Time.time > time + 1)
        {
            time = Time.time;
            slowUpdate();
            
        }
    }

    public abstract void slowUpdate();
    public void getGravity()
    {
        if (SceneSwitch.level == 1 || SceneSwitch.level == 2)
        {
            gravDir = new Vector3(0,-1,0);
        }
        else if (SceneSwitch.level == 3)
        {
            gravDir = new Vector3(10.4f, -35.7f, 33) - rb.position;
            gravDir = gravDir.normalized;
        }
        else
        {
            gravDir = new Vector3(0, -1, 0);
        }
        rb.AddForce(gravDir * rb.mass * 9f);
    }

}
