using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : BaseBall
{
    
    public byte owner =0;
    public static List<GameObject> balls = new List<GameObject>();
    public Material playerMaterial;
    public Material enemyMaterial;
    public float timer = 0;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        balls.Add(gameObject);
        GetComponent<Rigidbody>().drag = 0f;
        GetComponent<Rigidbody>().velocity = Random.Range(1, 10) * Random.onUnitSphere;
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (timer != 0 && Time.time > timer)
        {
            rb.isKinematic = false;
        }
    }


    public override void slowUpdate()
    {
        
    }

   

    void OnCollisionEnter(Collision c)
    {
        AudioHandler.singleton.CollisionEffect(gameObject, c);

        if (c.gameObject.name == "Player")
        {
            Player player = c.gameObject.GetComponent<Player>();
            if (player.powerUpEndTime.ContainsKey(PowerUp.powerUpType.Ice))
            {
                rb.isKinematic = true;
                timer = Time.time+3;
            }
            GetComponent<Renderer>().material = playerMaterial;
            owner = 1;
            


        }
        else if (c.gameObject.name == "Enemy")
        {
            GetComponent<Renderer>().material = enemyMaterial;
            owner = 2;
        }
    }
}
