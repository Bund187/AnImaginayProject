using UnityEngine;
using System.Collections;

public class BackgroundSizer : MonoBehaviour {

	SpriteRenderer spriteRend;
	Vector2 scale;
	Object[] sprites;

	public int defaultWidth= 1080, defaultHeight=720;

	void Start(){
		spriteRend = GetComponent<SpriteRenderer> ();
		sprites = FindObjectsOfType (typeof(GameObject));
	}

	void Update () {

		double width = spriteRend.sprite.bounds.size.x;
		double screenHeight = Camera.main.orthographicSize * 2;
		double screenWidth = screenHeight / Screen.height * Screen.width;
		transform.localScale = new Vector2 (1, 1) * (float)(screenWidth / width);
	}

}
