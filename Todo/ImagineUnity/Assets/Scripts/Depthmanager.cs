using UnityEngine;
using System.Collections;

public class Depthmanager : MonoBehaviour {


	SpriteRenderer spriteRend;
	int order;
	bool si;

	void Start () {
		spriteRend = GetComponent<SpriteRenderer> ();
		order = spriteRend.sortingOrder;
	}

	void Update(){
		if (si) {
			spriteRend.sortingOrder = GameObject.Find("Player").GetComponent<SpriteRenderer> ().sortingOrder + 1;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			si = true;
			//spriteRend.sortingOrder = col.gameObject.GetComponent<SpriteRenderer> ().sortingOrder + 1;
		} 
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			si = false;
			spriteRend.sortingOrder = order;
		}
	}
}
