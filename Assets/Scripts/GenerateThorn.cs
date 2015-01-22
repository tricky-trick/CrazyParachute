using UnityEngine;
using System.Collections;

public class GenerateThorn: MonoBehaviour {

	public GameObject thorn;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("CreateObstacle", Random.Range(0.0F, 1.0F), Random.Range(10.0F, 10.0F));
	}
	
	void CreateObstacle()
	{
		Instantiate(thorn);
	}
}
