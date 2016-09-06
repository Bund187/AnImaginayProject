using UnityEngine;
using System.Collections;

public class TorchLight : MonoBehaviour {

	public GameObject torch,torch2;

	void Update () {
		if (Time.time % 10 == 0) {
			torch.SetActive (false);		
			torch2.SetActive (false);
		} else {
			torch.SetActive (true);		
			torch2.SetActive (true);
		}
	}
}
