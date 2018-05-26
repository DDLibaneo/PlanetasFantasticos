using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExplanationManager : MonoBehaviour {
	private GameObject contentTeoria;
	private GameObject contentQuestion;
	private GameObject totalParagraphs;
	private GameObject totalQuestions;
	private DataGetter dataGetter;
	
	private int questionCounter = 0, paragraphCounter = 0;
	private List<string> explanationParagraph = new List<string>();
	private List<string> questions = new List<string>();	
	
	private ExplanationParagraphAdder explanationParagraphAdder;
	//private QuestionAdderSwitch questionAdderSwitch;

	private void OnLevelWasLoaded () {
       
	   if (SceneManager.GetActiveScene().name == "05Aprendizado") {
		  	
			contentTeoria = GameObject.FindGameObjectWithTag("ContentTeoria");
			//explanationParagraphAdder = GetComponent<ExplanationParagraphAdder>();
			//questionAdderSwitch = GetComponent<QuestionAdderSwitch>();
			totalParagraphs = GameObject.FindGameObjectWithTag("TotalParagraphs");
			totalQuestions = GameObject.FindGameObjectWithTag("TotalQuestions");

			dataGetter = GameObject.FindObjectOfType<DataGetter>();
			TriggerExplanation();
	  }
  } 

	private void TriggerExplanation () {
		
		//explanationParagraphAdder.AddExplanationParagraph(explanationParagraph);

		StartExplanation();
  }

	private void StartExplanation () {
        
		contentTeoria.GetComponentInChildren<Text>().text = explanationParagraph[0];
		totalParagraphs.GetComponent<Text>().text = "1" + " / " + (explanationParagraph.Count);
		Debug.Log("Contagem de parágrafos: " + explanationParagraph.Count);
	}

	public void DisplayNextSentence () {
		//changed i to paragraphCounter and questionCounter
		if (paragraphCounter < explanationParagraph.Count - 1) {
			paragraphCounter++;
		}
		if (paragraphCounter < explanationParagraph.Count && paragraphCounter >= 0) {
						
			contentTeoria.GetComponentInChildren<Text>().text = explanationParagraph[paragraphCounter];
			totalParagraphs.GetComponent<Text>().text = (paragraphCounter + 1) + " / " + (explanationParagraph.Count);
		}
		//Debug.Log("Contagem de parágrafos: " + explanationParagraph.Count);
	}

	public void DisplayPreviousSentence () {
	
		if (paragraphCounter >= 1) {
			paragraphCounter--;
		}
		if (paragraphCounter < explanationParagraph.Count && paragraphCounter >= 0) {
			//Debug.Log(explanationParagraph[i]);
			contentTeoria.GetComponentInChildren<Text>().text = explanationParagraph[paragraphCounter];
			totalParagraphs.GetComponent<Text>().text = (paragraphCounter + 1) + " / " + (explanationParagraph.Count);
		}
		//Debug.Log("Contagem de parágrafos: " + explanationParagraph.Count);
	}

	public void DisplayNextQuestion () {
		if (questionCounter < questions.Count - 1) {
			questionCounter++;
			Debug.Log("");
		}
		if (questionCounter < questions.Count && questionCounter >= 0) {
			contentQuestion.GetComponentInChildren<Text>().text = questions[questionCounter];
			totalQuestions.GetComponentInChildren<Text>().text = (questionCounter + 1) + " / " + (questions.Count);
		}
	}

	public void DisplayPreviousQuestion () {
		if (questionCounter >= 1) {
			questionCounter--;
		}
		if (questionCounter < questions.Count && questionCounter >= 0) {
			contentQuestion.GetComponentInChildren<Text>().text = questions[questionCounter];
			totalQuestions.GetComponentInChildren<Text>().text = (questionCounter + 1) + " / " + (questions.Count);
		}
	}

	public void FindQuestionObjects () {

		contentQuestion = GameObject.FindGameObjectWithTag("ContentQuestao");
		if(GameObject.FindGameObjectWithTag("ToggleQuestao").GetComponent<Toggle>().isOn) {
			
			TriggerQuestion();
		} 
	}

	private void TriggerQuestion () {
		//Esta é Chamada no final da FindQuestionObjects
		//questionAdderSwitch.AddQuestionSwitch(questions); /*Passar objeto Question*/
		Debug.Log(questions[0]);
		contentQuestion.GetComponentInChildren<Text>().text = questions[0];
		totalQuestions.GetComponent<Text>().text = "1" + " / " + (questions.Count);
	}

	public void ClearQuestionsList () {
		questions.Clear();
	}

	public GameObject GetTotalParagraphs () {
		
		return totalParagraphs;
	}

	public GameObject GetTotalQuestions () {

		return totalQuestions;
	}
}