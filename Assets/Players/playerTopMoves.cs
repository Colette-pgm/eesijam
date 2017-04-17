using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTopMoves : MonoBehaviour {
	private bool m_isJumping;
	private Rigidbody2D m_physic;

	public float laPouissance;
	public float DaSpeed;
	public float pasPlusViteQue;
	public GameObject botPlayer;
	private int m_direction;
	// Use this for initialization
	void Start () {
		m_isJumping = false;
		m_physic = gameObject.GetComponent<Rigidbody2D> ();
		m_direction = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !m_isJumping)
		{
			//m_isJumping = true;
			//Da joumpe!!!
			m_physic.AddForce(Vector2.up * laPouissance);
			Debug.Log ("jumpkey");
		}

		//directions !!!!
		if (Input.GetKeyDown (KeyCode.D)) {
			m_direction++;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			m_direction--;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			m_direction--;
		}
		if (Input.GetKeyUp (KeyCode.Q)) {
			m_direction++;
		}


	}
	void FixedUpdate(){
		if (Mathf.Abs (m_physic.velocity.x) < pasPlusViteQue) {
			//float dist = gameObject.GetComponent<Transform> ().position.x - botPlayer.GetComponent<Transform> ().position.x;
			//if (!(Mathf.Abs(dist)>1000 && dist * m_direction > 0F)) {
				m_physic.AddForce (Vector2.right * DaSpeed * m_direction);
			//}
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
