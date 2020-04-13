using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUp : MonoBehaviour
{

    public powerUpType pUpType;

    public enum powerUpType { 
        Speed, Fire, Ice 
    }


    // Start is called before the first frame update
    void Start()
    {
        Array values = Enum.GetValues(typeof(powerUpType));
        System.Random random = new System.Random();
        //pUpType = (powerUpType)values.GetValue(random.Next(values.Length));
        pUpType = powerUpType.Ice;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(5, 0, 0, Space.Self);
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
            
            c.gameObject.GetComponent<Player>().powerUp(pUpType);
            Destroy(gameObject);
        }
        
    }

  


}
