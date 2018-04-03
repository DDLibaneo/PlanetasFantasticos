using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Router : MonoBehaviour {

	// Root reference to our project
	private static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;
	
	public static DatabaseReference Players() {
		return baseRef.Child("players");
	}

	public static DatabaseReference PlayerWithUID(string uid) { // Will look up the player with the uid we pass in
		return baseRef.Child("players").Child(uid);
	}
}
