using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody2D m_rigidBody;
	public float gravityScale;
	// Use this for initialization
	void Start () {
		m_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		m_rigidBody.AddForce (Vector2.down * gravityScale);
	}
}
