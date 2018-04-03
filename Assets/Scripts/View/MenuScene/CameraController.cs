using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public float panSpeed = 20f;
	private Vector3 pos;

	void Start () {
		
	}
	
	void Update () {
	
		zoomCamera();
		moveCamera();
	}

	void zoomCamera(){
		
		getScroll();
		getPlusMinus();
	}

	void moveCamera(){
		
		getWASD();
		getArrows();
	}

	private void getScroll(){
		
		if(Input.GetAxis("Mouse ScrollWheel") > 0) {
			zoomIn();
		}
		else if(Input.GetAxis("Mouse ScrollWheel") < 0) {
			zoomOut();
		}
	}

	private void getPlusMinus(){

		if(Input.GetKey(KeyCode.Plus)) {
			zoomIn();			
		}
		else if(Input.GetKey(KeyCode.Minus)) {
			zoomOut();
		}
		else if(Input.GetKey(KeyCode.KeypadPlus)) {
			zoomIn();
		}
		else if(Input.GetKey(KeyCode.KeypadMinus)) {
			zoomOut();
		}
 	}

	private void zoomIn() {

		if(this.GetComponent<Camera>().orthographicSize > 7) {
				this.GetComponent<Camera>().orthographicSize--; 
		}
	}

	private void zoomOut(){

		if(this.GetComponent<Camera>().orthographicSize < 45) {
				this.GetComponent<Camera>().orthographicSize++; 
			}
	}

	private void getWASD() {
		
		pos = this.transform.position;
		if(Input.GetKey(KeyCode.W)) {
			pos.y += panSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)) {
			pos.y -= panSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)) {
			pos.x -= panSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D)) {
			pos.x += panSpeed * Time.deltaTime;
		}
		this.transform.position = pos;
	}

	private void getArrows() {

		pos = this.transform.position;
		if(Input.GetKey(KeyCode.UpArrow)) {
			pos.y += panSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			pos.y -= panSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			pos.x -= panSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.RightArrow)) {
			pos.x += panSpeed * Time.deltaTime;
		}
		this.transform.position = pos;
	}
}
