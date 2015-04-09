using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	public GameObject foodPrefab;
	public GameObject bathroomPrefab;
	public GameObject funPrefab;
	public GameObject hygienePrefab;


	public void CreateFoodShop(){		
		GameObject tile = (GameObject)Instantiate (foodPrefab, Vector3.zero, Quaternion.identity);
		tile.transform.position = new Vector3(0,0,0);

	}
	
	public void CreateBathroomShop(){

		GameObject tile = (GameObject)Instantiate (bathroomPrefab, Vector3.zero, Quaternion.identity);
		tile.transform.position = new Vector3(0,0,0);
	}

	public void CreateFunShop(){	
		GameObject tile = (GameObject)Instantiate (funPrefab, Vector3.zero, Quaternion.identity);
		tile.transform.position = new Vector3(0,0,0);
		
	}

	public void CreateHygieneShop(){
		
		GameObject tile = (GameObject)Instantiate (hygienePrefab, Vector3.zero, Quaternion.identity);
		tile.transform.position = new Vector3(0,0,0);
		
	}
}
