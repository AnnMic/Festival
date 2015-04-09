using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject tilePrefab;
	int nbrOfRows = 20;
	int nbrOfColumns = 20;
	public int[,] grid;

	// Use this for initialization
	void Start () {
		grid = new int[nbrOfRows, nbrOfColumns];

		for(int row = 0; row < nbrOfRows; row++){
			for(int column = 0; column < nbrOfRows; column++){
				GameObject tile = (GameObject)Instantiate (tilePrefab, Vector3.zero, Quaternion.identity);
				// Transform & parent
				tile.transform.SetParent(transform);
				//tileTransform.SetParent (parentContent.transform, false);
				tile.transform.position = new Vector3(10*row,0,10*column);
				tile.name = string.Format("tile_{0}_{1}", row, column);
				grid[row,column] = 0; // all empty
			}
		}
		gameObject.SetActive (false);
	}

}
