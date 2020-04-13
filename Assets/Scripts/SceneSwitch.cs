using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public UIManager ui;
    public static int level = 1;
    
   


    public void LevelSelect()
    {
        SceneManager.LoadScene(sceneName: "level_select");
    }


    public static void levelSelect()
    {
        SceneManager.LoadScene(sceneName: "level_select");
    }

    public static void resultsScreen()
    {
        SceneManager.LoadScene(sceneName: "Score_Screen");
    }


    public void NextLevel()
    {

        level++;
        Ball.balls = new List<GameObject>();
        SceneManager.LoadScene(sceneName:$"level_{level}");
    }
    

    public void LevelSelect(int _level)
    {
        level = _level;
        SceneManager.LoadScene(sceneName: $"level_{_level}");
    }

}
