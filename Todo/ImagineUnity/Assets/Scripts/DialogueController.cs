using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	ArrayList dialogue=new ArrayList();

	int i=0;
	bool isPress;
	Text auxDial, auxDials; 

	public Text dialogueTxt, dialShadow;
	//public GameObject obj1;

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {
			Dialogue ();
		}
	}

	public void Dialogue(){
		///////////pruebas
		if (transform.name == "plantita") {
			print ("objeto");
			//obj1.SetActive (true);
		}
		////////////
		StreamReader reader =null;
		if ((GameObject.Find ("Backgrnd").GetComponent ("IntroManager") as IntroManager) != null) {
			reader = new StreamReader (Application.dataPath + "/StreamingAssets/intro/" /*+ GameObject.Find ("Player").GetComponent<PlayerController> ().Idiom*/ + "espDialogue.txt");
			dialogue.Clear ();
			while (!reader.EndOfStream) {
				dialogue.Add (reader.ReadLine ());
			}
			if (i >= dialogue.Count) {
				i = 0;
			}

			if ((Input.GetAxisRaw ("Fire1") != 0)) {
				if (!isPress) {
					if (dialogue [i].ToString() == "P") {
						i++;
						dialogueTxt.color=Color.white;
					} 
					if(dialogue [i].ToString() == "M") {
						i++;
						dialogueTxt.color=Color.magenta;
					}
					dialogueTxt.text = dialogue [i].ToString ();
					dialShadow.text = dialogue [i].ToString ();
					print ("linea 1 = " + dialogue [i]);
					i++;
					isPress = true;
				}
			} else
				isPress = false;

		} else {
			reader = new StreamReader (Application.dataPath + "/StreamingAssets" + "/" + gameObject.name + "/" + GameObject.Find ("Player").GetComponent<PlayerController> ().Idiom + "Dialogue.txt");
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
