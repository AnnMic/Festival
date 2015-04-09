using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisitorPanel : MonoBehaviour {
	public Slider overallSlider;  
	public Text name;

	public Slider hungerSlider;  
	public Slider funSlider;  
	public Slider sleepSlider;  
	public Slider hygieneSlider;  
	public Slider thirstSlider;  
	public Slider bladderSlider;  

	public void SetStats(float overallHapiness, string stringName, float hunger, float fun, float sleep, float hygiene, float thirst, float bladder){

		overallSlider.value = overallHapiness;
		name.text = stringName;
		hungerSlider.value = hunger;
		funSlider.value = fun;
		sleepSlider.value = sleep;
		hygieneSlider.value = hygiene;
		thirstSlider.value = thirst;
		bladderSlider.value = bladder;
	}

	public void Close(){
		gameObject.SetActive(false);
	}

	void Start(){
		gameObject.SetActive (false);
	}
}
