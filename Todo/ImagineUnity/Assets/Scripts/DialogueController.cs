using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	ArrayList dialogue=new ArrayList();
	int i=0, j = 0;
	bool isPress,isPress2,endDialogue, isAnswering,exit = false,answerFound = false;
	Text auxDial, auxDials;
	GameObject player;

	public Text dialogueTxt, dialShadow;
	public GameObject answerBlock;

	//Al colisionar el jugador con el npc hablante se ejecuta la funcion del dialogo.
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Player") {
			DialogueFunc();
			player = col.gameObject;

		}
	}

	public void DialogueFunc(){
		if (exit) {
			print ("parando corrutina");
			player.GetComponent<PlayerController> ().BlockMove = false;
			answerBlock.SetActive (false);
			j = 0;
			exit = false;
		}

		//Se divide en dos partes el dialogo
		StreamReader reader =null;

		//La primera parte es referente a la intro. Chekea que el background tiene el script IntroManager
		if ((GameObject.Find ("Backgrnd").GetComponent ("IntroManager") as IntroManager) != null) {
			reader = new StreamReader (Application.dataPath + "/StreamingAssets/intro/" /*+ GameObject.Find ("Player").GetComponent<PlayerController> ().Idiom*/ + "espDialogue.txt");
			dialogue.Clear ();
			while (!reader.EndOfStream) {
				dialogue.Add (reader.ReadLine ());
			}
			if (i >= dialogue.Count) {
				i = 0;
			}
			//Aqui el lector va leyendo cual es la linea de la madre(M) o del player(P). (-)Hace referencia a los silencios. (x) Hace referencia al final de la conversacion
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

			//Si el background no tiene el script arriba indicado se ejecuta la segunda parte de este script. Este hace referencia al dialogo con NPCs.
		} else {
			reader = new StreamReader (Application.dataPath + "/StreamingAssets" + "/" + gameObject.name + "/" + GameObject.Find ("Player").GetComponent<PlayerController> ().Idiom + "Dialogue.txt");
			dialogue.Clear ();
			while (!reader.EndOfStream) {
				dialogue.Add (reader.ReadLine ());
			}
			if (i >= dialogue.Count) {
				i = 0;
			}
			//Si no esta respondiendo hace referencia a las respuestas del player
			if (!isAnswering) {
				if ((Input.GetAxisRaw ("Fire1") != 0)) {
					if (!isPress) {

						//Si el lector encuentra un "?" quiere decir que el player puede responder por lo tanto se inicia el sistema de respuesta.
						if (dialogue [i].ToString () == "?") {
							print ("·valor de la i=" + i);
							print ("empezando rspuestas");
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
							Talking (i);
							i++;

						}

						isPress = true;
					}
				} else
					isPress = false;
			}
		}

	}

	void Talking(int index){
		dialogueTxt.text = dialogue [index].ToString ();
		dialShadow.text = dialogue [index].ToString ();
		print ("linea 1 = " + dialogue [index] + " longitud="+dialogue [index].ToString ().Length);

	}

	void OnTriggerExit2D(Collider2D col){
		dialogueTxt.text = "";
		dialShadow.text = "";

	}

	IEnumerator AnswerManager(){
		
		int j = 0;
		bool isChoosing=true;
		isAnswering = true;
		exit = false;
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

			if (isChoosing) {
				yield return new WaitForSeconds (0.5f);
				isChoosing = false;
			}

			ChoosingOption (j);
			yield return null;
		}
		isAnswering = false;


	}

	void ChoosingOption(int index){
		
		if ((Input.GetAxisRaw ("Fire1") !=0)) {
			
			if (!isPress2) {
				for (int i = 0; i < 4; i++) {
					if (i != index) {
						answerBlock.GetComponent<UIAnswerController> ().answers [i].text = "";
						if (index == 3) {
							print ("diciendo adios");
							isAnswering = false;
							exit = true;
						}
					}
					answerBlock.GetComponent<UIAnswerController> ().answers [i].color = Color.white;
				}
				if ((Input.GetAxisRaw ("Fire1") !=0)) {
					answerBlock.SetActive (false);
					if (!isPress) {
						while (!answerFound) {
							if (dialogue [j].ToString () == index.ToString ()) {
								answerFound = true;
							}
							j++;
						}
						if (dialogue [j].ToString () != "." && answerFound) {
							Talking (j);
							j++;
						}
						if (dialogue [j].ToString () == ".") {
							print ("diciendo adios");
							dialogueTxt.text = "";
							dialShadow.text = "";	
							isAnswering = false;
							exit = true;
						}
					}
					isPress = true;

				}else
					isPress = false;

				isPress2 = true;
			}
		} else
			isPress2 = false;
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
