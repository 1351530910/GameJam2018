using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{

	public GameObject FatCat;
	public GameObject MedCat;
	public GameObject SkinnyCat;
	public GameObject Score;
	public GameObject ReturnButton;
	public GameObject SpeechBubble;

	public GameObject VomitMusic;

	public GameObject fishStackSpawn;
	public GameObject fishPrefab;
	private int fishCount;

	private float fishSpawnRate;
	private float fishSpawnCount;

	public ParticleSystem vomitSystem;
	private bool inVomit;

	//debug
	private int score = 50;

	// Use this for initialization
	void Start ()
	{
		FatCat.SetActive (false);
		MedCat.SetActive (false);
		SkinnyCat.SetActive (false);
		Score.SetActive (false);
		ReturnButton.SetActive (false);
		SpeechBubble.SetActive (false);
		vomitSystem.Play ();

		fishCount = 0;
		fishSpawnCount = 0f;
		fishSpawnRate = score * 20 / 12;

		inVomit = false;
	}
	

	void Update ()

	{
		int timepassed = (int)Time.timeSinceLevelLoad;
		if (timepassed == 2) {
			FatCat.SetActive (true);
			SpeechBubble.SetActive (true);

		} else if (timepassed == 6) {
			SpeechBubble.SetActive (false);

		} else if (timepassed == 7) {
			FatCat.SetActive (false);
			MedCat.SetActive (true);

		} else if (timepassed == 12) {
			MedCat.SetActive (false);
			SkinnyCat.SetActive (true);

		} else if (timepassed == 15) {
			Score.SetActive (true);

		} else if (timepassed == 18) {
			ReturnButton.SetActive (true);
		}


		if (timepassed >= 7 && !inVomit) {
			vomitSystem.Emit (1);
		}

		if (timepassed >= 7 && fishCount < score) {

			if (fishSpawnCount < 0) {
				spawnFish ();
				fishSpawnCount = 1 / fishSpawnRate;
			}
			fishSpawnCount -= Time.deltaTime;
		}
	}

	private void spawnFish() {
		GameObject newFish;
		newFish = Instantiate (fishPrefab, new Vector2 (fishStackSpawn.transform.position.x,
			fishStackSpawn.transform.position.y + fishCount * 4), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
		newFish.transform.localScale = new Vector3 (10, 10, 1);

		fishCount++;

	}
}
