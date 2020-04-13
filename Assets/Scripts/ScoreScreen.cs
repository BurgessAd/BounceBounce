using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{

    public Text results;


    // Start is called before the first frame update
    void Start()
    {
        results.text = $"Time: {(int)(UIManager.endTime - UIManager.startTime)} secs";
    }



}
