using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NodePath {
	
	public string Planet { get; set; }
	public string Theme { get; set; }
	public string Subject { get; set; }

	public NodePath() {

	}

	public NodePath (string Planet, string Theme, string Subject) {
		this.Planet = Planet;
		this.Theme = Theme;
		this.Subject = Subject;
	}

	public NodePath (string Planet, string Theme) {
		this.Planet = Planet;
		this.Theme = Theme;
	}

	public NodePath (string Planet) {
		this.Planet = Planet;
	}
}