using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	void OnParticleCollision(GameObject other)
	{
		if(other.transform.tag == "Player"){
			Destroy (other.gameObject); 
		}
	}
}
