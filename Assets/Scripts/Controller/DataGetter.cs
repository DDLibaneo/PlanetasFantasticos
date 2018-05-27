using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataGetter : MonoBehaviour {
	public List<Planet> planets = new List<Planet>();
	public List<Explanation> paragraphs = new List<Explanation>();
	public List<Theme> themes = new List<Theme>();
	public List<Subject> subjects = new List<Subject>();
	public List<Question> questions = new List<Question>();
	public List<string> answers = new List<string>();

	void Start () {
		
		//GetPlanetNodes();
		//GetThemeNodes();
		//GetSubjectNodes();
		//GetQuestions();
		//GetAnswers();
	}

	void OnLevelWasLoaded (){
		//Bora chamar o questions por aqui, que nem no ExplanationManager
		if (SceneManager.GetActiveScene().name == "05Aprendizado") {
			GetExplanations();
		}
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
		}, StringManager.RemoveDiacritics(CurrentInstance.currentPlanetName), 
		StringManager.RemoveDiacritics(CurrentInstance.currentThemeName));
	}

	public void GetExplanations() {
		paragraphs.Clear();
		
		DatabaseManager.sharedInstance.GetExplanationParagraphs(result => {			
			paragraphs = result;
			
			foreach (var item in paragraphs)
			{
				Debug.Log(item.explanation);
			}
		}, StringManager.RemoveDiacritics(CurrentInstance.currentPlanetName), 
		StringManager.RemoveDiacritics(CurrentInstance.currentThemeName), 
		StringManager.RemoveDiacritics(CurrentInstance.currentSubjectName));	
	}

	public void GetQuestions() {
		questions.Clear();
		
		DatabaseManager.sharedInstance.GetQuestions(result => {
			questions	= result;
			foreach (var question in questions)
			{
				Debug.Log(question.question);
				foreach (var answer in question.answers)
				{
						Debug.Log(answer.answer);
						Debug.Log(answer.isCorrect);
				}
			}
		}, StringManager.RemoveDiacritics(CurrentInstance.currentPlanetName), 
		StringManager.RemoveDiacritics(CurrentInstance.currentThemeName), 
		StringManager.RemoveDiacritics(CurrentInstance.currentSubjectName));
	}

	public void GetAnswers() {
		answers.Clear();

		DatabaseManager.sharedInstance.GetAnswers(result => {
			answers	= result;
			foreach (var item in answers)
			{
				
			}
		}, "Jupiter", "Historia", "Exploracao");

	}
}
