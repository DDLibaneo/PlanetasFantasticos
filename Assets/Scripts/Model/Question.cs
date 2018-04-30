using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {
	
	public List<string> questions;

	public Question (List<string> questions) {
		this.questions = questions;
	}

	// public Question (IDictionary<string, object> dictionary) {
	// 	this.question = dictionary["question"].ToString();
	// }
	
}
