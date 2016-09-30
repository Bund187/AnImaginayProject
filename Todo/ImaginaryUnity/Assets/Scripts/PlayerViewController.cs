using UnityEngine;
using System.Collections;

public class PlayerViewController : MonoBehaviour {

	public GameObject player;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationX = 0F;
	float rotationY = 0F;
	Rigidbody rigid;
	Quaternion originalRotation,playerRotate;

	void Start ()
	{
		// Make the rigid body not change rotation
		rigid=GetComponent<Rigidbody>();
		if (rigid)
			rigid.freezeRotation = true;
		originalRotation = transform.localRotation;
	}

	void Update ()
	{
		
		// Read the mouse input axis
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		rotationX = ClampAngle (rotationX, minimumX, maximumX);
		rotationY = ClampAngle (rotationY, minimumY, maximumY);

		//print ("rotacionX=" + rotationX);
		print ("rotacionY=" + rotationY);

		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

		transform.localRotation = originalRotation * xQuaternion * yQuaternion;

		playerRotate *= Quaternion.Euler (0f, rotationY, 0f);
		player.transform.localRotation = playerRotate;
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
}
