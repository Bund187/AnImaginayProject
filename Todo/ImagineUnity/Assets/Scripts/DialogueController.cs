using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	ArrayList dialogue=new ArrayList();
	string idiom="esp";
	int i=0;
	bool isPress;

	void OnCollisionStay2D(Collision2D col){
		if (col.collider.tag == "Player") {

			StreamReader reader = new StreamReader (Application.dataPath + "/StreamingAssets" + "/" + gameObject.name + "/" + idiom + "Dialogue.txt");
			while (!reader.EndOfStream) {
				dialogue.Add (reader.ReadLine ());
			}

			if ((Input.GetAxisRaw ("Fire1") != 0)) {
				if (!isPress) {
					print ("linea 1 = " + dialogue [i]);
					i++;
					isPress = true;
				}
			} else
				isPress = false;
		}
	}

	public string Idiom {
		get {
			return this.idiom;
		}
		set {
			idiom = value;
		}
	}
}
