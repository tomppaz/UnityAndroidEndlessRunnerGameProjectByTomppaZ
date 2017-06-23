using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

	public float orgspeed;
	public float speed;
	private Renderer _renderer;

	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed, 0);
		_renderer.material.mainTextureOffset = offset;
	}
}
