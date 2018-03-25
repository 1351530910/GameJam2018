using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableScript : MonoBehaviour {
	
	void FixedUpdate () {
		
		transform.Translate(new Vector2(0f, 0.04f));  

	if (transform.position.y> 5.0f){
			this.gameObject.SetActive (false);
		}
	}

 
}
