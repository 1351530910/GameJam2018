﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	public static float velocity; 
	public static float jump = 300;
	public static Rigidbody2D rigidbody;
	public static bool jumping = false;
	public static bool right;
	public static int inversion;

	public GameObject imageNormal;
	public GameObject imageNormalJump;
	public GameObject imageSlowed;
	public GameObject imageSlowedJump;
	public GameObject imageInverted;
	public GameObject imageInvertedJump;

	//public GameObject camera;

	void awake(){
		
	}

	void Start ()
	{
		//camera = GameObject.Find ("Main Camera");
		Debug.Log("did start");
		imageNormal = GameObject.Find ("imageNormal");
		imageNormalJump = GameObject.Find ("imageNormalJump");
		imageSlowed = GameObject.Find ("imageSlowed");
		imageSlowedJump = GameObject.Find ("imageSlowedJump");
		imageInverted = GameObject.Find ("imageInverted");
		imageInvertedJump = GameObject.Find ("imageInvertedJump");

		imageNormal.SetActive (false);
		imageNormalJump.SetActive (false);
		imageSlowed.SetActive (false);
		imageSlowedJump.SetActive (false);
		imageInverted.SetActive (false);
		imageInvertedJump.SetActive (false);

		right = true;
		velocity = 0.2f;
		inversion = 1;
		rigidbody = this.GetComponent<Rigidbody2D> ();
		Physics2D.gravity = new Vector2 (0, -30);
	}


	private void FixedUpdate ()
	{
		//Vector3 camerapos = camera.transform.position;
		//camerapos.x = transform.position.x;
		//camera.transform.position = camerapos;
		float horizontalMovement = Input.GetAxis ("Horizontal")  * inversion;
		float verticalMovement = Input.GetAxis ("Vertical");
		Debug.Log ("vertical" + verticalMovement);
		if (transform.position.y <0.5f) {
			if (verticalMovement > 0) {
				rigidbody.AddForce (new Vector2 (0, jump));
			}
				
			if (inversion == -1) {
				imageInverted.SetActive (true);
				imageSlowed.SetActive (false);
				imageNormal.SetActive (false);
				imageInvertedJump.SetActive (false);
				imageSlowedJump.SetActive (false);
				imageNormalJump.SetActive (false);
			} else if (velocity < 0.2f){
					imageSlowed.SetActive (true);
					imageSlowedJump.SetActive (false);
					imageNormal.SetActive (false);
					imageInverted.SetActive (false);
				imageInvertedJump.SetActive (false);
				imageNormalJump.SetActive (false);
		
			} else {
				imageNormal.SetActive (true);
				imageNormalJump.SetActive (false);
				imageSlowed.SetActive (false);
				imageInverted.SetActive (false);
				imageSlowedJump.SetActive (false);
				imageInvertedJump.SetActive (false);
			}

		} else {

			if (inversion == -1) {
				imageInvertedJump.SetActive(true);
				imageInverted.SetActive(false);
				imageSlowed.SetActive (false);
				imageNormal.SetActive (false);
				imageSlowedJump.SetActive (false);
				imageNormalJump.SetActive (false);
			} else if (velocity < 0.2f) {
				imageSlowedJump.SetActive (true);
				imageSlowed.SetActive (false);
				imageNormal.SetActive (false);
				imageInverted.SetActive(false);
				imageInvertedJump.SetActive (false);
				imageNormalJump.SetActive (false);

			} else {
				imageNormalJump.SetActive (true);
				imageSlowed.SetActive (false);
				imageNormal.SetActive (false);
				imageInverted.SetActive(false);
				imageSlowedJump.SetActive (false);
				imageInvertedJump.SetActive (false);
			}
		}

		if (horizontalMovement != 0) {
			if (horizontalMovement > 0 && !right) {
				transform.Rotate  (new Vector3 (0, 180,0));
				right = !right;
			}
			if (horizontalMovement < 0 && right) {
				transform.Rotate (new Vector3 (0, 180,0));
				right = !right;
			}

			Vector2 currentpos = transform.position;
			currentpos.x += velocity * horizontalMovement;
			transform.position = currentpos;
		}

	}


	// Collision with fish
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "BigFish") {
			ScoreController.AddScore (3);
			}

		else if (other.tag == "SlowFish") {
				velocity = 0.1f; 
			}
		else if (other.tag == "InvertFish") {
				inversion = -1; 
			}
		else if(other.tag == "Fish"){

			ScoreController.AddScore (1);

			}
		Debug.Log ("before fish");
			other.gameObject.SetActive (false);
		//	ViewController.Update();
			Debug.Log("score" + ScoreController.score);

	}
}
