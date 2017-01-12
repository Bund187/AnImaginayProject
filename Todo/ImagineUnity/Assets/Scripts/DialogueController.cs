using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	ArrayList dialogue=new ArrayList();
	int i=0;
	bool isPress,endDialogue, isAnswering;
	Text auxDial, auxDials;
	GameObject player;

	public Text dialogueTxt, dialShadow;
	public GameObject answerBlock;

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {
			DialogueFunc();
			player = col.gameObject;

		}
	}

	public void DialogueFunc(){
		
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
					if(dialogue [i].ToString() == "-") {
						i++;
					}
					if(dialogue [i].ToString() == "x") {
						dialogue.Clear ();	
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
			if (!isAnswering) {
				if ((Input.GetAxisRaw ("Fire1") != 0)) {
				
					//player.GetComponent<PlayerController> ().BlockMove = true;

					if (!isPress) {
						if (dialogue [i].ToString () == "?") {
							dialogueTxt.text = "";
							dialShadow.text = "";
							player.GetComponent<PlayerController> ().BlockMove = true;
							answerBlock.SetActive (true);
							answerBlock.GetComponent<UIAnswerController> ().Collision = transform.gameObject;
							answerBlock.GetComponent<UIAnswerController> ().answers [0].text = dialogue [i + 1].ToString ();
							answerBlock.GetComponent<UIAnswerController> ().answers [0].color = Color.yellow;
							answerBlock.GetComponent<UIAnswerController> ().answers [1].text = dialogue [i + 2].ToString ();
							answerBlock.GetComponent<UIAnswerController> ().answers [2].text = dialogue [i + 3].ToString ();
							answerBlock.GetComponent<UIAnswerController> ().answers [3].text = dialogue [i + 4].ToString ();
							StartCoroutine (AnswerManager ());
							//i++;

						}
						if (dialogue [i].ToString ().Length > 1) {
							dialogueTxt.text = dialogue [i].ToString ();
							dialShadow.text = dialogue [i].ToString ();
							print ("linea 1 = " + dialogue [i] + " longitud="+dialogue [i].ToString ().Length);
							i++;
							isPress = true;
						}
					
					}
				} else
					isPress = false;
			}
		}

	}

	void OnTriggerExit2D(Collider2D col){
		dialogueTxt.text = "";
		dialShadow.text = "";
	}

	IEnumerator AnswerManager(){
		int j = 0;
		bool exit = false;
		isAnswering = true;
		while (!exit) {
			if (Input.GetAxisRaw ("Vertical") < 0) {
				if (!isPress) {
					for (int k = 0; k < 4; k++) {
						answerBlock.GetComponent<UIAnswerController> ().answers [k].color = Color.white;
					}
					j++;
					if (j == 4)
						j = 0;
					answerBlock.GetComponent<UIAnswerController> ().answers [j].color = Color.yellow;

					isPress = true;

				}
			} else if (Input.GetAxisRaw ("Vertical") > 0) {
				if (!isPress) {
					for (int k = 3; k >=0; k--) {
						answerBlock.GetComponent<UIAnswerController> ().answers [k].color = Color.white;
					}
					j--;
					if (j == -1)
						j = 3;
					answerBlock.GetComponent<UIAnswerController> ().answers [j].color = Color.yellow;

					isPress = true;

				}
			}else {
				isPress = false;
			}

			if (Input.GetKeyDown (KeyCode.U)) {
				exit = true;
			}
			yield return null;
		}
		print ("press=" + isPress);
		isAnswering = false;


	}

	public ArrayList Dialogue {
		get {
			return this.dialogue;
		}
		set {
			dialogue = value;
		}
	}
	public int I {
		get {
			return this.i;
		}
		set {
			i = value;
		}
	}
}
