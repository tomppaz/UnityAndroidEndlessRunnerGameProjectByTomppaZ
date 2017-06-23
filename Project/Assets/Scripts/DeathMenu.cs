using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject fadeScreen;
	public Animator fadeAnim;

	void Start()
	{
		fadeScreen.SetActive (false);
	}
	public void RestartGame()
	{
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMain()
	{
		fadeScreen.SetActive (true);
		fadeAnim.SetTrigger ("playAnimTrig");
		StartCoroutine ("LoadMenuScene");
	}

	IEnumerator LoadMenuScene()
	{
		AsyncOperation asyncMenu = Application.LoadLevelAsync (mainMenuLevel);
		yield return null;
	}
}
