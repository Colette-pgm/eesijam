using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalVelocity : MonoBehaviour {

	Rigidbody2D m_rigidbody;
	Transform m_transform;
	// Use this for initialization
	void Start () {
		m_rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		m_transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Matrix4x4 WtL = m_transform.worldToLocalMatrix ;
		Matrix4x4 LtW = m_transform.localToWorldMatrix ;
		Vector3 localVelocity = WtL.MultiplyVector (m_rigidbody.velocity);
		localVelocity.y = 0F;//freeze local y
		m_rigidbody.velocity = LtW.MultiplyVector(localVelocity);

	}
}
