using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum States {
	Walking, 
	Dead, 
	Busy,
};

public class VisitorController : MonoBehaviour {

	List<Need> sortedNeeds = new List<Need>();

	Need highestPriority;
	public Needs currentNeed;

	GameObject target;

	public float overallHapiness;
	public string name = "Chuck Norris";

	GameObject visitorPanel;

	public Need bladder;
	public Need hunger;
	public Need hygiene;
	public Need fun;
	public Need sleep;
	public Need thirst;

	SceneObject sceneObject;

	private Animator animator;
	Income income;

	GameObject exit;
	public int cashSpent = 5;
	 
	public States currentState = States.Walking;

	string[] names = new string[] {"Chuck Norris", "Lessie Pyles", "Adriana Vangorder", "Armand Gridley","Berniece Christy", "Hue Dries",
		"Idella Dinardo",
		"Burl Starns",
		"Kacie Riccio",
		"Anne Mumm",
		"Harrison Sedor",
		"Sharika Terrell",
		"Catherin Huffine",
		"Saul Whigham",
		"Teofila Morning",
		"Brinda Alred",
		"Lacie Milera",
		"Stacie Pegues",
		"Eufemia Longo",
		"Verdie Baltes",
		"Stan Purpura"};

	void Awake(){
		visitorPanel = GameObject.FindGameObjectWithTag("VisitorPanel");
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		target = gameObject;

		bladder = gameObject.AddComponent<Need> ();
		hunger = gameObject.AddComponent<Need>();
		hygiene = gameObject.AddComponent<Need> ();
		fun = gameObject.AddComponent<Need>();
		thirst = gameObject.AddComponent<Need>();

		GameObject map = GameObject.FindGameObjectWithTag ("Map");
		sceneObject = map.GetComponent<SceneObject> ();

		bladder.CreateNeed (Needs.BLADDER, Random.Range(1f, 5f));
		sortedNeeds.Add (bladder);

		hunger.CreateNeed (Needs.HUNGER, Random.Range(1f, 5f));
		sortedNeeds.Add (hunger);

		hygiene.CreateNeed (Needs.HYGIENE, Random.Range(1f, 5f));
		sortedNeeds.Add (hygiene);

		fun.CreateNeed (Needs.FUN, Random.Range(3f, 6f));
		sortedNeeds.Add (fun);

		thirst.CreateNeed (Needs.THIRST, Random.Range(1f, 5f));
		sortedNeeds.Add (thirst);

		InvokeRepeating("UpdateNeed", 2, 5f);

		highestPriority = fun;

		GameObject cash= GameObject.FindGameObjectWithTag ("Cash");
		income = cash.GetComponent<Income> ();

		int random = (int)Random.Range(0, names.Length);
		name = names[random];

		exit = GameObject.FindGameObjectWithTag ("Exit");
		CalculateOverallHapiness ();

	}

	void UpdateNeed(){
		sortedNeeds = sortedNeeds.OrderBy(o=>o.value).ToList();

		highestPriority = sortedNeeds.First ();
		currentNeed = highestPriority.need;

		CalculateOverallHapiness ();

		if (currentState == States.Walking) {
		Debug.Log("Move to");
			MoveTowards ();
		}
	}

	void MoveTowards(){
		int random = 0;
		animator.SetInteger("State", AnimationConstants.WALK);
		switch (highestPriority.need)
		{
		case Needs.BLADDER:
			if(sceneObject.bladderObjects.Count > 0){
				random = (int)Random.Range(0,sceneObject.bladderObjects.Count);
				target = sceneObject.bladderObjects[random];

			}
			break;
		case Needs.HUNGER:
			if(sceneObject.hungerObjects.Count > 0){
				random = (int)Random.Range(0,sceneObject.hungerObjects.Count);
				target = sceneObject.hungerObjects[random];
			}
			break;
		case Needs.FUN:			
			if(sceneObject.funObjects.Count > 0){
				random = (int)Random.Range(0,sceneObject.funObjects.Count);
				target = sceneObject.funObjects[random];
			}
			break;
		case Needs.HYGIENE:
			if(sceneObject.hygieneObjects.Count > 0){
				random = (int)Random.Range(0,sceneObject.hygieneObjects.Count);
				target = sceneObject.hygieneObjects[random];
			}
			break;
		case Needs.THIRST:
			if(sceneObject.thirstObjects.Count > 0){
				random = (int)Random.Range(0,sceneObject.thirstObjects.Count);
				target = sceneObject.thirstObjects[random];
			}
			break;
		default:
			if(sceneObject.funObjects.Count > 0){
				random = (int)Random.Range(0,sceneObject.funObjects.Count);
				target = sceneObject.funObjects[random];
			}
			break;
		}
		if (cashSpent > 40) {
			Debug.Log("coing home");	
			target = exit;
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
		if (currentState == States.Walking) {

			float step = 3.0f * Time.deltaTime;

			transform.position = Vector3.MoveTowards (this.gameObject.transform.position, target.transform.position, step);

			transform.LookAt (target.transform.position);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Exit") return;
		if(other.gameObject.GetComponent<FestivalObject> ().fulfillsNeed == currentNeed){
			highestPriority.value = 100;
			Debug.Log("fulfill need" + highestPriority.need);
			currentState = States.Busy;
			if(currentNeed == Needs.BLADDER){

			}
			else if(currentNeed == Needs.FUN){
				income.AddCash(5);
				cashSpent += 5;
				animator.SetInteger("State", AnimationConstants.WATCH);

			}
			else if(currentNeed == Needs.THIRST){
				income.AddCash(10);
				cashSpent += 10;
				animator.SetInteger("State", AnimationConstants.IDLE);

			}
			else if(currentNeed == Needs.HUNGER){
				income.AddCash(5);
				cashSpent += 5;
				animator.SetInteger("State", AnimationConstants.IDLE);

			}
			StartCoroutine(Wait());

		}
	}
	
	IEnumerator Wait() {
		Debug.Log("Wait");
		yield return new WaitForSeconds(5);
		Debug.Log("DONE");
		currentState = States.Walking;
		MoveTowards ();

	}
	
	void OnMouseDown() {
		visitorPanel.SetActive (true);
		VisitorPanel panel = visitorPanel.GetComponent<VisitorPanel> ();
		panel.SetStats (this);
	}
}
