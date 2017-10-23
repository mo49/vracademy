using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// -------------------------------------------
// 委譲先 Manager メソッドを実行する
// -------------------------------------------
public class ActionInput : MonoBehaviour {

	public event Action AnyKeyDown;
	public event Action ClickSpace;

	void Update () {
		// 条件をまとめる
		if(Input.GetKeyDown(KeyCode.Space) && ClickSpace != null){
			ClickSpace();
			return;
    	}
		if(Input.anyKeyDown && AnyKeyDown != null){
    		AnyKeyDown(); // 処理の実行
    	}
	}
}
