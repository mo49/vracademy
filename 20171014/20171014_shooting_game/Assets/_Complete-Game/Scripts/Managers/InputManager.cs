using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour {

	public event Action ToggleMenu;

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) && ToggleMenu != null) {
			ToggleMenu ();
		}
	}
}
