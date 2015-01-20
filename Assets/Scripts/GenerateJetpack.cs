using UnityEngine;
using System.Collections;

public class GenerateJetpack: MonoBehaviour {

	public GameObject jetpack;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", Random.Range(1.0F, 10.0F), Random.Range(10.0F, 30.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(jetpack);
	}
}
