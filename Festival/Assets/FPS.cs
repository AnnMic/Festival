using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

	void OnGUI()
	{
		GUI.Label(new Rect(0, 0, 100, 100), (fps).ToString());        
	}

	float frameCount = 0f;
	float dt = 0.0f;
	float fps = 0.0f;
	float updateRate = 4.0f;  // 4 updates per sec.
	
	void Update()
	{
		frameCount++;
		dt += Time.deltaTime;
		if (dt > 1.0f/updateRate)
		{
			fps = frameCount / dt ;
			frameCount = 0f;
			dt -= 1.0f/updateRate;
		}
	}
}
