using UnityEngine;
using System.Collections;


public class PlayerMovementController : MonoBehaviour {

	public float speed;
	public float gravity = 20.0F;

	CharacterController charas;
	Vector3 moveDirection = Vector3.zero;

	void Start(){
		charas = GetComponent<CharacterController> ();
	}

	void FixedUpdate() {

		if (charas.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		charas.Move(moveDirection * Time.deltaTime);
	}

	void Update(){
		Run ();
	}

	public void Run(){

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			speed = 8f;
			GetComponent<PlayerViewController> ().StepSpeed = 0.04f;
			print ("is running");
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = 4f;
			GetComponent<PlayerViewController> ().StepSpeed = 0.01f;
			print ("is walking");
		}
	}

}
