using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
    public static int TotalCoinValue;
    private int DashIndex;

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

        DashIndex = this.tag.IndexOf("-") + 1;
        TotalCoinValue += int.Parse(this.tag.Substring(DashIndex));
    }
}
