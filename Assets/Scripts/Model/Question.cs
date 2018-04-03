using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {
	
	public List<Answer> Answers;
	public string Text {get; set;} 
	public int QuestionId {get; set;}

	public Question(int QuestionId, string Text) {
		this.QuestionId = QuestionId;
		this.Text = Text;
	}
}
