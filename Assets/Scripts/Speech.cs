using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour {

	public float volume = 0.4f;
	public AudioClip whatHappened;
	public AudioClip callForHeli;
	public AudioClip clearAreaSound;
	public AudioClip wrongPlaceForHeli;

	private AudioSource audioSource;
	private bool called = false;
	private bool areaClear = false;
	private bool clearAreaSoundPlayed  = false;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		audioSource.volume = volume;
		PlayClip (whatHappened, 2f);

	}

	void Update () {

		if (!called) {
			if (areaClear) {
				if (Input.GetButtonDown ("CallHeli")) {
					PlayClip (callForHeli, 0f);
					SendMessageUpwards ("OnHelicopterCalled");
					Invoke ("CallHeli", callForHeli.length + 1f);
					called = true;
				}
				if (!clearAreaSoundPlayed) {
					PlayClip (clearAreaSound, 0f);
					clearAreaSoundPlayed = true;
				}
			} else if (!areaClear) {
				clearAreaSoundPlayed = false;
				if (Input.GetButtonDown ("CallHeli")) {
					PlayClip (wrongPlaceForHeli, 0f);
				}
			}
		}

	}
	
	private void PlayClip(AudioClip clip, float delay) {
		audioSource.clip = clip;
		audioSource.PlayDelayed (delay);
	}

	void OnFindClearArea() {
		areaClear = true;
	}

	void OnNoClearArea() {
		areaClear = false;
	}

	void CallHeli() {
		SendMessageUpwards ("OnMakeInitialHeliCall");
	}

}
