using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        print("Collision Occured - collectible");
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
}
