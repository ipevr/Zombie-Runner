using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

	public float volume = 0.2f;
	public AudioClip responseFromHeli;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = volume;
	}
	
	private void OnMakeInitialHeliCall() {
		audioSource.clip = responseFromHeli;
		audioSource.Play ();
		BroadcastMessage ("OnDispatchHelicopter");
	}


}
