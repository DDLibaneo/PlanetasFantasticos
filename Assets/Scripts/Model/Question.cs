using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {
	
	public string question;

	public Question (string question) {
		this.question = question;
	}

	public Question (IDictionary<string, object> dictionary) {
		this.question = dictionary["Question"].ToString();
  }
	
}
