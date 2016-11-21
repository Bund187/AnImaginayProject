using UnityEngine;
using System.Collections;

public class Depthmanager : MonoBehaviour {


	SpriteRenderer spriteRend;
	int order;

	void Start () {
		spriteRend = GetComponent<SpriteRenderer> ();
		order = spriteRend.sortingOrder;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			spriteRend.sortingOrder = col.gameObject.GetComponent<SpriteRenderer> ().sortingOrder + 1;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			spriteRend.sortingOrder = order;
		}
	}
}
