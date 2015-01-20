using UnityEngine;
using System.Collections;

public class GenerateClouds2 : MonoBehaviour {

	public GameObject clouds;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", 1f, Random.Range(5.0F, 15.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(clouds);
	}
}
