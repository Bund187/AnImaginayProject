using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour {

	public Image img;
	public GameObject inventory, pause;

	bool isfading;
	Color color;

	void Start(){
		isfading = false;
		color = img.color;	
	}

	void Update(){
		if (isfading)
			FadeOut ();
		if (!isfading && img.color.a >= 0)
			FadeIn ();

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			isfading = true;
		}
	}

	void FadeIn(){
//		print ("fadein="+img.color.a);
		color.a-=0.05f;
		img.color=color;
		if(color.a==0.1){
			color.a=0;
			img.color=color;
			isfading=false;
		}
	}

	void FadeOut(){
	//	print ("fadeOut="+img.color.a);
		color.a+=0.05f;
		img.color=color;

		if(color.a>=1){
			color.a=254;
			img.color=color;
			SceneManager.LoadSceneAsync ("3scene", LoadSceneMode.Single);
			DontDestroyOnLoad (inventory);
			DontDestroyOnLoad (pause);
		}
	}
}
