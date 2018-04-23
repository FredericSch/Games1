using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;

}


public class PlayerCon : MonoBehaviour {


	
	public float speed;
	public Boundary boundary;
	public float tilt;
	public float ztilt;
	public GameObject shot;
	public Transform shotSpawn;
	public Transform shotSpawn2;
	public float fireRate;
	private float nextFire;


	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {

						nextFire = Time.time + fireRate;
						Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			//yield return new WaitForSeconds(1);
				
						nextFire = Time.time + fireRate;	
						Instantiate (shot, shotSpawn2.position, shotSpawn2.rotation);
			audio.Play ();
				}
						
				
		}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = move*speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z,boundary.zMin,boundary.zMax)
			);
		rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.z * ztilt ,0.0f, rigidbody.velocity.x * -tilt);

	}
}
