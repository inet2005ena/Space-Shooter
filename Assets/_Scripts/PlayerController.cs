using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xmin;
    public float xmax;
    public float zmax;
    public float zmin;
}

public class PlayerController : MonoBehaviour {

    public int speed;
    public float tilt;
    public float tiltY;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
	// Update is called once per frame
    public float fireRate;
    public float nextFire;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }


	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(moveHorizontal , 0.0f, moveVertical);

        GetComponent<Rigidbody>().velocity = velocity * speed * Time.deltaTime;
        GetComponent<Rigidbody>().position = new Vector3
            (Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xmin, boundary.xmax), 
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zmin, boundary.zmax)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

    void fireShot()
    {

    }

}
