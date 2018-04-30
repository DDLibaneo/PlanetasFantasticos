using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Subject {
	public string subject;

	public Subject (string subject) {
		this.subject = subject;
	}
	public Subject (IDictionary<string, object> dictionary) {
		this.subject = dictionary["subject"].ToString();
	}

}
