using UnityEngine;
using System.Collections;

public class SceneManagerController : MonoBehaviour {

	public GameObject Forest1_leave1Prefab;

	void Start () {
		
	}
	

	void Update () {
		SceneManager ();
	}

	void SceneManager(){
		if (transform.name=="Forest1_BG"){
			float positionX = Random.Range (-10.0f, 9.0f);
			int rnd = Random.Range (0, 10);
			print ("rnd=" + rnd);
			if (rnd == 4) {
				GameObject instLeave = (GameObject)Instantiate (Forest1_leave1Prefab, new Vector2 (positionX, 6.5f), Quaternion.identity);
			}
		}
		if (transform.name == "FallingLeave1(Clone)") {
			float speed = Random.Range (1.0f, 3.0f);
			transform.Translate (Vector2.down * (Time.deltaTime * speed));
			if (transform.position.y <= -7.6f) {
				Destroy (transform.gameObject);
			}
		}
	}
}
