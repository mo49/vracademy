using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionInput : MonoBehaviour {

	public event Action AnyKeyDown;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown && AnyKeyDown != null){
    		AnyKeyDown();
    	}
	}
}
