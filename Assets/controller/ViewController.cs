using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class ViewController
{

    public static GameObject Exp;
    public static GameObject Score;
    public static GameObject Leaderboard;

    public static int score = 0;


    public static void Init()
    {

        Exp = GameObject.Find("Exp");
        Score = GameObject.Find("Score");
        Leaderboard = GameObject.Find("Leaderboard");
    }

    public static void Update(){
        Score.GetComponent<Text>().text = ""+score;
    }
}