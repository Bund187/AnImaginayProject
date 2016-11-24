using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	ArrayList dialogue=new ArrayList();

	int i=0;
	bool isPress;

	public Text dialogueTxt, dialShadow;
	public GameObject obj1;

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {

			///////////pruebas
			if (transform.name == "plantita") {
				print ("objeto");
				obj1.SetActive (true);
			}
			////////////

			StreamReader reader = new StreamReader (Application.dataPath + "/StreamingAssets" + "/" + gameObject.name + "/" + GameObject.Find("Player").GetComponent<PlayerController>().Idiom + "Dialogue.txt");
			dialogue.Clear ();
			while (!reader.EndOfStream) {
				dialogue.Add (reader.ReadLine ());
			}
			if (i >= dialogue.Count) {
				i = 0;
			}

			if ((Input.GetAxisRaw ("Fire1") != 0)) {
				if (!isPress) {
					dialogueTxt.text = dialogue [i].ToString();
					dialShadow.text= dialogue [i].ToString();
					print ("linea 1 = " + dialogue [i]);
					i++;
					isPress = true;
				}
			} else
				isPress = false;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		dialogueTxt.text = "";
		dialShadow.text = "";
	}
}
