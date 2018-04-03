using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetButton : MonoBehaviour {

	private LevelManager levelManager;
	public string planetName;

	void Start () {
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnMouseDown() {

		//print("clique");
		levelManager.LoadLevel("02Planeta");
		CurrentInstance.currentPlanetName = planetName;
	}
}
