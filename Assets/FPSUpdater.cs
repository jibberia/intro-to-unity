using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSUpdater : MonoBehaviour {

	Text fpsText;
	// Use this for initialization
	void Start () {
		fpsText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 10 == 0) {
			int fps = (int) (1 / Time.smoothDeltaTime);
			fpsText.text = fps.ToString();//string.Format("{0} FPS", fps);
		}
	}
}
