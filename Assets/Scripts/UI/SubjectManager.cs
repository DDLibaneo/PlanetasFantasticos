using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class SubjectManager : MonoBehaviour {
	//public static SubjectManager instance;
	private GameObject contentManager;
	public List<string> physicSubjects, characteristicSubjects, historySubjects;
	private int listSize, i = 0, j = 0;

	private void Awake() {

		if(SceneManager.GetActiveScene().name == "04Assunto") {
			
			contentManager = GameObject.FindGameObjectWithTag("SubjectContent");			
			PopulateSubjectButtons();			
		}
	}

	private void Start() {

		physicSubjects = new List<string>();
		characteristicSubjects = new List<string>();
		historySubjects = new List<string>();
	}

	private void PopulateSubjectButtons() {

		if(CurrentInstance.currentThemeName == "Fisica") {
			AddPhysicSubject();
			listSize = physicSubjects.Count;
			for(i = 0; i < listSize; i++) {
				contentManager.transform.GetChild(i).gameObject.SetActive(true);
			}
			foreach(Transform button in contentManager.transform) {
				if(button.gameObject.activeInHierarchy){
					button.GetComponentInChildren<Text>().text = physicSubjects[j++];
				}
			}
			j = 0;
		} 
		else if(CurrentInstance.currentThemeName == "Caracteristicas") {
			AddCharateristicSubject();
			listSize = characteristicSubjects.Count;
			for(i = 0; i < listSize; i++){
				contentManager.transform.GetChild(i).gameObject.SetActive(true);
			}
			foreach(Transform button in contentManager.transform) {
				if(button.gameObject.activeInHierarchy) {
					button.GetComponentInChildren<Text>().text = characteristicSubjects[j++];
				}
			}
			j = 0;
		}
		else if(CurrentInstance.currentThemeName == "Historia") {
			AddHistorySubject();
			listSize = historySubjects.Count;
			for(i = 0; i < listSize; i++){
				contentManager.transform.GetChild(i).gameObject.SetActive(true);
			}
			foreach(Transform button in contentManager.transform) {
				if(button.gameObject.activeInHierarchy) {
					button.GetComponentInChildren<Text>().text = historySubjects[j++];
				}
			}
			j = 0;
		}
	}

	public void AddPhysicSubject () {
		/*Physics*/
		if(CurrentInstance.currentPlanetName == "Marte"){
			physicSubjects.Add("Excentricidade");	
		}
		else{
			physicSubjects.Add("Rotação");
		}
		physicSubjects.Add("Órbita");
		physicSubjects.Add("Astros Influentes");
		physicSubjects.Add("Astros Influentes 2");
	}

	public void AddCharateristicSubject () {
		/*Characteristics*/
		if(CurrentInstance.currentPlanetName == "Jupiter" || CurrentInstance.currentPlanetName == "Saturno" || CurrentInstance.currentPlanetName == "Urano" || CurrentInstance.currentPlanetName == "Netuno") {
			characteristicSubjects.Add("Composição Química");
		}
		else { 
			characteristicSubjects.Add("Geografia");
		}
		characteristicSubjects.Add("Aparência");
		characteristicSubjects.Add("Clima");
	}

	public void AddHistorySubject () {
		/*History*/
		historySubjects.Add("Primeiras Observações");
		if(CurrentInstance.currentPlanetName == "Marte") {
			historySubjects.Add("Canais");
		}
		else {
			historySubjects.Add("Mitos");
		}
		historySubjects.Add("Exploração");
	}
}