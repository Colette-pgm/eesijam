using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour {

	private bool m_isJumping;
	private Rigidbody2D m_physic;
	private int m_direction;//left -1, right 1, else 0
	private Gravity m_gravity;
	private Transform m_transform;

	//public fields
	public float jumpPower;
	public float acceleration;
	public float maxSpeed;
	public KeyCode jumpKey;
	public KeyCode leftKey;
	public KeyCode rightKey;


	// Use this for initialization
	void Start () {
		m_isJumping = false;
		m_physic = gameObject.GetComponent<Rigidbody2D> ();
		m_direction = 0;// start 
		m_gravity = gameObject.GetComponent<Gravity>();
		m_transform = gameObject.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(jumpKey) && !m_isJumping )//jump
		{
			m_physic.AddForce(Vector2.up * Mathf.Sign(m_gravity.gravityScale)* jumpPower);
			Debug.Log ("jumpkey");
		}

		//handle direction input
		if (Input.GetKeyDown (rightKey)) {
			m_direction++;
		}
		if (Input.GetKeyDown (leftKey)) {
			m_direction--;
		}
		if (Input.GetKeyUp (rightKey)) {
			m_direction--;
		}
		if (Input.GetKeyUp (leftKey)) {
			m_direction++;
		}


	}
	void FixedUpdate(){
		//
		if (Mathf.Abs (m_physic.velocity.x) < maxSpeed && !m_isJumping) {
			m_physic.AddForce (Vector2.right * acceleration * m_direction);
		}
	}

	//jumping state handling
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "platform" && Mathf.Sign(coll.transform.position.y - m_transform.position.y  )!= Mathf.Sign(m_gravity.gravityScale)){
			m_isJumping = false;
			Debug.Log ("landing");
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.tag == "platform" && Mathf.Sign(coll.transform.position.y - m_transform.position.y  )!= Mathf.Sign(m_gravity.gravityScale) ){
			m_isJumping = true;
			Debug.Log ("jumping");
		}
	}
}
