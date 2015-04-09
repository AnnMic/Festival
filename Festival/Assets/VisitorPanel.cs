using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VisitorPanel : MonoBehaviour {
	public Slider overallSlider;  
	public Text name;  

	public void SetStats(float overallHapiness, string stringName){

		overallSlider.value = overallHapiness;
		name.text = stringName;

	}

	public void Close(){
		gameObject.SetActive(false);
	}
}
