using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {

	void Start()
	{
		Vector2 velocity = new Vector2(-20,0);
		rigidbody2D.velocity = velocity;
	}
}
