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
	private GameObject toggleAnswers;
	private GameObject[] alternativas;
	private DataGetter dataGetter;
	
	private int questionCounter = 0, paragraphCounter = 0;
	private List<Explanation> explanationParagraph = new List<Explanation>();
	private List<Question> questions = new List<Question>();	
	
	private ExplanationParagraphAdder explanationParagraphAdder;

	private void OnLevelWasLoaded () {
    
	   if (SceneManager.GetActiveScene().name == "05Aprendizado") {
		  	
			contentTeoria = GameObject.FindGameObjectWithTag(ETags.tagContentTeoria);
			totalParagraphs = GameObject.FindGameObjectWithTag(ETags.tagTotalParagraphs);
			totalQuestions = GameObject.FindGameObjectWithTag(ETags.tagTotalQuestions);

			dataGetter = GameObject.FindObjectOfType<DataGetter>().GetComponent<DataGetter>();
			TriggerExplanation();
	  }
  } 

	private void TriggerExplanation () {
		
		explanationParagraph.Clear();
		
		DatabaseManager.sharedInstance.GetExplanationParagraphs(result => {			
			explanationParagraph = result;
			
			//Debug.Log(explanationParagraph.Count);
			StartExplanation();
		}, StringManager.RemoveAllAnnoyingCharacters(CurrentInstance.currentPlanetName, false), 
			StringManager.RemoveAllAnnoyingCharacters(CurrentInstance.currentThemeName, false), 
			StringManager.RemoveAllAnnoyingCharacters(CurrentInstance.currentSubjectName, false)
		);	
  }

	private void StartExplanation () {
        
		contentTeoria.GetComponentInChildren<Text>().text = explanationParagraph[0].explanation;
		totalParagraphs.GetComponent<Text>().text = "1" + " / " + (explanationParagraph.Count);
	}

	public void DisplayNextSentence () {

		if (paragraphCounter < explanationParagraph.Count - 1) {
			paragraphCounter++;
		}
		
		if (paragraphCounter < explanationParagraph.Count && paragraphCounter >= 0) {
						
			contentTeoria.GetComponentInChildren<Text>().text = explanationParagraph[paragraphCounter].explanation;
			totalParagraphs.GetComponent<Text>().text = (paragraphCounter + 1) + " / " + (explanationParagraph.Count);
		}
	}

	public void DisplayPreviousSentence () {
	
		if (paragraphCounter >= 1) {
			paragraphCounter--;
		}
		if (paragraphCounter < explanationParagraph.Count && paragraphCounter >= 0) {
			//Debug.Log(explanationParagraph[i]);
			contentTeoria.GetComponentInChildren<Text>().text = explanationParagraph[paragraphCounter].explanation;
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
			contentQuestion.GetComponentInChildren<Text>().text = questions[questionCounter].question;
			totalQuestions.GetComponentInChildren<Text>().text = (questionCounter + 1) + " / " + (questions.Count);
		}
	}

	public void DisplayPreviousQuestion () {
		if (questionCounter >= 1) {
			questionCounter--;
		}
		if (questionCounter < questions.Count && questionCounter >= 0) {
			contentQuestion.GetComponentInChildren<Text>().text = questions[questionCounter].question;
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
		int counterAnswers = 0, counterQuestions = 0;

		toggleAnswers = GameObject.FindGameObjectWithTag(ETags.tagToggleResposta);
		alternativas = GameObject.FindGameObjectsWithTag(ETags.tagAlternativas);

		questions.Clear();
		
		DatabaseManager.sharedInstance.GetQuestions(result => {
			questions	= result;

			contentQuestion.GetComponentInChildren<Text>().text = questions[0].question;
			totalQuestions.GetComponent<Text>().text = "1" + " / " + (questions.Count);
			
			for (counterQuestions = 0; counterQuestions < questions.Count; counterQuestions++)
			{
				foreach (GameObject item in alternativas)
				{
						item.GetComponentInChildren<Text>().text = questions[counterQuestions].answers[counterAnswers].answer;
						item.GetComponentInChildren<AlternativeAnswer>().answer = questions[counterQuestions].answers[counterAnswers];
						counterAnswers++;
				}
			}
			
		}, StringManager.RemoveAllAnnoyingCharacters(CurrentInstance.currentPlanetName, false), 
		StringManager.RemoveAllAnnoyingCharacters(CurrentInstance.currentThemeName, false), 
		StringManager.RemoveAllAnnoyingCharacters(CurrentInstance.currentSubjectName, false));		
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

		public void GetExplanations() {

	}
}