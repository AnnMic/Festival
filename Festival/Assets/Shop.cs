using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	public GameObject foodPrefab;
	public GameObject bathroomPrefab;
	public GameObject funPrefab;
	public GameObject hygienePrefab;
	GameObject selectedObject;
	SceneObject sceneObject;

	void Start(){
		GameObject map = GameObject.FindGameObjectWithTag ("Map");
		sceneObject = map.GetComponent<SceneObject> ();
	}

	public void CreateFoodShop(){		
		GameObject prefab = (GameObject)Instantiate (foodPrefab, Vector3.zero, Quaternion.identity);
		sceneObject.allObjects.Add (prefab);
		sceneObject.hungerObjects.Add (prefab);

		prefab.transform.position = new Vector3(0,0,0);
		selectedObject = prefab;
	}
	
	public void CreateBathroomShop(){
		GameObject prefab = (GameObject)Instantiate (bathroomPrefab, Vector3.zero, Quaternion.identity);
		sceneObject.allObjects.Add (prefab);
		sceneObject.bladderObjects.Add (prefab);

		prefab.transform.position = new Vector3(0,0,0);
		selectedObject = prefab;

	}

	public void CreateFunShop(){	
		GameObject prefab = (GameObject)Instantiate (funPrefab, Vector3.zero, Quaternion.identity);
		sceneObject.allObjects.Add (prefab);
		sceneObject.funObjects.Add (prefab);

		prefab.transform.position = new Vector3(0,0,0);	
		selectedObject = prefab;
	}

	public void CreateHygieneShop(){	
		GameObject prefab = (GameObject)Instantiate (hygienePrefab, Vector3.zero, Quaternion.identity);
		sceneObject.allObjects.Add (prefab);
		sceneObject.hygieneObjects.Add (prefab);

		prefab.transform.position = new Vector3(0,0,0);	
		selectedObject = prefab;
	}

	public void ConfirmPosition(){
		selectedObject = null;
	}
	
	public void RotateObject(){
		if (selectedObject != null) {
			selectedObject.transform.Rotate (0, 90, 0);
		}
		
	}

}
