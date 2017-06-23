using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public string GameLevel;
	public Text cashTxt;
	public StoreCash theCashStore;
	public GameObject musicGObject;
	public AudioSource music;
	public GameObject fadeScreen;
	public Animator fadeAnim;

	void Start()
	{
		fadeScreen.SetActive (false);
		theCashStore = FindObjectOfType<StoreCash> ();
		musicGObject = GameObject.FindWithTag ("music");
		music = musicGObject.GetComponent<AudioSource> ();
		music.Play();
	}

	void Update()
	{
		cashTxt.text = "" + theCashStore.storedCash;
	}

	public void StartGame()
	{
		fadeScreen.SetActive (true);
		fadeAnim.SetTrigger ("playAnimTrig");
		//Application.LoadLevel (GameLevel);
		StartCoroutine ("LoadPlayScene");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	IEnumerator LoadPlayScene()
	{
		AsyncOperation asyncGame = Application.LoadLevelAsync (GameLevel);
		yield return null;
	}
		
}
