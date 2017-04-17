using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionning : MonoBehaviour {

	private Transform m_transform;
	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {
		m_transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		Vector3 pos1 = player1.transform.position;
		Vector3 pos2 = player2.transform.position;
		Vector2 pos12 = new Vector2(pos1.x,pos1.y);
		Vector2 pos22 = new Vector2(pos2.x,pos2.y);
		Vector2 tmp = (pos12 + pos22) / 2F;
		m_transform.position = new Vector3(tmp.x,tmp.y,-10F);
	}
}
