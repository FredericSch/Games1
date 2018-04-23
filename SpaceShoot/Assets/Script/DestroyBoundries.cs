using UnityEngine;
using System.Collections;

public class DestroyBoundries : MonoBehaviour {

	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}
}
