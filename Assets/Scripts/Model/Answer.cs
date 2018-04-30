using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

[System.Serializable]
public class Answer {
	 
	public string answer;
	public bool isCorrect;
	
	public Answer (string answer, bool isCorrect) {
		
		this.answer = answer;
		this.isCorrect = isCorrect;
	}

	public Answer (IDictionary<string, object> dictionary) {
		
		this.answer = dictionary["answer"].ToString();
		this.isCorrect = Convert.ToBoolean(dictionary["isCorrect"]);
	 }
}
