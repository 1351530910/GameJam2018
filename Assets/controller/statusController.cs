using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusController : MonoBehaviour {

	public GameObject slow;
	public GameObject stun;

	// Use this for initialization
	void Start () {
		
		slow = GameObject.Find ("slow");
		stun = GameObject.Find ("stun");
		slow.gameObject.SetActive (false);
		stun.gameObject.SetActive (false);	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Debug.Log (PlayerScript.timeleft2);

			if (PlayerScript.timeleft > 0.0f) {
			stun.gameObject.SetActive (true);
			} else {
			stun.gameObject.SetActive (false);
			}



			if (PlayerScript.timeleft2 > 0.0f) {
				slow.gameObject.SetActive (true);
			} else {
			slow.gameObject.SetActive (false);
			}

	}
}
