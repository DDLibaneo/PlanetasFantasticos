using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Router : MonoBehaviour {
	// Root reference to our project
	public static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;

	public static DatabaseReference Players () {

		return baseRef.Child("players");
	}

		public static DatabaseReference PlayerWithUID (string uid) { // Will look up the player with the uid we pass in
		
		return baseRef.Child("players").Child(uid);
	}

	public static DatabaseReference Planet (string planetName) {

		return baseRef.Child("Planets").Child(planetName);
	}

	public static DatabaseReference Planets () {

		return baseRef.Child("Planets");
	}

	public static DatabaseReference Theme (string planet, string theme) {

		return Planet(planet).Child("Themes").Child(theme);
	}

	public static DatabaseReference Themes (string planet) {
		
		return Planets().Child(planet).Child("Themes");
	}

	public static DatabaseReference Subject (string planet, string theme, string subject) {

		return Theme(planet, theme).Child("Subjects").Child(subject);
	}

	public static DatabaseReference Subjects (string planet, string theme) {

		return Theme(planet, theme).Child("Subjects");
	}

	public static DatabaseReference ExplanationParagraphs (string planet, string theme, string subject) {
		
		return Subject(planet, theme, subject).Child("Explanation");
	}
	
	public static DatabaseReference Questions (string planet, string theme, string subject) {

		return Subject(planet, theme, subject).Child("Questions");
	}


}