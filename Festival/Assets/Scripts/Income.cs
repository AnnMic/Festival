using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Income : MonoBehaviour {

	Text text;
	public int cash = 5000;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "Cash: " + cash.ToString ();
	}

	public void DeductCash(int value){
		cash -= value;
		text.text = "Cash: " + cash.ToString ();
	}
	public void AddCash(int value){
		cash += value;
		text.text = "Cash: " + cash.ToString ();
	}
}
