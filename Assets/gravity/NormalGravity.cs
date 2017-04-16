using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGravity : MonoBehaviour {
	private Rigidbody2D m_rb;
	public float gravityScale;
	// Use this for initialization
	void Start () {
		m_rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		m_rb.AddForce (Vector2.down * gravityScale);
	}
}
