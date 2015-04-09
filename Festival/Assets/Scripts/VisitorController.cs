using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class VisitorController : MonoBehaviour {

	List<Need> sortedNeeds = new List<Need>();

	Need highestPriority;
	public Needs currentNeed;

	GameObject target;

	public float overallHapiness;
	string name = "Chuck Norris";

	public GameObject visitorPanel;

	Need bladder;
	Need hunger;
	Need hygiene;
	Need fun;

	SceneObject sceneObject;

	// Use this for initialization
	void Start () {
		target = gameObject;

		bladder = gameObject.AddComponent<Need> ();
		hunger = gameObject.AddComponent<Need>();
		hygiene = gameObject.AddComponent<Need> ();
		fun = gameObject.AddComponent<Need>();

		GameObject map = GameObject.FindGameObjectWithTag ("Map");
		sceneObject = map.GetComponent<SceneObject> ();

		bladder.CreateNeed (Needs.BLADDER, Random.Range(1f, 5f));
		sortedNeeds.Add (bladder);

		hunger.CreateNeed (Needs.HUNGER, Random.Range(0.5f, 2f));
		sortedNeeds.Add (hunger);

		hygiene.CreateNeed (Needs.HYGIENE, Random.Range(0.5f, 1f));
		sortedNeeds.Add (hygiene);

		fun.CreateNeed (Needs.FUN, Random.Range(1f, 5f));
		sortedNeeds.Add (fun);
		InvokeRepeating("UpdateNeed", 2, 0.3F);

		highestPriority = fun;
	}

	void UpdateNeed(){
		sortedNeeds = sortedNeeds.OrderBy(o=>o.value).ToList();
		if (highestPriority != sortedNeeds.First () || highestPriority == null) {
			highestPriority = sortedNeeds.First ();
			MoveTowards ();
			currentNeed = highestPriority.need;
		}
		CalculateOverallHapiness ();
	}

	void MoveTowards(){
		int random = 0;
		switch (highestPriority.need)
		{
		case Needs.BLADDER:
			if(sceneObject.bladderObjects.Count > 0)
				Debug.Log("count" + sceneObject.bladderObjects.Count);
				random = Random.Range(0, sceneObject.bladderObjects.Count);
				Debug.Log("random"+ random);
				target = sceneObject.bladderObjects[random];
			break;
		case Needs.HUNGER:
			if(sceneObject.bladderObjects.Count > 0)
				target = sceneObject.hungerObjects[Random.Range(0, sceneObject.hungerObjects.Count)];
			break;
		case Needs.FUN:			
			if(sceneObject.bladderObjects.Count > 0)
				target = sceneObject.funObjects[Random.Range(0, sceneObject.funObjects.Count)];
			break;
		case Needs.HYGIENE:
			if(sceneObject.bladderObjects.Count > 0)
				target = sceneObject.hygieneObjects[Random.Range(0, sceneObject.hygieneObjects.Count)];
			break;
		default:
			Debug.Log("Move to default: fun");
			if(sceneObject.bladderObjects.Count > 0)
				target = sceneObject.funObjects[Random.Range(0, sceneObject.funObjects.Count)];

			break;
		}
	}

	private void CalculateOverallHapiness() {
		float total = 0;
		foreach (Need need in sortedNeeds){
			total += need.value;
		}
		overallHapiness = total / (float)sortedNeeds.Count;
	}

	void Update() {
		float step = 3.0f * Time.deltaTime;

		transform.position = Vector3.MoveTowards (this.gameObject.transform.position, target.transform.position, step);
		if (transform.position == target.transform.position) {
			highestPriority.value = 100;
		}
		transform.LookAt (target.transform.position);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag==currentNeed.ToString()){
			highestPriority.value = 100;
		}
	}

	void OnMouseDown() {
		visitorPanel.SetActive (true);
		VisitorPanel panel = visitorPanel.GetComponent<VisitorPanel> ();
		panel.SetStats (overallHapiness / 100, name, hunger.value, fun.value,0.5f,hygiene.value,0.5f,bladder.value);
	}
}
