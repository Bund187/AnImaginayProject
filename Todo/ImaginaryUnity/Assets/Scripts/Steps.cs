using UnityEngine;
using System.Collections;

public class Steps : MonoBehaviour {

    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
	void Update () {
        
        if (transform.position.x <= -22)
        {
            
            if(transform.position.z >= 1.70)
            {
                audioS.Stop();
            }else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 5);
            }
        }else
        {
            transform.Translate(Vector3.left * Time.deltaTime * 12);
        }
	}
}
