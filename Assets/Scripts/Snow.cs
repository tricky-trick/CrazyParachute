using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour {

	public Vector2 velocity = new Vector2(0, -1);
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = velocity;
	}

	void Update()
	{
		if(rigidbody2D.transform.position.y < -20)
			Destroy(rigidbody2D.gameObject);
	}
}
