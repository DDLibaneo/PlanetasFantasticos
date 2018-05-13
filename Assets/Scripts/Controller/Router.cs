using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Router : MonoBehaviour {

	// Root reference to our project
	public static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;
	public static DatabaseReference planetReference = Planet("Jupiter");
	//Fisica, Caracteristicas, Historia
	public static DatabaseReference themeReference = Theme("Historia"); 
	public static DatabaseReference subjectReference = GetSubject("Exploracao");
	public static DatabaseReference questionReference = GetQuestion("-LBJcc3QPZLbkt1go1f6");

	public static DatabaseReference Players () {

		return baseRef.Child("players");
	}

	public static DatabaseReference PlayerWithUID (string uid) { // Will look up the player with the uid we pass in

		return baseRef.Child("players").Child(uid);
	}

	public static DatabaseReference Planets () {

		return baseRef.Child("Planets");
	}

	public static DatabaseReference Planet (Planet planetName) {

		return baseRef.Child("Planets").Child(planetName.planet);
	}

	public static DatabaseReference Planet (string planetName) {

		return baseRef.Child("Planets").Child(planetName);
	}

	public static DatabaseReference Theme (string themeName) {

		return planetReference.Child("Themes").Child(themeName);
	}

	public static DatabaseReference Subject () {

		string pushKey = themeReference.Child("Subjects").Push().Key;
		return themeReference.Child("Subjects").Child(pushKey);
	}

	public static DatabaseReference GetSubject (string pushKey) {

		return themeReference.Child("Subjects").Child(pushKey);
	}

	public static DatabaseReference Explanation () { 

		string pushKey = subjectReference.Child("Explanation").Push().Key;
		return subjectReference.Child("Explanation").Child(pushKey);
	}

	public static DatabaseReference Question () { 

		string pushKey = subjectReference.Child("Question").Push().Key;
		return subjectReference.Child("Questions").Child(pushKey);
	}

	public static DatabaseReference GetQuestion (string pushKey) {

		return subjectReference.Child("Questions").Child(pushKey);
	}

	public static DatabaseReference Answer () {

		string pushKey = questionReference.Push().Key;
		return questionReference.Child("Answers").Child(pushKey);
	}
}