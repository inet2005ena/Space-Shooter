using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,speed);
	}
	
}
