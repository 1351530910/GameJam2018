using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float speedfront;
	public float speedback;

	// Use this for initialization
	void Start () {
		speedfront = -0.03f;
		speedback = -0.01f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (gameObject.name == "frontview") {
			transform.Translate(new Vector2 ( speedfront, 0f));
		}

		if (gameObject.name == "backview") {
			transform.Translate(new Vector2 ( speedback, 0f));
		}
	}
}
