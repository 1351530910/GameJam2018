﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableScript : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
			if (this.tag == "BigFish") {

			ViewController.score++;
			}

            ViewController.score++;
            GameObject.Destroy(this.gameObject);
            ViewController.Update();
            Debug.Log(ViewController.score);
        }
    }
}
