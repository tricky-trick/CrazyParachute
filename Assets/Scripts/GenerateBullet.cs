using UnityEngine;
using System.Collections;

public class GenerateBullet: MonoBehaviour {

	public GameObject bullet;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 0.0F, 6.0F);
	}
	
	void CreateObstacle()
	{
		Instantiate(bullet);
	}
}
