using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public float speed = 50f;

	private Rigidbody rigidBody;
	private bool dispatched = false;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void OnDispatchHelicopter () {
		rigidBody.velocity = new Vector3 (0, 0, speed);
		dispatched = true;
	}
}
