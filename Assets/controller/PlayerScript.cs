using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	public AudioClip crunch;
	public AudioClip argh;
	public AudioSource audiosource;

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

	public bool fat;

	public GameObject fatNormal;
	public GameObject fatNormalJump;
	public GameObject fatSlowed;
	public GameObject fatSlowedJump;
	public GameObject fatInverted;
	public GameObject fatInvertedJump;

	public static float timeleft = -1.0f;
	public static float timeleft2 = -1.0f;

	//public GameObject camera;

	void awake ()
	{
		
	}

	void Start ()
	{
		audiosource = GetComponent<AudioSource> ();

		//camera = GameObject.Find ("Main Camera");
		Debug.Log ("did start");
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

		fatNormal.SetActive (false);
		fatNormalJump.SetActive (false);
		fatSlowed.SetActive (false);
		fatSlowedJump.SetActive (false);
		fatInverted.SetActive (false);
		fatInvertedJump.SetActive (false);

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
		float horizontalMovement = Input.GetAxis ("Horizontal") * inversion;
		float verticalMovement = Input.GetAxis ("Vertical");

		timeleft -= 0.02f;
		timeleft2 -= 0.02f;//
		if (timeleft <= 0)
		{
			inversion = 1;
		}
		if (timeleft2 <= 0)
		{
			velocity = 0.2f;
		}

		if (fat) {
			imageNormal.SetActive (false);
			imageNormalJump.SetActive (false);
			imageSlowed.SetActive (false);
			imageSlowedJump.SetActive (false);
			imageInverted.SetActive (false);
			imageInvertedJump.SetActive (false);
			jump = 250;
			if (transform.position.y < 0.5f) {
				if (verticalMovement > 0) {
					rigidbody.AddForce (new Vector2 (0, jump ));
				}

				if ((inversion == -1 && timeleft >= 0)) {
					fatInverted.SetActive (true);
					fatSlowed.SetActive (false);
					fatNormal.SetActive (false);
					fatInvertedJump.SetActive (false);
					fatSlowedJump.SetActive (false);
					fatNormalJump.SetActive (false);
				} else if (velocity < 0.15f && timeleft2 >= 0) {
					fatSlowed.SetActive (true);
					fatSlowedJump.SetActive (false);
					fatNormal.SetActive (false);
					fatInverted.SetActive (false);
					fatInvertedJump.SetActive (false);
					fatNormalJump.SetActive (false);

				} else {
					fatNormal.SetActive (true);
					fatNormalJump.SetActive (false);
					fatSlowed.SetActive (false);
					fatInverted.SetActive (false);
					fatSlowedJump.SetActive (false);
					fatInvertedJump.SetActive (false);
				}

			} else {

				if (inversion == -1 && timeleft >= 0) {
					fatInvertedJump.SetActive (true);
					fatInverted.SetActive (false);
					fatSlowed.SetActive (false);
					fatNormal.SetActive (false);
					fatSlowedJump.SetActive (false);
					fatNormalJump.SetActive (false);
				} else if (velocity < 1.5f && timeleft2 >= 0) {
					fatSlowedJump.SetActive (true);
					fatSlowed.SetActive (false);
					fatNormal.SetActive (false);
					fatInverted.SetActive (false);
					fatInvertedJump.SetActive (false);
					fatNormalJump.SetActive (false);

				} else {
					fatNormalJump.SetActive (true);
					fatSlowed.SetActive (false);
					fatNormal.SetActive (false);
					fatInverted.SetActive (false);
					fatSlowedJump.SetActive (false);
					fatInvertedJump.SetActive (false);
				}
			}
			}else {
			fatNormal.SetActive (false);
			fatNormalJump.SetActive (false);
			fatSlowed.SetActive (false);
			fatSlowedJump.SetActive (false);
			fatInverted.SetActive (false);
			fatInvertedJump.SetActive (false);
			if (transform.position.y < 0.5f) {
				if (verticalMovement > 0) {
					rigidbody.AddForce (new Vector2 (0, jump));
				}
				
				if (inversion == -1 && timeleft >= 0) {
					imageInverted.SetActive (true);
					imageSlowed.SetActive (false);
					imageNormal.SetActive (false);
					imageInvertedJump.SetActive (false);
					imageSlowedJump.SetActive (false);
					imageNormalJump.SetActive (false);
				} else if (velocity < 0.2f && timeleft2 >= 0) {
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

				if (inversion == -1 && timeleft >= 0) {
					imageInvertedJump.SetActive (true);
					imageInverted.SetActive (false);
					imageSlowed.SetActive (false);
					imageNormal.SetActive (false);
					imageSlowedJump.SetActive (false);
					imageNormalJump.SetActive (false);
				} else if (velocity < 0.2f && timeleft2 >= 0) {
					imageSlowedJump.SetActive (true);
					imageSlowed.SetActive (false);
					imageNormal.SetActive (false);
					imageInverted.SetActive (false);
					imageInvertedJump.SetActive (false);
					imageNormalJump.SetActive (false);

				} else {
					imageNormalJump.SetActive (true);
					imageSlowed.SetActive (false);
					imageNormal.SetActive (false);
					imageInverted.SetActive (false);
					imageSlowedJump.SetActive (false);
					imageInvertedJump.SetActive (false);
				}
			}

		}
		if (horizontalMovement != 0) {
			if (horizontalMovement > 0 && !right) {
				transform.Rotate (new Vector3 (0, 180, 0));
				right = !right;
			}
			if (horizontalMovement < 0 && right) {
				transform.Rotate (new Vector3 (0, 180, 0));
				right = !right;
			}

			Vector2 currentpos = transform.position;
			currentpos.x += velocity * horizontalMovement;
			transform.position = currentpos;
		}

		if (ScoreController.score >= 50) {
			fat = true;
			fatTransformation ();
		}

		if (ScoreController.score < 50) {
			fat = false;
			fatTransformation ();
		}

		if(fat) Debug.Log (fat);

	
		if (Time.time >= 120) {
			Application.LoadLevel ("gameOver");						
		}
	}



	// Collision with fish
	private void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "BigFish") {
			ScoreController.AddScore (3);
			audiosource.PlayOneShot (crunch, 100f);
		} else if (other.tag == "SlowFish") {
			velocity = 0.1f; 
			PlayerScript.timeleft2 = 5.0f;
			ScoreController.RemoveScore (2);
			audiosource.PlayOneShot (argh, 1f);
		} else if (other.tag == "InvertFish") {
			inversion = -1; 
			PlayerScript.timeleft = 5.0f;
			ScoreController.RemoveScore (2);
			audiosource.PlayOneShot (argh, 1f);
		} else if (other.tag == "Fish") {

			ScoreController.AddScore (1);
			audiosource.PlayOneShot (crunch, 100f);
		}

		other.gameObject.SetActive (false);
		//	ViewController.Update();

	}


	private void fatTransformation ()
	{
	}
}
