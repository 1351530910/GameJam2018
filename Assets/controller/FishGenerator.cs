using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishGenerator : MonoBehaviour {

	public GameObject Fish;
	public GameObject BigFish;
	public GameObject SlowFish;
	public GameObject InvertFish;

	public List<GameObject> bigFishList = new List<GameObject> ();
	public List<GameObject> fishList = new List<GameObject> ();
	public List<GameObject> slowFishList = new List<GameObject> ();
	public List<GameObject> invertFishList = new List<GameObject> ();

	private int rnd;
	private int debuffrnd;
	private float droprnd;
	private float debuffdroprnd;
	private float height;
	public float resetTimer;
	private Quaternion rotation = new Quaternion(0,0,0,0);

	// Use this for initialization
	void Start () {
		Fish = GameObject.Find ("Fish");
		BigFish = GameObject.Find ("BigFish");
		SlowFish = GameObject.Find ("SlowFish");
		InvertFish = GameObject.Find ("InvertFish");
		height = 4f;
		for (int i = 0; i < 16; i++) {
			fishList.Add (Instantiate (Fish));
		}for (int i = 0; i < 16; i++) {
			bigFishList.Add (Instantiate (BigFish));
		}for (int i = 0; i < 16; i++) {
			slowFishList.Add (Instantiate (SlowFish));
		}for (int i = 0; i < 16; i++) {
			invertFishList.Add (Instantiate (InvertFish));
		}
		foreach (GameObject child in fishList) {
			child.SetActive (false);
		}foreach (GameObject child in bigFishList) {
			child.SetActive (false);
		}foreach (GameObject child in slowFishList) {
			child.SetActive (false);
		}foreach (GameObject child in invertFishList) {
			child.SetActive (false);
		}
		height = -4.0f;
		resetTimer = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Time.time > (resetTimer + (109f / 60f))) {

			resetTimer = Time.time;
			rnd = Random.Range (0, 100);
			debuffrnd = Random.Range (0, 100);
			droprnd = Random.Range (-6.5f, 6.5f);
			debuffdroprnd = Random.Range (-6.5f, 6.5f);

			if (rnd < 80) {
				foreach (GameObject fish in fishList) {
					if (!fish.gameObject.activeSelf) {
						fish.gameObject.SetActive (true);
						fish.transform.position = new Vector2 (droprnd, height);
						break;
					}
				}
			} else {
				foreach (GameObject fish in bigFishList) {
					if (!fish.gameObject.activeSelf) {
						fish.gameObject.SetActive (true);
						fish.transform.position = new Vector2 (droprnd, height);
						break;
					}
				}
			}

			if (debuffrnd < 25) {
				foreach (GameObject fish in slowFishList) {
					if (!fish.gameObject.activeSelf) {
						fish.gameObject.SetActive (true);
						fish.transform.position = new Vector2 (debuffdroprnd, height);
						break;
					}
				}
			} else if(debuffrnd < 50){
				foreach (GameObject fish in invertFishList) {
					if (!fish.gameObject.activeSelf) {
						fish.gameObject.SetActive (true);
						fish.transform.position = new Vector2 (debuffdroprnd, height);
						break;
					}
				}
			}
		}
	}
}
