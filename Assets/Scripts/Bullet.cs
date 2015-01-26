using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		Vector2 velocity = new Vector2(0,Random.Range(1.0f, 3.0f));
		rigidbody2D.velocity = velocity;
	}
	
	void Update()
	{
		if(rigidbody2D.transform.position.y > 25)
			Destroy(rigidbody2D.gameObject);
	}
}
