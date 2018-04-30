using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Explanation {
    
	public string explanation;

	public Explanation (string explanation) {
		this.explanation = explanation;
	}

	public Explanation (IDictionary<string, object> dictionary) {
		this.explanation = dictionary["explanation"].ToString();
	}
}
