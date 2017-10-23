using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("Sample");
    }

	// Update is called once per frame
	void Update () {

	}

	IEnumerator Sample() {
        yield return null;
    }
}
