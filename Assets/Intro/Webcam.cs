using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour {


	// Use this for initialization
	void Start () {
		WebCamTexture tex = new WebCamTexture();
		this.GetComponent<Renderer>().material.mainTexture = tex;
		tex.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
