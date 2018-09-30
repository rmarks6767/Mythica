﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;

	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey("s"))
		{
			anim.SetTrigger("PlayerWalkingToCam");
		}
		else
		{
			anim.ResetTrigger("PlayerWalkingToCam");
		}
		if (Input.GetKey("w"))
		{
			anim.SetTrigger("PlayerWalkingAwayCam");
		}
		else
		{
			anim.ResetTrigger("PlayerWalkingAwayCam");
		}
		if (Input.GetKey("a"))
		{
			anim.SetTrigger("PlayerWalkingLeft");
		}
		else
		{
			anim.ResetTrigger("PlayerWalkingLeft");
		}
		if (Input.GetKey("d"))
		{
			anim.SetTrigger("PlayerWalkingRight");
		}
		else
		{
			anim.ResetTrigger("PlayerWalkingRight");
		}

		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f )
		{
			transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f ));

		}
		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
		{
			transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

		}

	}
}﻿