using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Answer {
	 
	public Question Question {get; set;}
	public int QuestionId {get; set;}
	public string Text {get; set;}
}
