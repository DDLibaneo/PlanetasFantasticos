using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleName : MonoBehaviour {

	private Text text;

	void Start () {
		
		/*Debug.Log(gameObject.tag);*/
		if (gameObject.tag == "TitlePlanet") {
			/*Debug.Log("Achei a tag TitlePlanet");*/
			text = this.GetComponent<Text>();
			text.text = CurrentInstance.currentPlanetName;
		}
		else if (gameObject.tag == "TitleTheme") {
			/*Debug.Log("Achei a tag TitleTheme");*/
			text = this.GetComponent<Text>();
			text.text = CurrentInstance.currentThemeName;
		}
		else if (gameObject.tag == "TitleSubject") {
			/*Debug.Log("Achei a tag TitleSubject");*/
			text = this.GetComponent<Text>();
			text.text = CurrentInstance.currentSubjectName;
		}
	}
}
