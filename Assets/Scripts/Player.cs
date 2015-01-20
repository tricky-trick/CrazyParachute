using UnityEngine;
using System.Collections;
using System.Linq;

public class Player : MonoBehaviour
{
	int score = 0;
	int highscore = 0;
	int life = 3;
	float time = 60f;
	float timeJetack = 10f;
	bool isJetpack;
	float timeBlinking = 0;
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	
	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;
	
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 left = new Vector2(-100, 0);
	public Vector2 right = new Vector2(100, 0);
	public Vector2 up = new Vector2(0, 0);
	public Vector2 down = new Vector2(0, -50);
	GameObject player;
	int rotation = 0;
	public Sprite[] playerSpritesParachute;
	public Sprite[] playerSpritesJP;
	
	GUIStyle largeFont;
	
	void Start()
	{
		PlayerPrefs.SetInt("isJetPack", 0);
		score = PlayerPrefs.GetInt("score");
		isJetpack = false;
		HideChildren ();
		HideExplode ();
		player = GameObject.FindGameObjectWithTag("Player");
		largeFont = new GUIStyle();

		largeFont.fontSize = 30;
		largeFont.normal.textColor = Color.white;
	}
	Camera camera;
	// Update is called once per frame
	void Update ()
	{


		//make screen into ray point
		Ray touchPos = Camera.main.ScreenPointToRay(Input.mousePosition);
		float speed = 0;
		if (isJetpack){
			speed = 1.5f;
		}
		else{
			speed = 0.7f;
		}

		if(Input.touchCount>0 || Input.GetMouseButton (0)) {
			rigidbody2D.transform.Translate(touchPos.origin.x * speed * Time.deltaTime, touchPos.origin.y * speed * Time.deltaTime, 0);  
		}


		// Left
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(left);
			if(rotation > -5){
				transform.Rotate(0, 0, 10.0f);
				rotation -= 5;
			}
		
		}

		//Right
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(right);
			if(rotation < 5){
				transform.Rotate(0, 0, -10.0f);
				rotation += 5;
			}
		
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(up);
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(down);
		}



//		if (Input.touchCount > 0){
//			foreach (Touch touch in Input.touches)
//			{
//				switch (touch.phase)
//				{
//				case TouchPhase.Began :
//					/* this is a new touch */
//					isSwipe = true;
//					fingerStartTime = Time.time;
//					fingerStartPos = touch.position;
//					break;
//					
//				case TouchPhase.Canceled :
//					/* The touch is being canceled */
//					isSwipe = false;
//					break;
//					
//				case TouchPhase.Ended :
//					float gestureTime = Time.time - fingerStartTime;
//					float gestureDist = (touch.position - fingerStartPos).magnitude;
//					
//					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
//						Vector2 direction = touch.position - fingerStartPos;
//						Vector2 swipeType = Vector2.zero;
//						
//						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
//							// the swipe is horizontal:
//							swipeType = Vector2.right * Mathf.Sign(direction.x);
//						}else{
//							// the swipe is vertical:
//							swipeType = Vector2.up * Mathf.Sign(direction.y);
//						}
//						if(swipeType.x != 0.0f){
//							if(swipeType.x > 0.0f){
//								rigidbody2D.velocity = Vector2.zero;
//								rigidbody2D.AddForce(right);
//								if(rotation < 0 ){
//									transform.Rotate(0, 0, -10.0f);
//									rotation += 10;
//								}
//								else if(rotation == 0){
//									transform.Rotate(0, 0, -5.0f);
//									rotation += 5;
//								}
//
//							}else{
//								rigidbody2D.velocity = Vector2.zero;
//								rigidbody2D.AddForce(left);
//								if(rotation > 0){
//									transform.Rotate(0, 0, 10.0f);
//									rotation -= 10;
//								}
//								else if(rotation == 0){
//									transform.Rotate(0, 0, 5.0f);
//									rotation -= 5;
//								}
//							}
//						}
//						if(swipeType.y != 0.0f ){
//							if(swipeType.y > 0.0f){
//								rigidbody2D.AddForce(up);
//							}else{
//								rigidbody2D.AddForce(down);
//							}
//						}
//					}
//					
//					break;
//				}
//			}
//		}

		if (transform.position.y > 7)
		{
			transform.position = new Vector2(transform.position.x, -6);
		}
		if(transform.position.y < -7)
		{
			transform.position = new Vector2(transform.position.x, 6);
		}
		if (transform.position.x > 6)
		{
			transform.position = new Vector2(-5, transform.position.y);
		}
		if (transform.position.x < -6) 
		{
			transform.position = new Vector2(5, transform.position.y);
		}

		time -= Time.deltaTime;
		if ( time < 0 )
		{
			Application.LoadLevel(Application.loadedLevel + 1);
			PlayerPrefs.SetInt("score",score);
		}
		if (isJetpack) {
			PlayerPrefs.SetInt("isJetPack", 1);
			left = new Vector2(-200, 0);
			right = new Vector2(200, 0);
			up = new Vector2(0, 150);
			down = new Vector2(0, -150);
						timeJetack -= Time.deltaTime;
						if (timeJetack < 0) {
								isJetpack = false;
								HideChildren ();
								HideExplode();
								timeJetack = 0;
								foreach (Sprite s in playerSpritesParachute)
										if (s.name.Equals ("player")) {
												player.GetComponent<SpriteRenderer> ().sprite = s;
												break;
										}
								//rigidbody2D.velocity = Vector2.zero;

						}
				} else {
			PlayerPrefs.SetInt("isJetPack", 0);
			up = new Vector2(0, 0);
			left = new Vector2(-100, 0);
			right = new Vector2(100, 0);
			down = new Vector2(0, -50);
				}

		timeBlinking -= Time.deltaTime;
		if (timeBlinking < 0) {
			CancelInvoke();
		}

	}

	
	void Die()
	{
		if (score > highscore){
			highscore = score;
			PlayerPrefs.SetInt("highscore", highscore);
		}
		PlayerPrefs.SetInt("score", 0);
		Application.LoadLevel(0);
	}
	

	void OnGUI () 
	{
		GUILayout.Label(" Score: " + score.ToString(), largeFont);
		GUILayout.Label(" Time: " + time.ToString("0"), largeFont);
		GUILayout.Label(" Life: " + life.ToString(), largeFont);
		GUILayout.Label(" Jetpack: " + timeJetack.ToString("0"), largeFont);
	}


	void Awake()
	{
		// load all frames in fruitsSprites array
		playerSpritesJP = Resources.LoadAll<Sprite>("jetpack_man");
		playerSpritesParachute = Resources.LoadAll<Sprite>("player");
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "coin") { 
						score += 10; 
						Destroy (other.gameObject); 
		} 
		else if (other.tag == "jetpack") {
			playerSpritesJP = Resources.LoadAll<Sprite>("jetpack_man");
			foreach(Sprite s in playerSpritesJP)
			if (s.name.Equals("jetpack_man")){
				player.GetComponent<SpriteRenderer>().sprite = s;
				break;
			}
			Destroy (other.gameObject); 
			isJetpack = true;
			timeJetack = 10f;
			ShowChildren();
		}
		else if (other.tag == "life"){
			life++;
			Destroy (other.gameObject);
		}
		else {
			if(!isJetpack){
				if(timeBlinking<0)
				{
				if (life > 0){
					life--;
					Destroy (other.gameObject); 
					transform.position = new Vector2(0.0f, 5.0f);
					timeBlinking = 3;
					InvokeRepeating("Blinking", 0.0f, 0.2f);
				}
				else{

						Die();
					}
				}
			}
			else
			{
				score += 10; 
				Destroy (other.gameObject);
				InvokeRepeating("Explosion", 0.0f, 1.0f);
			}
		}
	}

	void HideChildren()
	{
		Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
		foreach ( Renderer lRenderer in lChildRenderers)
		{
			if(lRenderer.tag == "jetpackFlamesTag"){
				lRenderer.enabled=false;
			}
		}
	}

	void ShowChildren()
	{
		Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
		foreach ( Renderer lRenderer in lChildRenderers)
		{
			if(lRenderer.tag == "jetpackFlamesTag"){
				lRenderer.enabled=true;
			}
		}
	}

	void Explode()
	{
		Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
		foreach ( Renderer lRenderer in lChildRenderers)
		{
			if(lRenderer.tag == "explode"){
				lRenderer.enabled=true;
			}
		}
	}

	void HideExplode()
	{
		Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
		foreach ( Renderer lRenderer in lChildRenderers)
		{
			if(lRenderer.tag == "explode"){
				lRenderer.enabled=false;
			}
		}
		//renderer.enabled = true;
	}

	IEnumerator Wait(float seconds)
	{
		transform.renderer.enabled = false;
		yield return new WaitForSeconds(seconds); 
		transform.renderer.enabled = true;
	}

	IEnumerator WaitForExplode() {
		Explode ();
		yield return new WaitForSeconds(0.3f);
		HideExplode ();
	}

	void Blinking()
	{
		StartCoroutine( Wait (.1f));
	}

	void Explosion()
	{
		StartCoroutine( WaitForExplode ());
	}

}