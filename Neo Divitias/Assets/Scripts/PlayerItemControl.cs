using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemControl : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
