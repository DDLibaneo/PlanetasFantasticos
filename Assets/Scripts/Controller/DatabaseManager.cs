using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
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
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://firequest-f0846.firebaseio.com/");
		FirebaseApp.DefaultInstance.SetEditorP12FileName("FireQuest-c6de189dba86.p12");
    FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("daniel@firequest-f0846.iam.gserviceaccount.com");
    FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

		Debug.Log(Router.Players());
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
}