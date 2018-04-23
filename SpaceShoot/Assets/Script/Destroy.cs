using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameControl gamecontrol;

	void Start(){
				GameObject gamecontrolObject = GameObject.FindWithTag ("GameController");
				if (gamecontrolObject != null) {
						gamecontrol = gamecontrolObject.GetComponent <GameControl> ();
				}
				if (gamecontrol == null) {
						Debug.Log ("Cannot find 'gamecontrol' Script");
				}
		}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") {
						return;
				}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
						Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gamecontrol.Gameover();
				}
				gamecontrol.Add (scoreValue);
				Destroy (other.gameObject);
				Destroy (gameObject);
		}
}
