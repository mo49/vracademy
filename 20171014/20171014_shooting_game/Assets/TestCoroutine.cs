using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour {

	bool isRunning = false;

	IEnumerator coroutineMethod;

	// Use this for initialization
	void Start () {
        // StartCoroutine("Sample", 60);
        StartCoroutine("Sample1");
        StartCoroutine("StartTimer");

		coroutineMethod = Sample(1000);
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			StopCoroutine("StartTimer");
		}
	}

	void OnMouseDown() {
		StartCoroutine(coroutineMethod);
	}
	void OnMouseUp() {
		StopCoroutine(coroutineMethod);
	}

	IEnumerator Sample(int len) {
		// 1フレームごとに実行する
		for (int i = 0; i < len; i++) {
			yield return null;
			Debug.Log("i: " + i);
		}
    }

	IEnumerator Sample1() {
		// Debug.Log("Sample1 start"); // ①
		yield return StartCoroutine("Sample2");
		// Debug.Log("Sample1 end");   // ④
	}
	IEnumerator Sample2() {
		// Debug.Log("Sample2 start"); // ②
		yield return new WaitForSeconds(1f);
		// Debug.Log("Sample2 end");   // ③
	}

	// stop
	IEnumerator StartTimer() {
		if(isRunning) yield break;
		isRunning = true;
		yield return new WaitForSeconds(3f);
		Explode();
	}
	void Explode() {
		Debug.Log("どっかーん");
	}

}
