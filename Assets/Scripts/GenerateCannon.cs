using UnityEngine;
using System.Collections;

public class GenerateCannon: MonoBehaviour {

	public GameObject cannon;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 0.0F, Random.Range(15.0F, 25.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(cannon);
	}
}
