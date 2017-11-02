using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEvent : MonoBehaviour {
  [SerializeField] private UnityEvent m_event;

  void Start () {
		if(m_event == null)
      m_event = new UnityEvent();
    m_event.AddListener(Ping);
  }

	void Update () {
    if(Input.anyKeyDown && m_event != null) {
      m_event.Invoke();
    }
	}

	void Ping() {
    // Debug.Log("Ping");
  }
}
