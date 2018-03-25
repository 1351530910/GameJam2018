using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static string ScoreText;
	public static int score;
	public Text thisText;

	// Use this for initialization
	void Start () {
		thisText = GetComponent<Text>();
		score = 0;
		SetScore ();

	}
	
	// Update is called once per frame
	void Update () {
		thisText.text = ScoreText;
	}

public static void AddScore(int time){
		for(int i = 0; i< time; i++){
	score ++;
			SetScore ();
}
}
	public static void RemoveScore(int time){
		for(int i = 0; i< time; i++){
			score --;
			SetScore ();
		}
	}

	public static void SetScore() {
		ScoreText = "EXP: " + score;
}
}
