using UnityEngine;
using System.Collections;

public class StarsInConcertController : MonoBehaviour {

	public float switchDelay;

	private int currentPerformer = 0;
	private GameObject[] starsInConcert;

	void Awake(){
		starsInConcert = new GameObject[transform.childCount];
		for (int i=0; i<transform.childCount; i++){
			starsInConcert[i] = transform.GetChild(i).gameObject;
		}
		currentPerformer = Random.Range(0, starsInConcert.Length);
	}

	void Start(){
		starsInConcert[currentPerformer].SetActive(true);
		StartCoroutine(SwitchPerformer(switchDelay));
	}

	private IEnumerator SwitchPerformer(float delay){
		yield return new WaitForSeconds(delay);
		starsInConcert[currentPerformer].SetActive(false);
		currentPerformer = Random.Range(0, starsInConcert.Length);
		starsInConcert[currentPerformer].SetActive(true);
		StartCoroutine(SwitchPerformer(switchDelay));
	}
}
