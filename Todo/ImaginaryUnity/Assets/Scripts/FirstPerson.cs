using UnityEngine;
using System.Collections;

public class FirstPerson : MonoBehaviour {

    public float walkSpeed = 3;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void FixedUpdate()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        Move();
    }

    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime* walkSpeed;
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime* walkSpeed;
        if (xMove > 0f || xMove < 0f)
        {
            transform.Translate(new Vector3(xMove, 0, 0));
        }
        if(zMove > 0f || zMove < 0f)
        {
            transform.Translate(new Vector3(0, 0, zMove));
        }
    }
}
