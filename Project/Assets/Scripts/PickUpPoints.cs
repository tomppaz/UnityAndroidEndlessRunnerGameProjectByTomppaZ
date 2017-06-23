using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour {

	public int cashToGive;

	private ScoreManager theScoreMan;

	private CashManager theCashMan;
	// Use this for initialization
	void Start () {
		theScoreMan = FindObjectOfType<ScoreManager> ();
		theCashMan = FindObjectOfType<CashManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			theCashMan.cashAmmount++;
			theCashMan.storeCash ();
			gameObject.SetActive (false);
		}
			
	}
	void OnTrigger2D(Collider2D thing)
	{
		if (thing.gameObject.tag == "kill") {
			gameObject.SetActive (false);
		}
	}
}
