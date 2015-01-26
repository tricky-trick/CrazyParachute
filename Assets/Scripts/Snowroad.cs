using UnityEngine;
using System.Collections;

public class Snowroad : MonoBehaviour {

	public Vector2 velocity = new Vector2(-3.0f, 1.7f);
	
	// Use this for initialization
	void Start()
	{
		rigidbody2D.velocity = velocity;
	}

	void Update()
	{
		if(rigidbody2D.transform.position.y > 30)
			Destroy(rigidbody2D.gameObject);
	}

}
