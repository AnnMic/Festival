using UnityEngine;
using System.Collections;

public enum Needs {
	HUNGER, 
	BLADDER, 
	HYGIENE, 
	FUN 
};

public class Need : MonoBehaviour {

	public Needs need = Needs.HYGIENE;
	public float decrease = 1f;
	public float value = 100f;


	// Use this for initialization
	public void CreateNeed (Needs type, float decreaseRate ) {
		need = type;
		value = 100f;
		decrease = decreaseRate;
		InvokeRepeating("UpdateNeed", 2, 5);

	}

	void UpdateNeed(){
		value -= decrease;

	}
}
