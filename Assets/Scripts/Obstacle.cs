using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    private LevelManager Level;
	// Use this for initialization
	void Start () {
        Level = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        print("Collision Occured");
        Level.LoadNextLevel("Lose");
    }
}
