using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform roadGenerator;
	private Vector3 platformStartPoint;
	public Movement thePlayer;
	private Vector3 playerStartPoint;
	private PlatformDestroyer[] platformList;
	private ScoreManager theScoreManager;
	public DeathMenu theDeathScreen;
	public BGScroll bgscroll;
	// Use this for initialization
	void Start () {
		platformStartPoint = roadGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame()
	{
		bgscroll.speed = 0f;
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		theDeathScreen.gameObject.SetActive (true);
	}

	public void Reset()
	{
		theDeathScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = playerStartPoint;
		roadGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreIncreasing = true;
		theScoreManager.scoreCount = 0;
		bgscroll.speed = bgscroll.orgspeed;
	}
}
