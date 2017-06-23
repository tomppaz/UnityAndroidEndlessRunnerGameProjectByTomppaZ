using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCash : MonoBehaviour {

	public float storedCash;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		getCashFromStore ();
	}
	
	// Update is called once per frame
	void Update () {
		storeCashToStore ();
	}

	public void storeCashToStore()
	{
		PlayerPrefs.SetFloat ("STcash", storedCash);
	}

	public void getCashFromStore()
	{
		storedCash = PlayerPrefs.GetFloat ("STcash", 0);
	}
}
