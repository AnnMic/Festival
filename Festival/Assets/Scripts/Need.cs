using UnityEngine;
using System.Collections;

public enum Needs {
	HUNGER, 
	BLADDER, 
	HYGIENE, 
	FUN,
	SLEEP,
	THIRST,
	GOHOME
};

public class Need : MonoBehaviour {

	public Needs need = Needs.HYGIENE;
	public float decrease = 1f;
	public float value = 70f;


	// Use this for initialization
	public void CreateNeed (Needs type, float decreaseRate ) {
		need = type;
		value = 70f;
		decrease = decreaseRate;
		InvokeRepeating("UpdateNeed", 2, 5);

	}

	void UpdateNeed(){
		value -= decrease;

	}
}
