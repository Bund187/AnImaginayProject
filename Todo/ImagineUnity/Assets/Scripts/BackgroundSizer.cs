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


		//Spriteresizer ();
	}

	void Spriteresizer(){
		scale = new Vector2 (defaultWidth / Screen.width, defaultHeight / Screen.height);
		GameObject.Find("Player").transform.localScale = Vector2.Scale (GameObject.Find("Player").transform.localScale, scale);

		/*foreach (GameObject sprit in sprites) {
			print ("sprites = "+sprit.name);
			sprit.transform.localScale = Vector2.Scale (sprit.transform.localScale, scale);
			sprit.transform.position = Vector2.Scale (sprit.transform.position, scale);
		}*/
	}
}
