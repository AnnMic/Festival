using UnityEngine;
using System.Collections;

public class Editor : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void onAddObject(){
		GameObject tile = (GameObject)Instantiate (prefab, Vector3.zero, Quaternion.identity);
		tile.transform.position = new Vector3(0,0,0);


	}
}
