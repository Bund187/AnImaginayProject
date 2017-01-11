using UnityEngine;
using System.Collections;

public class UIAnswerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		print ("colision");
		if (transform.position.y == 0.65f) {
			transform.position = new Vector2 (transform.position.x, -0.65f);
		}
	}
}
