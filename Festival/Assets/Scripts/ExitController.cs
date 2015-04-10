using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	public VisitorsGenerator visitorGenerator;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Visitor"){
			visitorGenerator.RemoveVisitor(col.gameObject);
		}
	}
}
