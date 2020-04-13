
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseBall
{
    // Start is called before the first frame update
    private bool jumping = true;
    public float speed = 20f;
    public int touchDirVert = 0;
    public int touchDirHor = 0;
    public float rotationSpeed = 10f;
    public float speedMultiplier = 1;
    public bool poweredUp = false;
    public int powerDuration = 5;
    public float jumpTimer = 0;
    public Vector3 forward;
    bool doubleTap = false;
    public Dictionary<PowerUp.powerUpType, float> powerUpEndTime;

    new void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height,true);
        base.Start();
        base.rb.drag = 2;
        powerUpEndTime = new Dictionary<PowerUp.powerUpType, float>();
        transform.up = base.gravDir;
    }


    public override void slowUpdate()
    {


        removePowerUps();

       
    }

    void removePowerUps()
    {
        if (powerUpEndTime.Count != 0)
        {
            foreach (PowerUp.powerUpType pUp in powerUpEndTime.Keys)
            {
                if (powerUpEndTime[pUp] < Time.time)
                {
                    if (pUp == PowerUp.powerUpType.Speed)
                    {
                        speedMultiplier -= 0.5f;
                    }
                    powerUpEndTime.Remove(pUp);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();


        transform.forward = Vector3.ProjectOnPlane(transform.forward, gravDir).normalized;

        touchDirVert = 0;
        touchDirHor = 0;
        doubleTap = false;
        foreach (Touch touch in Input.touches)
        {
            if (touch.tapCount >= 2)
            {
                doubleTap = true;
            }
            if (touch.position.x <= Screen.width / 2)
            {

                if (touch.position.y >  Screen.height / 2)
                {
                    touchDirVert = 1;
                }
                else
                {
                    touchDirVert = -1;
                }
            }
            else
            {
                if (touch.position.x > 3*Screen.width / 4)
                {
                    touchDirHor = 1;
                }
                else
                {
                    touchDirHor = -1;
                }
            }
        }

        if (jumping && Input.GetKey("m") && GetComponent<Rigidbody>().velocity.y> -15)
        {
            GetComponent<Rigidbody>().velocity += base.gravDir;
        }


        if (Input.GetKeyDown("left shift"))
        {
            speedMultiplier +=0.5f;
        }
        else if(Input.GetKeyUp("left shift"))
        {
            speedMultiplier -= 0.5f;
        }

        if(Vector3.Dot(Vector3.ProjectOnPlane(base.rb.velocity,gravDir),transform.forward) < speed*speedMultiplier)
        {
            GetComponent<Rigidbody>().AddForce(2*(Input.GetAxis("Vertical")+touchDirVert) * Vector3.ProjectOnPlane(transform.forward, gravDir).normalized * GetComponent<Rigidbody>().mass * speed * speedMultiplier);
        }
        
        //base.rb.velocity = Vector3.Dot(base.rb.velocity, gravDir)*base.gravDir + Input.GetAxis("Vertical") * Vector3.ProjectOnPlane(transform.forward, gravDir) * speed * speedMultiplier;
         
        float rotation = (Input.GetAxis("Horizontal")+touchDirHor) * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.RotateAround(transform.position,-gravDir, rotation);

        if ((Input.GetKeyDown("space")||doubleTap) &&!jumping)
        {
            int jumpVel = 10;
            if(Time.time-jumpTimer < 0.25f)
            {
                jumpVel = 20;
            }
            GetComponent<Rigidbody>().velocity -= base.gravDir * jumpVel;
            jumping = true;
        }
        
       

    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject collidee = collision.gameObject;
        if (collidee.name == "Terrain")
        {
            jumpTimer = Time.time;
            jumping = false;
        }
    }

    public void powerUp(PowerUp.powerUpType pUp)
    {
        


        if (powerUpEndTime.ContainsKey(pUp))
        {
            powerUpEndTime[pUp] += 20;
        }
        else
        {
            powerUpEndTime.Add(pUp, Time.time + 20f);
            if (pUp == PowerUp.powerUpType.Speed)
            {
                speedMultiplier += 0.5f;
            }
        }
    }
}
