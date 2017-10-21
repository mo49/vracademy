using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSingleton : MonoBehaviour {

    private static SampleSingleton mInstance;
    private int num = 0;

	public static SampleSingleton Instance {
		get {
			if( mInstance == null ) {
				GameObject go = new GameObject("SampleSingleton");
                mInstance = go.AddComponent<SampleSingleton>();
			}
            return mInstance;
        }
		set {

		}
	}

	public int setNum( int n = 0 ) {
        return this.num = n;
    }
	public int getNum() {
        return this.num;
    }


}
