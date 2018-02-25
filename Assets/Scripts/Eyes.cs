using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

	public float zoomRatio = 1.5f;

	private Camera eye;
	private float defaultFOV;
	private float zoomedFOV;
	// Use this for initialization
	void Start () {
		eye = GetComponent<Camera> ();
		defaultFOV = eye.fieldOfView;
		zoomedFOV = defaultFOV / zoomRatio;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Zoom")) {
			eye.fieldOfView = zoomedFOV;
		} else {
			eye.fieldOfView = defaultFOV;
		}
	}

}
