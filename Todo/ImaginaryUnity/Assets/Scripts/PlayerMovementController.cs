using UnityEngine;
using System.Collections;


public class PlayerMovementController : MonoBehaviour {

	float speed= 2f;

	void Update() {
		float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		Vector3 RIGHT = transform.TransformDirection(Vector3.right);
		Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

		transform.localPosition += RIGHT * h;
		transform.localPosition += FORWARD * v;
	}




}
