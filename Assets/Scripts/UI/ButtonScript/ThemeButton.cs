using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThemeButton : MonoBehaviour {
	
	private SubjectManager subjectManager;

	void Start () {

		subjectManager = GameObject.FindObjectOfType<SubjectManager>();
	}

	public void GetThemeName () {

		subjectManager.historySubjects.Clear();
		subjectManager.characteristicSubjects.Clear();
		subjectManager.physicSubjects.Clear();
		CurrentInstance.currentThemeName = this.GetComponentInChildren<Text>().text;
		
		if(this.tag == "Historia") {
			CurrentInstance.currentThemeName = "Historia";
			subjectManager.AddHistorySubject();
			/*subjectManager.historySubjects.ForEach(print);*/
		}
		else if(this.tag == "Caracteristicas") {
			CurrentInstance.currentThemeName = "Caracteristicas";
			subjectManager.AddCharateristicSubject();
			/*subjectManager.characteristicSubjects.ForEach(print);*/
		}
		else if(this.tag == "Fisica") {
			CurrentInstance.currentThemeName = "Fisica";
			/*subjectManager.physicSubjects.ForEach(print);*/
		}
	}
	
}
