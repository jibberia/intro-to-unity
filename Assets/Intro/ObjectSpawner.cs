using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public int spawnEveryNFrames = 15;

	public GameObject ballParent;

	public Material ballMaterial;

	// Use this for initialization
	void Start () {
		CreateBall();
		ballParent = GameObject.Find("BallParent");
	}

	void CreateBall() {
		GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		Rigidbody rb = ball.AddComponent<Rigidbody>();
		rb.mass = 0.5f;

		ball.transform.position = this.transform.position;
		Vector3 position = this.transform.position;
		position.x += Random.Range(-this.transform.localScale.x / 2f, this.transform.localScale.x / 2f);
		position.y += Random.Range(-this.transform.localScale.y / 2f, this.transform.localScale.y / 2f);
		position.z += Random.Range(-this.transform.localScale.z / 2f, this.transform.localScale.z / 2f);
		ball.transform.position = position;

		// ball.transform.parent = ballParent.transform;
		ball.transform.SetParent(ballParent.transform, true);

		ball.GetComponent<Renderer>().material = ballMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % spawnEveryNFrames == 0) {
			CreateBall();
		}
	}
}
