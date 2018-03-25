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

	// Use this for initialization
	void Start ()
	{
		FatCat.SetActive (false);
		MedCat.SetActive (false);
		SkinnyCat.SetActive (false);
		Score.SetActive (false);
		ReturnButton.SetActive (false);
		SpeechBubble.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()

	{
		int timepassed = (int)Time.timeSinceLevelLoad;
		if (timepassed == 5) {
			FatCat.SetActive (true);
			SpeechBubble.SetActive (true);

		} else if (timepassed == 8) {
			SpeechBubble.SetActive (false);
		} else if (timepassed == 12) {
			FatCat.SetActive (false);
			MedCat.SetActive (true);
		} else if (timepassed == 16) {
			MedCat.SetActive (false);
			SkinnyCat.SetActive (true);
		} else if (timepassed == 17) {
			Score.SetActive (true);
		} else if (timepassed == 20) {
			ReturnButton.SetActive (true);
		}
	}
}
