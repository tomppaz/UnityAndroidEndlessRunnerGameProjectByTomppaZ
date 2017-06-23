using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
		platformDestructionPoint = GameObject.Find ("RoadDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestructionPoint.transform.position.x) {
			gameObject.SetActive (false);
		}
	}
}
