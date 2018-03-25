using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FishDispatcher : MonoBehaviour
{

	public GameObject FishList;
	public GameObject BigFishList;
	public GameObject SlowFishList;
	public GameObject InvertFishList;

	public GameObject Fish;
	public GameObject BigFish;
	public GameObject SlowFish;
	public GameObject InvertFish;

	private List<GameObject> FishArray = new List<GameObject>();
	private List<GameObject> BigFishArray = new List<GameObject>();
	private List<GameObject> SlowFishArray = new List<GameObject>();
	private List<GameObject> InvertFishArray = new List<GameObject>();

	public static bool FishReady;
	public static bool BigFishReady;
	public static bool SlowFishReady;
	public static bool InvertFishReady;

	private int rnd;
	private float droprnd;
	private float height;
	private float time;
	private float resetTime;
	private Quaternion rotation = new Quaternion (0, 0, 0, 0);

	// Use this for initialization
	void Start ()
	{
		FishReady = false;
		BigFishReady = false;
		SlowFishReady = false;
		InvertFishReady = false;



		time = 0.0f;
		resetTime = 0.0f;
		FishList = GameObject.Find ("FishList");
		BigFishList = GameObject.Find ("BigFishList");
		SlowFishList = GameObject.Find ("SlowFishList");
		InvertFishList = GameObject.Find ("InvertFishList");

		for (int i = 0; i < 16; i++) {
			FishArray.Add(Instantiate (Fish));
			foreach (Transform child in FishList.transform) {
				child.gameObject.SetActive (false);
			}
		}
		for (int i = 0; i < 16; i++) {
			Instantiate (BigFish).transform.parent = BigFishList.transform;
			foreach (Transform child in BigFishList.transform) {
				child.gameObject.SetActive (false);
			}
		}
		for (int i = 0; i < 16; i++) {
			Instantiate (SlowFish).transform.parent = SlowFishList.transform;
			foreach (Transform child in SlowFishList.transform) {
				child.gameObject.SetActive (false);
			}
		}
		for (int i = 0; i < 16; i++) {
			Instantiate (InvertFish).transform.parent = InvertFishList.transform;
			foreach (Transform child in InvertFishList.transform) {
				child.gameObject.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		

		if (Time.time > resetTime + (109 / 60)) {
			resetTime = Time.time;
			rnd = Random.Range (0, 100);
			droprnd = Random.Range (-6.5f, 6.5f);
			transform.position = new Vector2 (droprnd, 4);


			if (rnd < 60) { 
				foreach (Transform child in FishList.transform) {
					if(!child.gameObject.activeSelf){
					child.gameObject.SetActive (true);
						break;
				}
				}

			} else if (rnd < 75) {
				foreach (Transform child in SlowFishList.transform) {
					if(!child.gameObject.activeSelf){
						child.gameObject.SetActive (true);
						break;
					}
				}

			} else if (rnd < 90) {
				foreach (Transform child in InvertFishList.transform) {
					if(!child.gameObject.activeSelf){
						child.gameObject.SetActive (true);
						break;
					}
				}

			} else {
				foreach (Transform child in BigFishList.transform) {
					if(!child.gameObject.activeSelf){
						child.gameObject.SetActive (true);
						break;
					}
				}

			}
		}
	}
}
