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
	private DataAdder dataAdder = new DataAdder();
	public GetNodesTest getNodesTest;
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

	public void GetPlanets (Action<List<Planet>> completionBlock) {
		List<Planet> tempList = new List<Planet>(); 

		Router.Planets().GetValueAsync().ContinueWith(task => {			
			DataSnapshot planets = task.Result;
			foreach (DataSnapshot itemNode in planets.Children) //de onde vem o taskResult?
			{
				string planetName = itemNode.Key.ToString();				
				tempList.Add(new Planet(planetName));
			}
			completionBlock(tempList);
		});
	}

	public void GetThemes (Action<List<Theme>> completionBlock) {
		List<Theme> tempList = new List<Theme>(); 

		Router.Themes("Jupiter").GetValueAsync().ContinueWith(task => {			
			DataSnapshot themes = task.Result;
			foreach (DataSnapshot itemNode in themes.Children) //de onde vem o taskResult?
			{
				string themeName = itemNode.Key.ToString();				
				tempList.Add(new Theme(themeName));
			}
			completionBlock(tempList);		
		});
	}

	public void GetSubjects (Action<List<Subject>> completionBlock, string planet, string theme) {
		List<Subject> tempList = new List<Subject>(); 

		Router.Subjects("Jupiter", "Historia").GetValueAsync().ContinueWith(task => {			
			DataSnapshot subjects = task.Result;
			foreach (DataSnapshot itemNode in subjects.Children) //de onde vem o taskResult?
			{
				string subjectName = itemNode.Key.ToString();				
				tempList.Add(new Subject(subjectName));
			}
			completionBlock(tempList);		
		});
	}

	public void GetExplanationParagraphs (Action<List<Explanation>> completionBlock, string planet, string theme, string subject) {		
		List<Explanation> tempList = new List<Explanation>(); 

		Router.ExplanationParagraphs(planet, theme, subject).GetValueAsync().ContinueWith(task => {
			DataSnapshot paragraphs = task.Result;
			foreach (DataSnapshot itemNode in paragraphs.Children) 
			{
				string paragraph = itemNode.Value.ToString();					
				tempList.Add(new Explanation(paragraph));
			}
			completionBlock(tempList);
		});
	}

	public void GetQuestions (Action<List<Question>> completionBlock, string planet, string theme, string subject) {
		List<Question> tempList = new List<Question>(); 

		Router.Questions(planet, theme, subject).GetValueAsync().ContinueWith(task => {
			DataSnapshot questions = task.Result;

			foreach (DataSnapshot itemNode in questions.Children) 
			{
				var questionDictionary = (IDictionary<string, object>)itemNode.Value;
				Question newQuestion = new Question(questionDictionary);
				tempList.Add(newQuestion);
			}
			completionBlock(tempList);
		});
	}
}