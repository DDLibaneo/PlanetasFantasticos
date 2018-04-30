using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Unity.Editor;
using System;
using System.Threading.Tasks;

public class DatabaseManager : MonoBehaviour {
 
	public static DatabaseManager sharedInstance = null;

	/// <summary>
	/// Awake this instance and initialize sharedInstance for Singleton pattern
	/// </summary>
	void Awake() {
		if (sharedInstance == null) {
			sharedInstance = this;
		} 
		else if (sharedInstance != this) {
			Destroy(gameObject);  
		}

		DontDestroyOnLoad(gameObject);
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://planets-tests.firebaseio.com/");

		Debug.Log(Router.Players());
		Debug.Log(Router.Planets());
	}
	
	public void CreateNewPlayer (Player player, string uid) { // We're saving data!
		//we need to convert the object to raw json to put it on the database
		string playerJSON = JsonUtility.ToJson(player);
		Router.PlayerWithUID(uid).SetRawJsonValueAsync(playerJSON);
	}

	public void GetPlayers (Action<List<Player>> completionBlock) { // We're retrieving data!
		Debug.Log("Function fired");
		List<Player> tempList = new List<Player>();
		
		Router.Players().GetValueAsync().ContinueWith(task => { // here our task returns a Data Snapshot	
			DataSnapshot players = task.Result; // this snapshot will be an iDictionary of iDictionaries, that's how you set up a player node when saving new player info
			// we can get each player individual dictionary with an foreach loop:

			foreach (DataSnapshot playerNode in players.Children) {
				var playerDictionary = (IDictionary<string, object>)playerNode.Value; //we convert the playerNode.Value into an iDictionary of json objects]
				Player newPlayer = new Player(playerDictionary);
				tempList.Add(newPlayer);
			}
			//Assign tempList to our completion block
			completionBlock(tempList);
		});
	}

	public void CreateNewSubject (Subject subject) {
		Debug.Log(subject.subject);
		string subjectJson = JsonUtility.ToJson(subject);
		Router.Subject().SetRawJsonValueAsync(subjectJson);
	}

	public void CreateNewExplanations (List<string> explanations) {
		foreach (string explanation in explanations)
		{			
			//Router.Explanation().Child("Paragraph").SetValueAsync(explanation);
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

	public void GetPlanets (Action<List<Player>> completionBlock) {
		List<Planet> tempList = new List<Planet>(); 

		Router.Planets().GetValueAsync().ContinueWith(task => {
			
		});
	}
}