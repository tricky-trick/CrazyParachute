using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		Vector2 velocity = new Vector2(0,2);
		rigidbody2D.velocity = velocity;
	}
}
