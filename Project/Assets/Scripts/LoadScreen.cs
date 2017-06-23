using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour {


	public string lvlToLoad1;
	public Image progressBar;

	private float loadProgress;

	// Use this for initialization
	void Start () {
		StartCoroutine ("SceneSwitch");
	}


	IEnumerator SceneSwitch()
	{
		AsyncOperation async1 = Application.LoadLevelAsync (lvlToLoad1);
		while (!async1.isDone) {
			loadProgress = async1.progress;
			progressBar.fillAmount = loadProgress;
			print (async1.progress);
			yield return null;
		}
			
			
	}
}
