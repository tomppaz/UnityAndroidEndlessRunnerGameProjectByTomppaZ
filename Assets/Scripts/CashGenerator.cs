using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashGenerator : MonoBehaviour {

	public ObjectPooler coinPool;
	public float distanceBetweenCoins;

	public void SpawnCoins (Vector3 startPosition)
	{
		GameObject cash1 = coinPool.GetPooledObject ();
		cash1.transform.position = startPosition;
		cash1.SetActive (true);

		GameObject cash2 = coinPool.GetPooledObject ();
		cash2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
		cash2.SetActive (true);

		GameObject cash3 = coinPool.GetPooledObject ();
		cash3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
		cash3.SetActive (true);
	}
}
