using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfGravity : MonoBehaviour {
	
	public float rotationSpeed;
	private Vector3 rotationDegree;

	void Start () {
		
	}
	
	void Update () {

		rotationDegree = new Vector3(0, 0, rotationSpeed * Time.deltaTime);
		transform.Rotate(rotationDegree);
	}
}
