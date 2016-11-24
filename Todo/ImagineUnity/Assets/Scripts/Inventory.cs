using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {


	GameObject invent;
	bool isActive,isPressed;

	void Update () {
		if ((Input.GetAxisRaw ("Inventory") != 0)) {
			Inventor ();
		}else
			isPressed = false;
	}

	void Inventor(){
		if (!isPressed) {
			isActive = !isActive;
			invent.SetActive (isActive);
			isPressed = true;
		}
	}

	public GameObject Invent {
		get {
			return this.invent;
		}
		set {
			invent = value;
		}
	}
}




