using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
  
[System.Serializable]
public static class CurrentInstance {
//fazer desta classe um Singleton ou usar outro design pattern (i.e state pattern)       
	public static string currentPlanetName; 
	public static string currentThemeName;
	public static string currentSubjectName;    
}