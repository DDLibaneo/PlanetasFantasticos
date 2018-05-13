using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNodesTest : MonoBehaviour {
	public List<Planet> planetList = new List<Planet>();
	public List<Explanation> paragraphs = new List<Explanation>();
	void Awake () {

	}

	public void GetPlanetNodes() {
		planetList.Clear();
		
		DatabaseManager.sharedInstance.GetPlanets(result => {
			planetList = result;	
			foreach (var item in planetList)
			{
				Debug.Log(item.planet);
			}
		});
		
	}

	public void GetExplanations() {
		paragraphs.Clear();
		
		DatabaseManager.sharedInstance.GetExplanation(result => {			
			paragraphs = result;
			foreach (var item in paragraphs)
			{
				Debug.Log(item.explanation);
			}
		});
		
	}
}
