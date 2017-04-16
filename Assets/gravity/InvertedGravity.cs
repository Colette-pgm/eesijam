using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedGravity : MonoBehaviour {
	private Rigidbody2D m_rb;
	public float gravityScale;
	// Use this for initialization
	void Start () {
		m_rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		m_rb.AddForce (Vector2.up * gravityScale);
	}
}
