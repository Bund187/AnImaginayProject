using UnityEngine;
using System.Collections;

public class PlayerViewController : MonoBehaviour {
	
	public bool iscamera = true;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;


	float rotationY = 0F, stepSpeed=0.01f;
	Rigidbody rigid;
	Vector3 initpos,targetL,targetR;
	bool moveHeadLeft=true, moveHeadCenter=true;

	void Start ()
	{
		// El rigidbody no rota
		rigid=GetComponent<Rigidbody>();
		if (rigid)
			rigid.freezeRotation = true;
		Quaternion originalRotation = transform.localRotation;
		initpos = transform.localPosition;
		targetL = new Vector3 (initpos.x - 0.1f, transform.localPosition.y-0.2f, transform.localPosition.z);
		targetR = new Vector3 (initpos.x + 0.1f, transform.localPosition.y-0.2f, transform.localPosition.z);
	}

	void Update ()
	{
		if(!iscamera)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		BodyMovement ();
	}

	//Moviemiento del cuerpo al caminar
	public void BodyMovement(){
		if(/*Input.GetAxis("Horizontal")<0 || Input.GetAxis("Horizontal")>0 || */Input.GetAxis("Vertical")>0 || Input.GetAxis("Vertical")<0){

			if (!moveHeadLeft && !moveHeadCenter) {
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, initpos , stepSpeed);
				if (transform.localPosition == initpos) {
					moveHeadLeft = true;
					moveHeadCenter = true;
				}

			} 
			if (moveHeadLeft && !moveHeadCenter) {
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, initpos , stepSpeed);
				if (transform.localPosition == initpos){
					moveHeadLeft = false;
					moveHeadCenter = true;
				}
			} 
			if(moveHeadCenter) {
				if (moveHeadLeft) {
					transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetL, stepSpeed);
					if (transform.localPosition == targetL) moveHeadCenter = false;
				} else {
					transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetR, stepSpeed);
					if (transform.localPosition == targetR) moveHeadCenter = false;
				}

			}
		}
	}

	//Limitamos el angulo de rotación de la camara arriba y bajo
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}

	public float StepSpeed {
		get {
			return this.stepSpeed;
		}
		set {
			stepSpeed = value;
		}
	}
}
