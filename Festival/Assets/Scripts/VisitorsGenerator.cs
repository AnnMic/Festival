using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisitorsGenerator : MonoBehaviour {

	public int maxVisitors;

	public float minSpawnDelay;
	public float maxSpawnDelay;

	public Transform visitorsContainer;

	public GameObject[] visitorPrefabs;

	private Stack<GameObject> visitorsPool;

	void Awake(){
		visitorsPool = new Stack<GameObject>(maxVisitors);
		for (int i=0; i<maxVisitors; i++){
			GameObject visitor = GameObject.Instantiate(visitorPrefabs[Random.Range(0, visitorPrefabs.Length)], 
			                                            transform.position, Quaternion.identity) as GameObject;
			visitor.SetActive(false);
			visitor.name = "Visitor"+i;
			visitor.transform.SetParent(transform);
			visitorsPool.Push(visitor);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(GenerateVisitors(Random.Range(minSpawnDelay, maxSpawnDelay)));
	}
	
	private IEnumerator GenerateVisitors(float delay){
		if (visitorsPool.Count > 0){
			GameObject visitor = visitorsPool.Pop();
			visitor.SetActive(true);
			visitor.transform.SetParent(visitorsContainer);
			visitor.transform.position = visitor.transform.position + new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
		}
		yield return new WaitForSeconds(delay);
		StartCoroutine(GenerateVisitors(Random.Range(minSpawnDelay, maxSpawnDelay)));
	}
}
