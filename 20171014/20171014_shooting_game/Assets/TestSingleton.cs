using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSingleton : MonoBehaviour {

	void Start() {
        SampleSingleton sampleSingleton = SampleSingleton.Instance;

        // Debug.Log("num is " + sampleSingleton.getNum());

        sampleSingleton.setNum(100);

        // Debug.Log("after num is " + sampleSingleton.getNum());
    }

}
