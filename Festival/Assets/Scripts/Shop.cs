using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	public GameObject foodPrefab;
	public GameObject bathroomPrefab;
	public GameObject funPrefab;
	public GameObject hygienePrefab;
	public GameObject thirstPrefab;

	GameObject selectedObject;
	SceneObject sceneObject;

	Income income;
	int priceFood = 500;
	int priceThirst = 1000;
	int priceToilette = 100;
	int priceHygiene = 200;
	int priceFun = 2000;


	void Start(){
		GameObject map = GameObject.FindGameObjectWithTag ("Map");
		sceneObject = map.GetComponent<SceneObject> ();
		GameObject cash= GameObject.FindGameObjectWithTag ("Cash");
		income = cash.GetComponent<Income> ();
	}

	public void CreateFoodShop(){	
		if (income.cash >= priceFood) {
			income.DeductCash(priceFood);
			GameObject prefab = (GameObject)Instantiate (foodPrefab, Vector3.zero, Quaternion.identity);
			sceneObject.allObjects.Add (prefab);
			sceneObject.hungerObjects.Add (prefab);
			
			prefab.transform.position = new Vector3(0,0,0);
			selectedObject = prefab;
		}

	}
	
	public void CreateBathroomShop(){
		if (income.cash >= priceToilette) {
			income.DeductCash (priceToilette);
			GameObject prefab = (GameObject)Instantiate (bathroomPrefab, Vector3.zero, Quaternion.identity);
			sceneObject.allObjects.Add (prefab);
			sceneObject.bladderObjects.Add (prefab);

			prefab.transform.position = new Vector3 (0, 0, 0);
			selectedObject = prefab;
		}
	}

	public void CreateFunShop(){
		if (income.cash >= priceFun) {
			income.DeductCash (priceFun);
			GameObject prefab = (GameObject)Instantiate (funPrefab, Vector3.zero, Quaternion.identity);
			sceneObject.allObjects.Add (prefab);
			sceneObject.funObjects.Add (prefab);

			prefab.transform.position = new Vector3 (0, 0, 0);	
			selectedObject = prefab;
		}
	}

	public void CreateHygieneShop(){
		if (income.cash >= priceHygiene) {
			income.DeductCash (priceHygiene);
			GameObject prefab = (GameObject)Instantiate (hygienePrefab, Vector3.zero, Quaternion.identity);
			sceneObject.allObjects.Add (prefab);
			sceneObject.hygieneObjects.Add (prefab);

			prefab.transform.position = new Vector3 (0, 0, 0);	
			selectedObject = prefab;
		}
	}
	public void CreateThirstShop(){	
		if (income.cash >= priceThirst) {
			income.DeductCash (priceThirst);
			GameObject prefab = (GameObject)Instantiate (thirstPrefab, Vector3.zero, Quaternion.identity);
			sceneObject.allObjects.Add (prefab);
			sceneObject.thirstObjects.Add (prefab);
		
			prefab.transform.position = new Vector3 (0, 0, 0);	
			selectedObject = prefab;
		}
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
