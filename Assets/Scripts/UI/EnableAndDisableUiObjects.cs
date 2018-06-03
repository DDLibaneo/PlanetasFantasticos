using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*O objetivo desta classe é ativar e desativar objetos UI
de acordo com a necessidade da aplicação */

public class EnableAndDisableUiObjects : MonoBehaviour {
	ExplanationManager explanationManager; 

	private void OnLevelWasLoaded (){
       
	   if(SceneManager.GetActiveScene().name == "05Aprendizado") {
		  	
			explanationManager = GameObject.FindObjectOfType<ExplanationManager>();
        }
    }

	public void DisableNextPrevExplanationButtons () {
		Button[] nextPrevButtons;
		nextPrevButtons = GameObject.FindObjectsOfType<Button>();
				
		foreach (Button button in nextPrevButtons) {
			
			if (button.name == "BtnNextExplanation" || button.name == "BtnPrevExplanation") {

				button.GetComponent<Image>().enabled = false;
				button.GetComponent<Button>().enabled = false;
				button.GetComponentInChildren<Text>().enabled = false;	
			}
		}
	}

	public void EnableNextPrevExplanationButtons () {
		Button[] nextPrevButtons;
		nextPrevButtons = GameObject.FindObjectsOfType<Button>();
				
		foreach (Button button in nextPrevButtons) {
			
			if (button.name == "BtnNextExplanation" || button.name == "BtnPrevExplanation") {

				button.GetComponent<Image>().enabled = true;
				button.GetComponent<Button>().enabled = true;
				button.GetComponentInChildren<Text>().enabled = true;	
			}
		}
	}	

	public void EnableNexPrevQuestionButtons () {
		Button[] nextPrevButtons;
		nextPrevButtons = GameObject.FindObjectsOfType<Button>();

		foreach (Button button in nextPrevButtons) {

			if(button.name == "BtnNextQuestion" || button.name == "BtnPrevQuestion") {

				button.GetComponent<Image>().enabled = true;
				button.GetComponent<Button>().enabled = true;
				button.GetComponentInChildren<Text>().enabled = true;
			}
		}
	}	

	public void DisableNexPrevQuestionButtons () {
		Button[] nextPrevButtons;
		nextPrevButtons = GameObject.FindObjectsOfType<Button>();

		foreach (Button button in nextPrevButtons) {

			if(button.name == "BtnNextQuestion" || button.name == "BtnPrevQuestion") {

				button.GetComponent<Image>().enabled = false;
				button.GetComponent<Button>().enabled = false;
				button.GetComponentInChildren<Text>().enabled = false;
			}
		}
	}

	public void EnablePreviousQuestionButton () {
		Button[] nextPrevButtons;
		nextPrevButtons = GameObject.FindObjectsOfType<Button>();

		foreach (Button button in nextPrevButtons) {

			if(button.name == "BtnPrevQuestion") {

				button.GetComponent<Image>().enabled = true;
				button.GetComponent<Button>().enabled = true;
				button.GetComponentInChildren<Text>().enabled = true;
			}
		}
	}

	public void DisablePreviousQuestionButton () {
		Button[] nextPrevButtons;
		nextPrevButtons = GameObject.FindObjectsOfType<Button>();

		foreach (Button button in nextPrevButtons) {

			if(button.name == "BtnPrevQuestion") {

				button.GetComponent<Image>().enabled = false;
				button.GetComponent<Button>().enabled = false;
				button.GetComponentInChildren<Text>().enabled = false;
			}
		}
	}

	public void EnableParagraphCounter () {
		
		explanationManager.GetTotalParagraphs().GetComponent<Text>().enabled = true;
	}

	public void DisableParagraphCounter () {

		explanationManager.GetTotalParagraphs().GetComponent<Text>().enabled = false;		
	}

	public void EnableQuestionCounter () {

		explanationManager.GetTotalQuestions().GetComponent<Text>().enabled = true;
	}

	public void DisableQuestionCounter () {

		explanationManager.GetTotalQuestions().GetComponent<Text>().enabled = false; 
	}
}