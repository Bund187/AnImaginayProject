using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIAnswerController : MonoBehaviour {

	public Text[] answers=new Text[4];

	GameObject collision;


	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name==collision.name){
			AvoidCollision (this.gameObject);	
		}
	}

	void AvoidCollision(GameObject obj){
		if (obj.transform.localPosition.y >= 0.64f) {
			transform.localPosition = new Vector2 (0, -0.65f);

		}
		else if (obj.transform.localPosition.y <= -0.65f) {
			transform.localPosition = new Vector2 (1.1f,0);

		}else if (obj.transform.localPosition.x <= -1.1f) {
			transform.localPosition = new Vector2 (0, 0.65f);

		}else if (obj.transform.localPosition.x >= 1.1f) {
			transform.localPosition = new Vector2 (-1.1f,0);

		}
	}

	public GameObject Collision {
		get {
			return this.collision;
		}
		set {
			collision = value;
		}
	}
}
