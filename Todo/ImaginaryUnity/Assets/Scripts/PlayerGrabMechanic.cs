using UnityEngine;
using System.Collections;

public class PlayerGrabMechanic : MonoBehaviour {

	public GameObject cursor;

	void Start () {
		
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3 (400, 250, 0));
		Debug.DrawRay(ray.origin,ray.direction, Color.red);
		if (Physics.Raycast(ray.origin, ray.direction,out hit,20)){
			if (hit.collider.tag=="collect") {
				cursor.SetActive (true);
				if (Input.GetMouseButtonDown (0)){
					Destroy (hit.collider.gameObject);
				}
			} else {
				cursor.SetActive (false);
			}
		}


	
	}
}
