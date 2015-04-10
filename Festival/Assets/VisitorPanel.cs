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

	public Text cashSpent;

	VisitorController visitor;

	public void SetStats(VisitorController visitorController){

		visitor = visitorController;
	}

	void Update(){
		if (visitor != null) {
			overallSlider.value = (float)visitor.overallHapiness/100;
			name.text = visitor.name;
			hungerSlider.value = (float)visitor.hunger.value / 100;
			funSlider.value = (float)visitor.fun.value / 100;
			sleepSlider.value = (float)0.5f;
			hygieneSlider.value = (float)visitor.hygiene.value/100;
			thirstSlider.value = (float)visitor.thirst.value/100;
			bladderSlider.value = (float)visitor.bladder.value/100;
		
			cashSpent.text = "Cash spent: " + visitor.cashSpent.ToString ();
		}
	}

	public void Close(){
		gameObject.SetActive(false);
	}

	void Start(){
		gameObject.SetActive (false);
	}
}
