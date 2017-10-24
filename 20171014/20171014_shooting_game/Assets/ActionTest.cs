using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------------------------
// 委譲元　メソッドの登録・削除（実行はしない）
// -------------------------------------------
public class ActionTest : MonoBehaviour {

	// [SerializeField] private InputManager inputManager;

	private InputManager inputManager;

	void Awake() {
		// scriptの参照
		GameObject inputManagerObj = GameObject.Find("InputManager");
		if(inputManagerObj != null){
			inputManager = inputManagerObj.GetComponent<InputManager>();
		}
		if(inputManager == null){
			Debug.Log("Cannot find 'InputManager' script.");
		}
	}

	void OnEnable() {
		// アクションメソッドを登録
		inputManager.AnyKeyDown += KeyDownAction;
		inputManager.AnyKeyDown += ClickSpaceAction;
		inputManager.ClickSpace += ClickSpaceAction;
	}
	void OnDisable() {
		// アクションメソッドを削除
		inputManager.AnyKeyDown -= KeyDownAction;
		inputManager.AnyKeyDown -= ClickSpaceAction;
		inputManager.ClickSpace -= ClickSpaceAction;
	}

	void KeyDownAction() {
		Debug.Log("Fire KeyDownAction");
	}
	void ClickSpaceAction() {
		Debug.Log("Fire ClickSpaceAction");
	}
}
