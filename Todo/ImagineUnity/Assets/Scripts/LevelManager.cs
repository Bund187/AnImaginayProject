using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	GameObject[] objs;
	GameObject invent;

	void Awake () {
		objs= Resources.FindObjectsOfTypeAll<GameObject>();

		foreach (GameObject obj in objs) {
			if (obj.name == "InventoryMenu")
				GameObject.Find("Player").GetComponent<Inventory>().Invent = obj;
			if(obj.name =="PauseMenu")
				GameObject.Find("Player").GetComponent<PlayerController>().PauseCanvas = obj;
			
		}
		print ("pause=" + GameObject.Find ("Player").GetComponent<PlayerController> ().PauseCanvas);
	}

}
