using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timetest : MonoBehaviour {

	public Text time;
	// Use this for initialization
	void Start () {
		time =  GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		time.text = string.Format("{0:N2}", Time.time);
		Debug.Log (Time.time);
	}
}
