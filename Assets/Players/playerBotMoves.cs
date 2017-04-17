using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBotMoves : MonoBehaviour {
	private bool m_isJumping;
	private Rigidbody2D m_physic;

	public float laPouissance;
	public float DaSpeed;
	public float pasPlusViteQue;
	private int m_direction;
	// Use this for initialization
	void Start () {
		m_isJumping = false;
		m_physic = gameObject.GetComponent<Rigidbody2D> ();
		m_direction = 0;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Keypad0) && !m_isJumping)
		{
			//m_isJumping = true;
			//Da joumpe!!!
			m_physic.AddForce(Vector2.down * laPouissance);
			Debug.Log ("jumpkey2");
		}

		//directions !!!!
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			m_direction++;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			m_direction--;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			m_direction--;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			m_direction++;
		}


	}
	void FixedUpdate(){
		if (Mathf.Abs (m_physic.velocity.x) < pasPlusViteQue) {
			m_physic.AddForce (Vector2.right * DaSpeed * m_direction);
		}
		//Debug.Log (m_direction);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Ground" ){
			m_isJumping = false;
			Debug.Log ("s'eclate par terre");
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.tag == "Ground" ){
			m_isJumping = true;
			Debug.Log ("jump");
		}
	}
}
