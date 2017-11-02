using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	Canvas canvas;

	private InputManager inputManager;

	void Awake() {
		// scriptの参照
		GameObject inputManagerObj = GameObject.Find ("InputManager");
		if (inputManagerObj != null) {
			inputManager = inputManagerObj.GetComponent<InputManager> ();
		}
		if (inputManager == null) {
			Debug.Log ("Cannot find 'inputManager' script");
		}
	}

	void OnEnable() {
		inputManager.ToggleMenu += ToggleMenu;
	}
	void OnDisable() {
		inputManager.ToggleMenu -= ToggleMenu;
	}

	void Start()
	{
		canvas = GetComponent<Canvas>();
	}

	void ToggleMenu() {
		canvas.enabled = !canvas.enabled;
		Pause();
	}

	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass ();

	}

	void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			paused.TransitionTo(.01f);
		}

		else

		{
			unpaused.TransitionTo(.01f);
		}
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
