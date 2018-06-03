using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour {
	private GameObject[] alternativas;
	private GameObject checkedAlternative;
	
	public void CheckAnswer () {

		alternativas = GameObject.FindGameObjectsWithTag(ETags.tagAlternativas);
		foreach (GameObject alternativa in alternativas) {		
			if (alternativa.GetComponentInChildren<Toggle>().isOn) {

				if (alternativa.GetComponentInChildren<AlternativeAnswer>().answer.isCorrect) {
					Debug.Log("HORRAAAAYYY");
				}	
				else {
					Debug.Log("OH NO :(");
				}
			}
		}
	}
}
