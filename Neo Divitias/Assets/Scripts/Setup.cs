using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Game game = new Game("Game One");
        Game.current = game;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
