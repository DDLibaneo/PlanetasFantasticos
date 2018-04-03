using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

public class Player {
	
	//class properties
	public string email;
	public int score;
	public int level;

	public Player (string email, int score, int level) {
		this.email = email;
		this.score = score;
		this.level = level;
	}

	public Player (IDictionary<string, object> dictionary) {
		// all values on the dictionaries are objects, so convert them to string and int
		this.email = dictionary["email"].ToString();
		this.score = Convert.ToInt32(dictionary["score"]);
		this.level = Convert.ToInt32(dictionary["level"]);
	}
}
