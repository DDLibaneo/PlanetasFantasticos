using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {
	
	public string question { get; set; }
	public List<Answer> answers = new List<Answer>();

	public Question () {

	}

	public Question (string question) {
		this.question = question;
	}

	public Question (IDictionary<string, object> dictionary) {
		this.question = dictionary["Question"].ToString();
		//this.answers = dictionary[""]
  }
}
