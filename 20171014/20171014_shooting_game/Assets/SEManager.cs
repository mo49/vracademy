using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GameObject.Find("SEObject").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			audio.Play ();
			// audio.PlayOneShot(audio.clip);
			// GetComponent<AudioSource> ().Play();
			// GetComponent<AudioSource> ().PlayOneShot(GetComponent<AudioSource> ().clip);
		}
	}
}
