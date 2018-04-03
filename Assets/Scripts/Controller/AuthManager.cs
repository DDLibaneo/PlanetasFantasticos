using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour {

	// Firebase API variables
	Firebase.Auth.FirebaseAuth auth;

	//Delegates
	/* 
		-AuthCallBack passes information back and forth 
		-Task<> the <> is casting the task to a firebase task
		-'task' is the task name
		-The point of this callback is to pass a task and a string communicating what the operation is returning
	*/
	public delegate IEnumerator AuthCallBack(Task<Firebase.Auth.FirebaseUser> task, string operation); 
	public event AuthCallBack authCallBack;

	void Awake () {
		auth = FirebaseAuth.DefaultInstance;
	}

	public void SignUpNewUser (string email, string password) {
		auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			StartCoroutine(authCallBack(task, "sign_up"));
		});
	}

	public void LogInExistingUser (string email, string password) {
		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
			StartCoroutine(authCallBack(task, "login"));
		});
	}
}
