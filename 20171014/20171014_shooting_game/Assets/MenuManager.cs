using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {

	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	Canvas canvas;

	void Start () {
		canvas = GetComponent<Canvas> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ToggleMenu ();
		}
	}

	void ToggleMenu() {
		canvas.enabled = !canvas.enabled;
		// 時間依存で動いているものは止まる
		Time.timeScale = Time.timeScale == 1 ? 0 : 1;
		// スナップショットを切り替える
		if(Time.timeScale == 0){
			unpaused.TransitionTo(.01f);
		} else {
			paused.TransitionTo(.01f);
		}
	}

}
