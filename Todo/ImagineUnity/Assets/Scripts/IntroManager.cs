using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour {

	public GameObject playerEat;
	Animator anim;

	bool isPress, isActive;

	void Start () {
		anim = playerEat.GetComponent<Animator> ();
	}

	void Update () {
		gameObject.GetComponent<DialogueController> ().Dialogue ();

		if ((Input.GetAxisRaw ("Fire1") != 0)) {
			if (!isPress) {
				isActive = !isActive;
				anim.SetBool("stop", isActive);
				isPress = true;
			}
			
		} else
			isPress = false;
	}
}
