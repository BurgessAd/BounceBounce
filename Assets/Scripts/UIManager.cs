using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static int ballsOwned;
    public static int totalNum;
    public static List<GameObject> balls;
    public Text text;
    public Player player;
    public bool complete = false;
    public static float startTime=0;
    public static float endTime=0;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        balls = Ball.balls;
        ballsOwned = 0;
        totalNum = Ball.balls.Count;
        text.text = $"Balls collected: {0} / {totalNum}";
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        totalNum = balls.Count;
        for (int i = 0; i <totalNum; i++)
        {
        
            if ((balls[i].GetComponent<Ball>()).owner == 1)
            {
                count++;
            }
        }
        ballsOwned = count;
        

        text.text = $"Balls collected: {count} / {totalNum} \nPowerUps: ";
        foreach(PowerUp.powerUpType pUp in player.powerUpEndTime.Keys)
        {
            text.text = text.text + pUp.ToString() + " ";
        }


        if (ballsOwned > totalNum / 2)
        {
            complete = true;
            Ball.balls.Clear();
            endTime = Time.time;
            SceneSwitch.resultsScreen();
        }

    }
}
