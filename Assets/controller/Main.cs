using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Main {

    public static Timer bpm;
    public static Timer countdown;
	public static List<int> leaderboard;



    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void setup(){
		try {
			leaderboard = (List<int>)Serializer.Load("savedata");
			updateldb();
		} catch (System.Exception ex) {
			leaderboard = new List<int> ();
			Serializer.Save("savedata", leaderboard);
			updateldb ();
		}
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
	public static void updateldb(){
		leaderboard.Sort ();
		GameObject leaderb = GameObject.Find ("leaderboard");
		Text l = leaderb.GetComponent<Text> ();
		string txt = "leaderboard:\n";
		for (int i = leaderboard.Count-1; i >= 0; i--) {
			txt += leaderboard [i]+"\n";
		}
		l.text = txt;
		Serializer.Save ("savedata", leaderboard);
	}
}
