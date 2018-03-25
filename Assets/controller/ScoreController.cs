using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	//public static string ScoreText;
	public static int score;
	public int curr;
	//public Text thisText;

	// Font fields
	public GameObject[] numbers;
	public GameObject numFontStart;


	// Use this for initialization
	void Start () {
		//thisText = null;
		score = 0;
		//ScoreText = "EXP: ";
		//SetScore ();

	}
	
	// Update is called once per frame
	void Update () {
		if (curr>1000) {
			score = curr;
		}
		//thisText.text = ScoreText;

		// Font
		DestroyAllOther ();
		NumberFont ("" + score, numFontStart.transform.position, 1f);
	}

public static void AddScore(int time){
		for(int i = 0; i< time; i++){
			score ++;
			//SetScore ();
}
}
	public static void RemoveScore(int time){
		for(int i = 0; i< time; i++){
			score --;
			//SetScore ();
		}
	}
	/*
	public static void SetScore() {
		ScoreText = "EXP: " + score;
}*/

	public void NumberFont(string s, Vector3 pos, float gap) {

		int num = 0;
		int ser = int.Parse (s);
		int lim = s.Length;

		for (int n = 0; n < lim; n++) {
			num = int.Parse ((s.ToCharArray () [n]).ToString ());
			GameObject newb;
			newb = Instantiate (numbers [num], new Vector3 (pos.x + n * gap, pos.y, pos.z), Quaternion.identity);
			newb.transform.localScale = new Vector2 (0.1f, 0.1f);
			
		}
	
	}

	public void DestroyAllOther() {

		GameObject[] others = GameObject.FindGameObjectsWithTag ("Num");
		foreach (GameObject go in others) {
			if (go != gameObject) {
				Destroy (go);
			}
		}
	
	}
}
