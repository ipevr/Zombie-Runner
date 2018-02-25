using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

	[Tooltip ("Length of a day in minutes")]
	public float lengthOfDayInMin = 6f;

	private Vector3 startRot = new Vector3(5f,270f,0f);

	// Use this for initialization
	void Start () {
		transform.eulerAngles = startRot;
	}
	
	// Update is called once per frame
	void Update () {
		float degreesPerSecond = 360 / (lengthOfDayInMin * 60f);
		transform.RotateAround (transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);

	}
}
