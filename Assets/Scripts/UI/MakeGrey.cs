using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeGrey : MonoBehaviour {

	private Toggle toggle;

	void Start () {
		toggle = this.GetComponent<Toggle>();
	}
	
	void Update () {
		if(!toggle.isOn){
			GetComponentInChildren<Image>().color = new Color32(184, 184, 184, 255);
		}
	}

	
}
