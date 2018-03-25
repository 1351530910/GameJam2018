using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Main {

    public static Timer bpm;
    public static Timer countdown;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void setup(){
       // ViewController.Init();
    }

    public static void settimer(double bpm,double duration)
    {
        Main.bpm.Stop();
        Main.bpm = new Timer();
        Main.bpm.Interval = 0.001 / (bpm/60);
        Main.bpm.Elapsed += Bpm_Elapsed;

        countdown.Stop();
        countdown = new Timer();
        countdown.Interval = duration;
        countdown.Elapsed += Countdown_Elapsed;
        
        Main.bpm.Start();
    }

    private static void Countdown_Elapsed(object sender, ElapsedEventArgs e)
    {
        
    }

    private static void Bpm_Elapsed(object sender, ElapsedEventArgs e)
    {
        countdown.Start();
    }
    
}
