using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class VisitorController : MonoBehaviour {

	List<Need> sortedNeeds = new List<Need>();

	Need highestPriority;
	public Needs currentNeed;

	GameObject target;

	// Use this for initialization
	void Start () {
		target = gameObject;

		Need bladder = gameObject.AddComponent<Need>();
		Need hunger = gameObject.AddComponent<Need>();
		Need hygiene = gameObject.AddComponent<Need>();
		Need fun = gameObject.AddComponent<Need>();


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

	}

	void MoveTowards(){

		switch (highestPriority.need)
		{
		case Needs.BLADDER:
			target = GameObject.FindGameObjectWithTag("BLADDER");
			break;
		case Needs.HUNGER:
			target = GameObject.FindGameObjectWithTag("HUNGER");
			break;
		case Needs.FUN:
			target = GameObject.FindGameObjectWithTag("FUN");
			break;
		case Needs.HYGIENE:
			target = GameObject.FindGameObjectWithTag("HYGIENE");
			break;
		default:
			Debug.Log("Move to default: fun");
			target = GameObject.FindGameObjectWithTag("FUN");

			break;
		}
	}

	void Update(){
		float step = 7.0f * Time.deltaTime;

		transform.position = Vector3.MoveTowards (this.gameObject.transform.position, target.transform.position, step);
		if (transform.position == target.transform.position) {
			highestPriority.value = 100;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag==currentNeed.ToString()){
			highestPriority.value = 100;
		}
	}
}
