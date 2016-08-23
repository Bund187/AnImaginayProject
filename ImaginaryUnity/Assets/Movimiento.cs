using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	private float startTime;	

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime *4);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate(Vector3.back * Time.deltaTime *4);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector3.left * Time.deltaTime *4);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime *4);
		}

	}
}
