using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNodesTest : MonoBehaviour {
	public List<Planet> planets = new List<Planet>();
	public List<Explanation> paragraphs = new List<Explanation>();
	public List<Theme> themes = new List<Theme>();
	public List<Subject> subjects = new List<Subject>();
	public List<Question> questions = new List<Question>();

	void Start () {
		
		//GetPlanetNodes();
		//GetThemeNodes();
		//GetSubjectNodes();
		//GetExplanations();
		GetQuestions();
	}

	public void GetPlanetNodes() {
		planets.Clear();
		
		DatabaseManager.sharedInstance.GetPlanets(result => {
			planets = result;	
			foreach (var item in planets)
			{
				Debug.Log(item.planet);
			}
		});
	}

	public void GetThemeNodes() {
		themes.Clear();
		
		DatabaseManager.sharedInstance.GetThemes(result => {
			themes = result;	
			foreach (var item in themes)
			{
				Debug.Log(item.theme);
			}
		});
	}

	public void GetSubjectNodes() {
		subjects.Clear();
		
		DatabaseManager.sharedInstance.GetSubjects(result => {
			subjects = result;	
			foreach (var item in subjects)
			{
				Debug.Log(item.subject);
			}
		}, "Jupiter", "Historia");
	}

	public void GetExplanations() {
		paragraphs.Clear();
		
		DatabaseManager.sharedInstance.GetExplanationParagraphs(result => {			
			paragraphs = result;
			foreach (var item in paragraphs)
			{
				Debug.Log(item.explanation);
			}
		}, "Jupiter", "Historia", "Exploracao");	
	}

	public void GetQuestions() {
		questions.Clear();
		
		DatabaseManager.sharedInstance.GetQuestions(result => {
			questions	= result;
			Debug.Log("Entrei");
			foreach (var item in questions)
			{
				Debug.Log("Entrei");
				Debug.Log(item.question);
			}
		}, "Jupiter", "Historia", "Exploracao");
	}
}
