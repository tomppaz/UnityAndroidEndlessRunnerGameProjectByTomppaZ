using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

	public GameObject theRoad;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;
	private int roadSelector;
	private int dangerSelector;
	private float[] platformWidths;
	public ObjectPooler[] theObjectPools;
	private CashGenerator theCashGenerator;
	public float randomCashTreshold;
	public float randomDangerTreshold;
	public ObjectPooler[] theDangerPool;
	private float dangerXPosition;
	public float miniumDangerSpawnDistanceFromEdge;

	// Use this for initialization
	void Start () {
		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
			platformWidths [i] = theObjectPools [i].pooledObject.GetComponent<Renderer> ().bounds.size.x;
		}

		theCashGenerator = FindObjectOfType<CashGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			roadSelector = Random.Range (0, theObjectPools.Length);

			transform.position = new Vector3(transform.position.x + (platformWidths[roadSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

			GameObject newPlatform = theObjectPools [roadSelector].GetPooledObject ();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if (Random.Range (0f, 100f) < randomCashTreshold) {
				theCashGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
			}

			if (Random.Range (0f, 100f) < randomDangerTreshold) {
				dangerSelector = Random.Range (0, theDangerPool.Length);
				GameObject newDanger = theDangerPool [dangerSelector].GetPooledObject ();

				dangerXPosition = Random.Range ((-platformWidths [roadSelector] / 2) + miniumDangerSpawnDistanceFromEdge, (platformWidths [roadSelector] / 2) - miniumDangerSpawnDistanceFromEdge);

				float dangerYPosition = Random.Range (0.1f, 0.42f);

				Vector3 dangerPosition = new Vector3 (dangerXPosition, dangerYPosition, 0f);
				newDanger.transform.position = transform.position + dangerPosition;
				newDanger.transform.rotation = transform.rotation;
				newDanger.SetActive (true);

			}

			transform.position = new Vector3(transform.position.x + (platformWidths[roadSelector] / 2), transform.position.y, transform.position.z);
		}
	
}
}
