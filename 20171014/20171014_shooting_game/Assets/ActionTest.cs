using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------------------------
// 委譲元　メソッドの登録・削除（実行はしない）
// -------------------------------------------
public class ActionTest : MonoBehaviour {

	// [SerializeField] private ActionInput actionInput;

	private ActionInput actionInput;

	void Awake() {
		// scriptの参照
		GameObject actionInputObj = GameObject.Find("ActionInput");
		if(actionInputObj != null){
			actionInput = actionInputObj.GetComponent<ActionInput>();
		}
		if(actionInput == null){
			Debug.Log("Cannot find 'ActionInput' script.");
		}
	}

	void OnEnable() {
		// アクションメソッドを登録
		actionInput.AnyKeyDown += KeyDownAction;
		actionInput.AnyKeyDown += ClickSpaceAction;
		actionInput.ClickSpace += ClickSpaceAction;
	}
	void OnDisable() {
		// アクションメソッドを削除
		actionInput.AnyKeyDown -= KeyDownAction;
		actionInput.AnyKeyDown -= ClickSpaceAction;
		actionInput.ClickSpace -= ClickSpaceAction;
		Debug.Log("disabled");
	}

	void KeyDownAction() {
		Debug.Log("Fire KeyDownAction");
	}
	void ClickSpaceAction() {
		Debug.Log("Fire ClickSpaceAction");
	}
}
