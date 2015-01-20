using UnityEngine;
using System.Collections;

public class GenerateBird1 : MonoBehaviour {

	public GameObject bird;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, Random.Range(8.0F, 15.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(bird);
	}
}
