using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	//public AudioClip audioclip;
	public AudioSource audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
		audiosource.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			audiosource.Pause ();
		}
		if (Time.timeScale == 1) {
			audiosource.UnPause ();
		}
	}
}
