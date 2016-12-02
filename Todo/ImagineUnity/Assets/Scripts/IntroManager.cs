using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour {

	public GameObject mumTalk,mumEat, mumEatH, playerEatH,playerEat,sitDown, standUp, eating, door;

	bool isPress, isActive;
	Animator animEat,animEatH;

	void Start(){
		animEat = mumEat.GetComponent<Animator> ();
		animEatH = mumEatH.GetComponent<Animator> ();

	}

	void Update () {
		print ("I=" + GameObject.Find ("Backgrnd").GetComponent<DialogueController> ().I);
		if (GameObject.Find ("Backgrnd").GetComponent<DialogueController> ().I >= 20) {
				playerEatH.SetActive (false);
				playerEat.SetActive (false);
				sitDown.SetActive (false);
				eating.SetActive (false);
				door.SetActive (false);
				standUp.SetActive (true);

				if ((Input.GetAxisRaw ("Fire1") != 0)) {
					if (!isPress) {
						animEat.enabled = false;
						animEatH.enabled = false;
						mumTalk.SetActive (true);
						isPress = true;
					}
				} else
					isPress = false;
		}
		if (GameObject.Find ("Backgrnd").GetComponent<DialogueController> ().I >= 27) {
			animEat.enabled = true;
			animEatH.enabled = true;
			mumTalk.SetActive (false);
		}

		gameObject.GetComponent<DialogueController> ().DialogueFunc ();
	}
}
