using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Theme {
	public string theme;

	public Theme (string theme) {
		this.theme = theme;
	}

	public Theme (IDictionary<string, object> dictionary) {
		this.theme = dictionary["theme"].ToString();
	}
}
