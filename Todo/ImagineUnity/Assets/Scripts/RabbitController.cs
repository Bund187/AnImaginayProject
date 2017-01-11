using UnityEngine;
using System.Collections;

public class RabbitController : MonoBehaviour {

	Animator anim;
	int rnd=1 ;
	bool nextAnim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		


		if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=1/*Input.GetKeyDown(KeyCode.U)*/) {
			rnd = Random.Range (1, 11);

		}
		if (rnd < 5) {
			rnd = 1;
			anim.SetInteger ("rnd", rnd);

		}
		if (rnd > 4 && rnd < 8) {
			rnd = 7;
			anim.SetInteger ("rnd", rnd);

		}
		if (rnd > 7) {
			rnd = 9;
			anim.SetInteger ("rnd", rnd);
			nextAnim = true;

		}
		if (nextAnim) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsName("RabbitJump2")) {
				if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=1){
					rnd = 10;
					anim.SetInteger ("rnd", rnd);

				}
			}
			nextAnim = false;
		}
	}
}
