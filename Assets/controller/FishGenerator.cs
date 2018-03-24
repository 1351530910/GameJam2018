using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishGenerator : MonoBehaviour {

	public GameObject Fish;
	public GameObject BigFish;
	public GameObject SlowFish;
	public GameObject InvertFish;

	private int rnd;
	private float droprnd;
	private float height;
	private Quaternion rotation = new Quaternion(0,0,0,0);

	// Use this for initialization
	void Start () {
		Fish = GameObject.Find ("Fish");
		BigFish = GameObject.Find ("BigFish");
		SlowFish = GameObject.Find ("SlowFish");
		InvertFish = GameObject.Find ("InvertFish");
		height = 4f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rnd = Random.Range (0,100);
		droprnd = Random.Range (-6.5f, 6.5f);

		if (rnd < 60) {
				Instantiate(Fish, new Vector2(droprnd,height), rotation);
		} else if (rnd < 75) {
				Instantiate(SlowFish, new Vector2(droprnd,height), rotation);
		} else if (rnd < 90) {
				Instantiate(InvertFish, new Vector2(droprnd,height), rotation);
		} else {
				Instantiate(BigFish, new Vector2(droprnd,height), rotation);
		}

	}
}
