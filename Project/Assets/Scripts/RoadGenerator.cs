using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

	public GameObject theRoad;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;
	private int roadSelector;
	private float[] platformWidths;
	public ObjectPooler[] theObjectPools;
	private CashGenerator theCashGenerator;
	public float randomCashTreshold;
	public float randomDangerTreshold;
	public ObjectPooler spikePool;
	public ObjectPooler trashPool;
	public ObjectPooler firePool;
	private int randomLol;

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
						randomLol = Random.Range (1,4);
						if(randomLol == 1)
						{
						GameObject newSpike = spikePool.GetPooledObject();
						Vector3 spikePosition = new Vector3(0f, 0.4f, 0f);
						newSpike.transform.position = transform.position + spikePosition;
						newSpike.transform.rotation = transform.rotation;
						newSpike.SetActive (true);
						} else if(randomLol == 2)
						{
							GameObject newFire = firePool.GetPooledObject();
							Vector3 firePosition = new Vector3(0f, 0.2f, 0f);
							newFire.transform.position = transform.position + firePosition;
							newFire.transform.rotation = transform.rotation;
							newFire.SetActive (true);
						} else if(randomLol == 3)
						{
							GameObject newTrash = trashPool.GetPooledObject();
							Vector3 trashPosition = new Vector3(0f, -0.1f, 0f);
							newTrash.transform.position = transform.position + trashPosition;
							newTrash.transform.rotation = transform.rotation;
							newTrash.SetActive (true);
						}

			transform.position = new Vector3(transform.position.x + (platformWidths[roadSelector] / 2), transform.position.y, transform.position.z);
		}
	}
}
}
