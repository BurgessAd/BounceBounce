using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{

    public Text results;
    public Texture blueBall;
    public Texture redBall;
    public Text bestTime;
    public float bestTimeVal;
    public Graphic container;
    public Phase phase;
    public Vector2 endPosition = new Vector2(0,0);
    public Vector2 beginPosition = new Vector2(0,-1000);
    // Start is called before the first frame update

    public enum Phase
    {
        timer,hopping,stars
    }

    void Start()
    {
        container.rectTransform.anchoredPosition = beginPosition;
        phase = Phase.hopping;
        float timeTaken = UIManager.endTime - UIManager.startTime;
        results.text = $"{(int)timeTaken/60}:{(int)timeTaken%60}";
        bestTime.text = $"{(int)bestTimeVal / 60}:{(int)bestTimeVal % 60}";
    }

    void FixedUpdate()
    {
        if(phase == Phase.hopping)
        {
            if(container.rectTransform.anchoredPosition.y < endPosition.y)
            {
                container.rectTransform.anchoredPosition += new Vector2(0, 25);
            }
            else
            {
                phase = Phase.timer;
            }
        }
        else if(phase == Phase.timer)
        {

        }
        else if(phase == Phase.stars)
        {

        }




    }



}
