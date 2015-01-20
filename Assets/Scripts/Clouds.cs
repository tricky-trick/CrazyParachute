using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

	public Vector2 velocity = new Vector2(0, 5);
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = velocity;
	}
}
