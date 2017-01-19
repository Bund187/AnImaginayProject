using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public bool canMove;
	public GameObject shadow;

	GameObject pauseCanvas;
	bool isMovingL=true, isMovingR = true, isMovingU = true, isMovingD = true, blockMove=false;
	Animator anim;
	SpriteRenderer spriteRend, shadowRend;
	bool facingRight,isPaused,isPressed;
	string idiom="esp";

	void Start() {
		anim = GetComponent<Animator>();
		canMove = true;
		spriteRend = GetComponent<SpriteRenderer> ();
		shadowRend = shadow.GetComponent<SpriteRenderer> ();
	}

	void FixedUpdate(){

		if (!canMove)   
		{
			moveSpeed = 0;
			return;
		}
		Move();
	}

	void Update(){
		if ((Input.GetAxisRaw ("Pause") != 0)) {
			Pause ();
			pauseCanvas.SetActive (isPaused);	

		} else
			isPressed = false;
	}



	public void Pause(){
		if (!isPressed) {
			isPaused = !isPaused;
			if (isPaused)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
			isPressed = true;
		}
	}

	void Move() {
		float xMove = Input.GetAxisRaw("Horizontal");
		float yMove = Input.GetAxisRaw("Vertical");

		if (!blockMove) {
			if ((xMove > 0f || xMove < 0f) || (yMove > 0f || yMove < 0f)) { 
				if (isMovingR) {
					if (xMove > 0f) {
						shadowRend.sprite = Resources.Load ("ShadowSide", typeof(Sprite)) as Sprite;
						shadowRend.flipX = true;
						spriteRend.flipX = false;
						anim.SetBool ("RunRight", true);
						anim.SetBool ("RunDown", false);
						anim.SetBool ("RunUp", false);
						anim.SetBool ("RunLeft", false);
						anim.SetBool ("RunUpLeft", false);
						transform.Translate (new Vector3 (xMove * moveSpeed * Time.deltaTime, 0f, 0f));
					}
				}

				if (isMovingL) {
					if (xMove < 0f) {
						shadowRend.sprite = Resources.Load ("ShadowSide", typeof(Sprite)) as Sprite;
						shadowRend.flipX = false;
						spriteRend.flipX = true;
						anim.SetBool ("RunLeft", true);
						anim.SetBool ("RunDown", false);
						anim.SetBool ("RunRight", false);
						anim.SetBool ("RunUp", false);
						anim.SetBool ("RunUpLeft", false);
						transform.Translate (new Vector3 (xMove * moveSpeed * Time.deltaTime, 0f, 0f));

					}
				}
				if (isMovingU) {
					if (yMove > 0f) {
						shadowRend.sprite = Resources.Load ("ShadowBack", typeof(Sprite)) as Sprite;
						shadowRend.flipX = false;
						anim.SetBool ("RunUp", true);
						anim.SetBool ("RunDown", false);
						anim.SetBool ("RunLeft", false);
						anim.SetBool ("RunRight", false);
						anim.SetBool ("RunUpLeft", false);
						transform.Translate (new Vector3 (0f, yMove * moveSpeed * Time.deltaTime, 0f));

						if (xMove < 0f) {
							print ("se mueve arriba izqu");
							spriteRend.flipX = false;
							anim.SetBool ("RunLeft", false);
							anim.SetBool ("RunDown", false);
							anim.SetBool ("RunRight", false);
							anim.SetBool ("RunUp", false);
							anim.SetBool ("RunUpLeft", true);
						} 
						if (xMove > 0f) {
							print ("se mueve arriba derecha");
							spriteRend.flipX = true;
							anim.SetBool ("RunLeft", false);
							anim.SetBool ("RunDown", false);
							anim.SetBool ("RunRight", false);
							anim.SetBool ("RunUp", false);
							anim.SetBool ("RunUpLeft", true);
						} 
					}
				}

				if (isMovingD) {
					if (yMove < 0f) {
						shadowRend.sprite = Resources.Load ("ShadowBack", typeof(Sprite)) as Sprite;
						shadowRend.flipX = true;
						anim.SetBool ("RunDown", true);
						anim.SetBool ("RunUp", false);
						anim.SetBool ("RunLeft", false);
						anim.SetBool ("RunRight", false);
						transform.Translate (new Vector3 (0f, yMove * moveSpeed * Time.deltaTime, 0f));
					}

				}

			} else {
				anim.SetBool ("RunLeft", false);
				anim.SetBool ("RunDown", false);
				anim.SetBool ("RunRight", false);
				anim.SetBool ("RunUp", false);
				anim.SetBool ("RunUpLeft", false);
			}
		}



	}

	public bool BlockMove {
		get {
			return this.blockMove;
		}
		set {
			blockMove = value;
		}
	}
	public bool IsMovingR
	{
		get
		{
			return isMovingR;
		}

		set
		{
			isMovingR = value;
		}
	}

	public bool IsMovingL
	{
		get
		{
			return isMovingL;
		}

		set
		{
			isMovingL = value;
		}
	}

	public bool IsMovingU
	{
		get
		{
			return isMovingU;
		}

		set
		{
			isMovingU = value;
		}
	}

	public bool IsMovingD
	{
		get
		{
			return isMovingD;
		}

		set
		{
			isMovingD = value;
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
	public GameObject PauseCanvas {
		get {
			return this.pauseCanvas;
		}
		set {
			pauseCanvas = value;
		}
	}

}
