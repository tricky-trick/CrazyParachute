using UnityEngine;
using System.Collections;

public class Bird1 : MonoBehaviour {
	
	void Start()
	{
		Vector2 velocity = new Vector2(Random.Range(2.0F, 7.0F), Random.Range(0.0F, 5.0F));
		rigidbody2D.velocity = velocity;
	}

	void Update()
	{
		if(rigidbody2D.transform.position.y > 10)
			Destroy(rigidbody2D.gameObject);
	}
}
