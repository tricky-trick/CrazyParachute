using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		Vector2 velocity = new Vector2(0,1);
		rigidbody2D.velocity = velocity;
	}
}
