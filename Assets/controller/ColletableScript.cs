using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableScript : MonoBehaviour {


	
	void Start () {
		
	}
	
	
	void Update () {
		
			transform.Translate(new Vector2(0f, -0.02f));  

		if(transform.position.y<-5.0f){
			GameObject.Destroy (this.gameObject);
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
			if (this.tag == "BigFish") {
			ViewController.score++;
			ViewController.score++;
			}

			else if (this.tag == "SlowFish") {
				PlayerScript.velocity = 0.1f; 
			}
			else if (this.tag == "InvertFish") {
				PlayerScript.inversion = -1; 
			}
			else{
				ViewController.score++;
			}

			GameObject.Destroy(this.gameObject);
            ViewController.Update();
            Debug.Log(ViewController.score);
        }
    }


}
