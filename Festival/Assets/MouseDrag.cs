using UnityEngine;
using System.Collections;


public class MouseDrag : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 curScreenPoint ;
	private Vector3 curPosition ;
	
	void Start () {
	}
	
	void Update () {
	}
	
	void OnMouseDown () {
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Cursor.visible = false;
	}
	
	void OnMouseDrag() { 
		curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
	
	void OnMouseUp(){
		Cursor.visible = true;
	}
	
}