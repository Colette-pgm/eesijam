using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalBoxScript : MonoBehaviour {
	public float topDecal;
	public float botDecal;
	private Transform m_transform;
	private Vector3 positionOrigine;

	// Use this for initialization
	void Start () {
		m_transform = gameObject.GetComponent<Transform> ();
		positionOrigine = new Vector3 (m_transform.position.x, m_transform.position.y, m_transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		if (m_transform.position.y > positionOrigine.y + m_transform.localScale.y * botDecal) {
			m_transform.position = new Vector3(m_transform.position.x,positionOrigine.y + m_transform.localScale.y * botDecal,m_transform.position.y);
		}
		if (m_transform.position.y < positionOrigine.y + m_transform.localScale.y * topDecal) {
			m_transform.position = new Vector3(m_transform.position.x,positionOrigine.y + m_transform.localScale.y * topDecal,m_transform.position.y);
		}
	}
}
