using UnityEngine;
using System.Collections;

public class CharacterResizer : MonoBehaviour {

	Vector2 initPosition;
	Vector2 initScale;

	void Start () {
		initPosition = transform.position;
		initScale = transform.localScale;
	}

	void Update () {
		if (transform.position.y > initPosition.y) {
			transform.localScale = new Vector2 (transform.localScale.x - 0.007f, transform.localScale.y - 0.007f);
			initPosition = transform.position;
		} else if (transform.position.y == initPosition.y) {
			
		} else{
			transform.localScale = new Vector2 (transform.localScale.x + 0.007f, transform.localScale.y + 0.007f);
			initPosition = transform.position;
		}
	}
}
