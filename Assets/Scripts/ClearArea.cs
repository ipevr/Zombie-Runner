using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

	public float clearTime = 3f;

	private float timeSinceLastTrigger = 0f;
	private bool foundClearArea = false;
	private bool messageNoClearAreaSended = false;

	void Update() {
		timeSinceLastTrigger += Time.deltaTime;
		if (timeSinceLastTrigger >= clearTime && Time.realtimeSinceStartup > 10f && !foundClearArea) {
			SendMessageUpwards ("OnFindClearArea");
			foundClearArea = true;
			messageNoClearAreaSended = false;
		} else if (timeSinceLastTrigger < clearTime && !messageNoClearAreaSended) {
			SendMessageUpwards ("OnNoClearArea");
			messageNoClearAreaSended = true;
			foundClearArea = false;
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag != "Player") {
			timeSinceLastTrigger = 0;
		}
	}

}
