using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjButton : MonoBehaviour {
	 
	public void GetSubjectName () {		
		
		CurrentInstance.currentSubjectName = this.GetComponentInChildren<Text>().text;
	}
	
}
