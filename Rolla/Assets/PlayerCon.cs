using UnityEngine;
using System.Collections;

public class PlayerCon : MonoBehaviour {

	public float speed;
	private int count;
	public GUIText Counter;
	public GUIText Winning;

	void Start(){
				count = 0;
		SetText ();
		Winning.text = "";
		}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rigidbody.AddForce (movement*speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count = count+1;
			SetText ();
				}

		if (other.gameObject.tag == "PickUP") {
			other.gameObject.SetActive(false);
			count = count+2;
			SetText();
		}
	}

	void SetText(){
		Counter.text = "Count: " + count.ToString ();
		if (count >= 15) {
			Winning.text="You Suck!";
				}
	}
}
