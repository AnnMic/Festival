using UnityEngine;
using System.Collections;

public class PanCamera : MonoBehaviour {
	public float mouseSensitivity = 1.0f;
	private Vector3 lastPosition;
	public float speed = 0.5F;
	float scrollSpeed = 0.5f;

	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				
			// Move object across XY plane
			transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}

		if (Input.GetMouseButtonDown(1))
		{
			lastPosition = Input.mousePosition;
		}
		
		if (Input.GetMouseButton(1))
		{
			Vector3 delta = Input.mousePosition - lastPosition;
			transform.Translate(delta.x * mouseSensitivity, delta.y * mouseSensitivity, 0);
			lastPosition = Input.mousePosition;
		}
	}
}
