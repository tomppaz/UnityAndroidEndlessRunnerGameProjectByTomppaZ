using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;
	public float pointsPerSecond;
	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		getHiScore ();
		hiScoreText.text = "HighScore: " + Mathf.Round (hiScoreCount);
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		if (scoreCount > hiScoreCount) {
			hiScoreCount = scoreCount;
		}

		scoreText.text = "" + Mathf.Round (scoreCount);
		hiScoreText.text = "HighScore: " + Mathf.Round (hiScoreCount);
		
	}

	public void storeHiScore()
	{
		PlayerPrefs.SetFloat ("hScore", hiScoreCount);
	}

	public void getHiScore()
	{
		hiScoreCount = PlayerPrefs.GetFloat ("hScore", 0);
	}
}
