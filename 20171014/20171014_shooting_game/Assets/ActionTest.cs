using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------------------------
// 委譲元　メソッドの登録・削除（実行はしない）
// -------------------------------------------
public class ActionTest : MonoBehaviour {

	[SerializeField] private ActionInput m_actionInput;

	void OnEnable() {
		// アクションメソッドを登録
		m_actionInput.AnyKeyDown += KeyDownAction;
		m_actionInput.AnyKeyDown += ClickSpaceAction;
		m_actionInput.ClickSpace += ClickSpaceAction;
		Debug.Log("enabled");
	}
	void OnDisable() {
		// アクションメソッドを削除
		m_actionInput.AnyKeyDown -= KeyDownAction;
		m_actionInput.AnyKeyDown -= ClickSpaceAction;
		m_actionInput.ClickSpace -= ClickSpaceAction;
		Debug.Log("disabled");
	}

	void KeyDownAction() {
		Debug.Log("Fire KeyDownAction");
	}
	void ClickSpaceAction() {
		Debug.Log("Fire ClickSpaceAction");
	}
}
