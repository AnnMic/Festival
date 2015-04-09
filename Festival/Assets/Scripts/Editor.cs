using UnityEngine;
using System.Collections;

public class Editor : MonoBehaviour {

	public GameObject prefab;
	public GameObject topdown;
	public GameObject ortographic;
	public GameObject grid;
	public GameObject panel;

	private bool isDragging = false;
	private GameObject draggedObject = null;
	private Vector3 dragOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckMouseInput();
	}

	private void CheckMouseInput(){
		if (Input.GetMouseButtonDown(0)){
			// if not dragging an object at the moment
			if (draggedObject == null){
				RaycastHit hit;
				Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
				if (hit.transform && hit.transform.tag == "draggable"){
//					print (hit.transform.name);
					// pick an object and start to drag
					draggedObject = hit.transform.gameObject;
					dragOffset = hit.point - draggedObject.transform.position;
//					print (dragOffset);
				}
			}
		}
		if (Input.GetMouseButtonUp(0)){
			// release dragged object if any
			RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
			foreach(RaycastHit hit in hits){
				if (hit.transform.tag == "Grid"){
					draggedObject.transform.position = new Vector3(hit.transform.position.x,
					                                               draggedObject.transform.position.y,
					                                               hit.transform.position.z);
				}
			}
			draggedObject = null;
		}
		if (draggedObject != null){
			// drag object
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			draggedObject.transform.position = new Vector3(mousePos.x-dragOffset.x, 
			                                               draggedObject.transform.position.y,
			                                               mousePos.z-dragOffset.z -5f);
		}
	}


	public void onAddObject(){
		ChangeCameraView ();

		grid.SetActive (true);
		panel.SetActive (true);
	}

	void ChangeCameraView(){
		ortographic.SetActive (false);
		topdown.SetActive(true);
	}

	public void CloseEditor(){
		topdown.SetActive(false);
		ortographic.SetActive (true);
		grid.SetActive (false);
		panel.SetActive (false);

	}
	
}
