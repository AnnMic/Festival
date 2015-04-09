using UnityEngine;
using System.Collections;

public class Editor : MonoBehaviour {

	public GameObject prefab;
	public GameObject topdown;
	public GameObject ortographic;
	public GameObject grid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void onAddObject(){


		GameObject tile = (GameObject)Instantiate (prefab, Vector3.zero, Quaternion.identity);
		tile.transform.position = new Vector3(0,0,0);
		ChangeCameraView ();

		grid.SetActive (true);
	}

	void ChangeCameraView(){
		ortographic.SetActive (false);
		topdown.SetActive(true);
	}

	public void CloseEditor(){
		topdown.SetActive(false);
		ortographic.SetActive (true);
		grid.SetActive (false);

	}
}
