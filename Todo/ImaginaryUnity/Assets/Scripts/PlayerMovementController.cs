using UnityEngine;
using System.Collections;


public class PlayerMovementController : MonoBehaviour {

	public float speed= 2f;
	public float rotateSpeed = 2F;
	CharacterController charas;

	Vector2 mouseVel;

	void Start(){
		charas = GetComponent<CharacterController> ();
	}

	void Update() {
		
		//transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
		//transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
			
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float curSpeed = speed * Input.GetAxis("Vertical");
		charas.SimpleMove(forward * curSpeed);

		/*float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		Vector3 RIGHT = transform.TransformDirection(Vector3.right);
		Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

		transform.localPosition += RIGHT * h;
		transform.localPosition += FORWARD * v;*/
	}

	void FixedUpdate () {
		//transform.Rotate(0f,(mouseVel.x * Time.deltaTime),0f);
	}



}
