using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Planet {
  
  public string planet;

  public Planet (string planet) {
    this.planet = planet;
  }

  public Planet (IDictionary<string, object> dictionary) {
    this.planet = dictionary["planet"].ToString();
  }
}
