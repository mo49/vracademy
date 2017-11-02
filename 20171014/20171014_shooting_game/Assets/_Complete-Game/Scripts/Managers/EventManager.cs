using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    private static EventManager mInstance;
    private int score = 0;

    public static EventManager Instance {
        get {
            if( mInstance == null ) {
                GameObject obj = new GameObject("EventManager");
                mInstance = obj.AddComponent<EventManager>();
            }
            return mInstance;
        }
    }

    public void setScore( int n ) {
        this.score = n;
    }
    public int getScore() {
        return this.score;
    }

}


