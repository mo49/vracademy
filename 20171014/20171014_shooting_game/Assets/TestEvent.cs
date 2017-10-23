using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEvent : MonoBehaviour {
  [SerializeField] private UnityEvent m_event;

  // Use this for initialization
  void Start () {
		if(m_event == null)
      m_event = new UnityEvent();
    m_event.AddListener(Ping);
  }

	// Update is called once per frame
	void Update () {

	}

	void Ping() {
    Debug.Log("Ping");
  }
}
