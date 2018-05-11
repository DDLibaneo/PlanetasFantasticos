﻿using System.Collections;
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
		FirebaseApp.DefaultInstance.SetEditorP12FileName("planets-tests-2ec2a79f2334.p12");
    FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("daniel@planets-tests.iam.gserviceaccount.com ");
    FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");
		
		getNodesTest.GetExplanations();

		Debug.Log(Router.subjectReference);
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
		Debug.Log("Function fired");
		List<Planet> tempList = new List<Planet>(); 

		Router.Planets().GetValueAsync().ContinueWith(task => {
			if(task.IsFaulted || task.IsCanceled) {				
				Debug.Log("Ocorreu um erro com a task");				
				return;
			}
			else if (task.IsCompleted) {
				Debug.Log("Task Fired");
				DataSnapshot planets = task.Result;
				Debug.Log(planets);
				foreach (DataSnapshot itemNode in planets.Children) //de onde vem o taskResult?
				{
						var planetDictionary = (IDictionary<string, object>)itemNode.Value;
						Planet newPlanet = new Planet(planetDictionary);
						tempList.Add(newPlanet);
				}
				completionBlock(tempList);
			}				
		});
	}

	public void GetExplanation (Action<List<string>> completionBlock) {
		Debug.Log("Function fired");
		List<string> tempList = new List<string>(); 

		Router.Subject().GetValueAsync().ContinueWith(task => {
			if(task.IsFaulted || task.IsCanceled) {				
				Debug.Log("Ocorreu um erro com a task");				
				return;
			}
			else if (task.IsCompleted) {
				Debug.Log("Task ContinueWith() Fired");
				DataSnapshot paragraphs = task.Result;
				Debug.Log(paragraphs);
				foreach (DataSnapshot itemNode in paragraphs.Children) 
				{
						var paragraph = itemNode.Value.ToString();					
						tempList.Add(paragraph);
				}
				completionBlock(tempList);
			}
		});
	}
}