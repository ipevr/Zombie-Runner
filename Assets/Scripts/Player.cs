using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints;
	public GameObject landingArea;
	public bool reSpawn = false;

	private Transform[] spawnPoint;


	// Use this for initialization
	void Start () {
		spawnPoint = playerSpawnPoints.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (reSpawn) {
			ReSpawn ();
		}
	}

	private void ReSpawn() {
		int spawnPointNumber = Random.Range (1, spawnPoint.Length); // element 0 is the parent!!!
		transform.position = spawnPoint [spawnPointNumber].position;
		reSpawn = false;
	}

	private void OnHelicopterCalled() {
		Invoke ("DropFlare", 0f);
	}

	private void DropFlare() {
		Instantiate (landingArea, transform.position, transform.rotation);
	}

}
