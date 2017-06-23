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
	private float timerTime;
	public float timerTimeTime;

	public string tip1;
	public string tip2;
	public string tip3;
	private int tipSelector = 1;
	public Text tipTxt;

	void Start()
	{
		fadeScreen.SetActive (false);
		theCashStore = FindObjectOfType<StoreCash> ();
		musicGObject = GameObject.FindWithTag ("music");
		music = musicGObject.GetComponent<AudioSource> ();
		music.Play();
		timerTime = timerTimeTime;
	}

	void Update()
	{
		cashTxt.text = "" + theCashStore.storedCash;

		if (timerTime > 0) {
			timerTime -= Time.deltaTime;
		} else {
			timerTime = timerTimeTime;
			tipSelector++;
		}

		if (tipSelector == 4)
			tipSelector = 1;

		if (tipSelector == 1) {
			tipTxt.text = tip1;
		} else if (tipSelector == 2) {
			tipTxt.text = tip2;
		} else if (tipSelector == 3) {
			tipTxt.text = tip3;
		}
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
