using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour {

	public float cashAmmount;
	public Text cashText;
	public StoreCash theCashStore;

	void Start()
	{
		theCashStore = FindObjectOfType<StoreCash> ();
		getCash();
		cashText.text = "" + cashAmmount; 
	}
	void Update()
	{
		//storeCash ();
		cashText.text = "" + cashAmmount;
		theCashStore.storedCash = cashAmmount;
	}

	public void storeCash()
	{
		PlayerPrefs.SetFloat ("cash", cashAmmount);
	}

	public void getCash()
	{
		cashAmmount = PlayerPrefs.GetFloat ("cash", 0);
	}
}
