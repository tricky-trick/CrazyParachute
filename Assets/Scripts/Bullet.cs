using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		Vector2 velocity = new Vector2(-4.0f,0.0f);
		rigidbody2D.velocity = velocity;
	}
}
