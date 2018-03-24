using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	GameObject[] pauseObjects;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("SettingsPaused");
		foreach (GameObject g in pauseObjects) {
			g.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showSetting() {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			foreach (GameObject g in pauseObjects) {
				g.SetActive (true);
			}
		} else {
			Time.timeScale = 1;
			foreach (GameObject g in pauseObjects) {
				g.SetActive (false);
			}
		}
	}


	public void loadLevel(string level) {
		Application.LoadLevel (level);
	}

	public void quitGame() {
		Application.Quit();
	}
}
