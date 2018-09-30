using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int state;
    public float moveSpeed;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;

    public float timeToMove;
    private float timeToMoveCounter;

    private Rigidbody2D myRigidbody;
    private bool moving;
    private Vector3 moveDirection;

	public Transform target;
	public float chaseRange;

	bool attack;


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
		state = 1;
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
		float distanceToTarget = Vector3.Distance (transform.position, target.position);
		switch (state) {
		case 1: //patrolling
			if (distanceToTarget > chaseRange) {
				if (moving) {
					timeToMoveCounter -= Time.deltaTime;
					myRigidbody.velocity = moveDirection;

					if (timeToMoveCounter < 0f) {
						moving = false;
						timeBetweenMoveCounter = timeBetweenMove;
					}

				} else {
					timeBetweenMoveCounter -= Time.deltaTime;
					myRigidbody.velocity = Vector2.zero;

					if (timeBetweenMoveCounter < 0f) {
						moving = true;
						timeToMoveCounter = timeToMove;

						moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
					}
				}
			} else {
				state = 2;
			}
			break;
		case 2: //attacking & chasing
			if (distanceToTarget < chaseRange) 
			{
				//chasing the player
				Vector3 targetDir = target.position - transform.position;
				float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f; //for rotating the ai in order to chase
				Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);
				transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);

				//attacking the player
				if ((distanceToTarget <= 3) && (distanceToTarget >= 2)) {
					moveSpeed = 0;
					attack = true;
				} else {
					moveSpeed = 3;
				}
				if (attack) {

				}

	           
			} else {
				state = 1;
			}
			break;
		case 3: //retreating & regeneration of health
			
			break;
		default:  //???????
			break;
		}
    }
}