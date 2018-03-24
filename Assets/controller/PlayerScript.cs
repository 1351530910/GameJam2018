using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	public float velocity = 0.3f;
	public static float jump = 1000;
	public static Rigidbody rigidbody;
	public static bool jumping = false;
	public static bool right = true;

	public GameObject imageNormal;
	public GameObject imageNormalJump;
	public GameObject imageSlowed;
	public GameObject imageSlowedJump;
	public GameObject imageInverted;
	public GameObject imageInvertedJump;

	public GameObject camera;


	void Start ()
	{
		camera = GameObject.Find ("Main Camera");

		imageNormal = GameObject.Find ("imageNormal");
		imageNormalJump = GameObject.Find ("imageNormalJump");
		//imageSlowed = GameObject.Find ("imageSlowed");
		//imageSlowedJump = GameObject.Find ("imageSlowedJump");
		//imageInverted = GameObject.Find ("imageInverted");
		//imageInvertedJump = GameObject.Find ("imageInvertedJump");


		rigidbody = this.GetComponent<Rigidbody> ();
		Physics.gravity = new Vector3 (0, -160, 0);
	}


	private void FixedUpdate ()
	{
		Vector3 camerapos = camera.transform.position;
		camerapos.x = transform.position.x;
		camera.transform.position = camerapos;
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		if (transform.position.y < -2.3f) {
			if (verticalMovement > 0) {
				rigidbody.AddForce (new Vector3 (0, jump, 0));
			}
			imageNormalJump.SetActive (false);
			imageNormal.SetActive (true);
		

		} else {
			imageNormalJump.SetActive (true);
			imageNormal.SetActive (false);
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

			Vector3 currentpos = transform.position;
			currentpos.x += velocity * horizontalMovement;
			transform.position = currentpos;
		}





	}
}
