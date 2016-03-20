using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    private PlayerController Player;
    public float CameraLead;
    // Use this for initialization
    void Start () {
        AutoFollow();
    }
	
	// Update is called once per frame
	void Update () {
        AutoFollow();
	}
    void AutoFollow()
    {
        //find object in scene is of type playercontroller
        Player = GameObject.FindObjectOfType<PlayerController>();
        //store initial position to modify it
        Vector3 playerpos = Player.transform.position;
        playerpos.z = transform.position.z;
        //add the lead distance of the camera to the intial position to keep player at a certain part of the screen at all times
        playerpos.x = Player.transform.position.x + CameraLead;
        playerpos.y = Player.transform.position.y;
        //interpolate the distance between the intial position and the new camera lead distance rather than jumping straight to the destination position
        transform.position = Vector3.Lerp(transform.position, 
                                            playerpos, 
                                            StageController.CurrentSpeed * Time.deltaTime);
    }
}
