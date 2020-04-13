using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseBall
{
    public List<GameObject> balls;
    public float speed = 10f;
    public Vector2 dirToTarget;
    public GameObject currentTarget;
    public float speedMultiplier = 1f;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        balls = Ball.balls;
        currentTarget = getNewTarget();
    }

    private GameObject getNewTarget()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].GetComponent<Ball>().owner != 2)
            {
                return balls[i];
                
            }
        }
        return null;
    }

    public override void slowUpdate()
    {
        if (currentTarget == null || currentTarget.GetComponent<Ball>().owner == 2)
        {
            currentTarget = getNewTarget();
        }
    }

    private void calcDirToTarget()
    {
        if (currentTarget != null)
        {
            dirToTarget = new Vector2((currentTarget.transform.position.x - gameObject.transform.position.x), (currentTarget.transform.position.z - gameObject.transform.position.z)).normalized;
        }
        else
        {
            currentTarget = getNewTarget();
        }
        
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        base.FixedUpdate();
        calcDirToTarget();
        GetComponent<Rigidbody>().velocity = new Vector3(dirToTarget.x* speed * speedMultiplier, GetComponent<Rigidbody>().velocity.y,dirToTarget.y* speed * speedMultiplier);

    }
}
