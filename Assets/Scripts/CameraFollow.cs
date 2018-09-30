using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;

	public GameObject Player_0;

	// Use this for initialization
	void Start () 
	{
		Player_0 = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float posX = Mathf.SmoothDamp (transform.position.x, Player_0.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, Player_0.transform.position.y, ref velocity.y, smoothTimeY);     
		transform.position = new Vector3 (posX, posY, transform.position.z);
	}
}
