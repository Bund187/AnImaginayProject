using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour {

	public Image img;
	public GameObject inventory, pause;

	bool isfading;
	Color color;
	float fadeInVal, fadeOutVal;
	string scene;

	void Start(){
		if ((GameObject.Find ("Backgrnd").GetComponent ("IntroManager") as IntroManager) != null) {
			fadeInVal = 0.01f;
			fadeOutVal = 0.01f;
		} else {
			fadeInVal = 0.05f;
			fadeOutVal = 0.05f;
		}
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
		color.a-=fadeInVal;
		img.color=color;
		if(color.a==0.1){
			color.a=0;
			img.color=color;
			isfading=false;
		}
	}

	void FadeOut(){
		color.a+=fadeOutVal;
		img.color=color;

		if(color.a>=1){
			color.a=254;
			img.color=color;
            DontDestroyOnLoad(inventory);
            DontDestroyOnLoad(pause);
            SceneManager.LoadSceneAsync (scene, LoadSceneMode.Single);
			
		}
	}

	public bool Isfading {
		get {
			return this.isfading;
		}
		set {
			isfading = value;
		}
	}

	public float FadeInVal {
		get {
			return this.fadeInVal;
		}
		set {
			fadeInVal = value;
		}
	}

	public float FadeOutVal {
		get {
			return this.fadeOutVal;
		}
		set {
			fadeOutVal = value;
		}
	}
}
