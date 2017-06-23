using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmmount;

	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();

		for (int i = 0; i < pooledAmmount; i++) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	}
	
	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects[i].activeInHierarchy) {
				return pooledObjects[i];
			}
		}

		GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;

	}
}
