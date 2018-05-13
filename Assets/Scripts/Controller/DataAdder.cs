using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataAdder {

	public void CreateNewPlayer (Player player, string uid) { // We're saving data!
		//we need to convert the object to raw json to put it on the database
		string playerJSON = JsonUtility.ToJson(player);
		Router.PlayerWithUID(uid).SetRawJsonValueAsync(playerJSON);
	}
	
	public void CreateNewExplanations (List<string> explanations) {
		foreach (string explanation in explanations)
		{						
			Router.Explanation().SetValueAsync(explanation);
		}
	}

	public void CreateNewQuestions (List<string> questions) {
		foreach (string question in questions)
		{
				Router.Question().Child("Question").SetValueAsync(question);
		}
	}

	public void CreateNewAnswers (List<Answer> answers) {
		foreach (Answer answer in answers)
		{
			string answerJson = JsonUtility.ToJson(answer);
			Debug.Log("Conteudo do answerJson: " + answerJson);
			Router.Answer().SetRawJsonValueAsync(answerJson);
		}
	}
}
