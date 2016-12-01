using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour {

	public GameObject playerEatH, mumEatH, playerEat, mumEat, playerSee, mumSee, sitDown, standUp, eating;
	Animator anim, anim2, anim3, anim4;

	bool isPress, isActive;

	void Start () {
		anim = playerEatH.GetComponent<Animator> ();
		anim2 = mumEatH.GetComponent<Animator> ();
		anim3 = mumEat.GetComponent<Animator> ();
		anim4 = playerEat.GetComponent<Animator> ();
	}

	void Update () {

        if (Input.GetKeyDown(KeyCode.T))
        {
            playerEat.SetActive(false);
            sitDown.SetActive(false);
            eating.SetActive(false);
            playerEatH.SetActive(false);
            standUp.SetActive(true);
        }

		gameObject.GetComponent<DialogueController> ().Dialogue ();

		if ((Input.GetAxisRaw ("Fire1") != 0)) {
			if (!isPress) {
				isActive = !isActive;

				playerSee.SetActive (isActive);
				mumSee.SetActive (isActive);
				if (isActive) {
					/*anim.enabled = false;
					anim2.enabled = false;
					anim3.enabled = false;
					anim4.enabled = false;*/
				} else {
					/*anim.enabled = true;
					anim2.enabled = true;
					anim3.enabled = true;
					anim4.enabled = true;*/
				}

				isPress = true;
			}
			
		} else isPress = false;
		
	}
}
