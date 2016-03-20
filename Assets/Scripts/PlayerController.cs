using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public bool Jumping;
    public float JumpTime = 1f;
    public float JumpForce = 3f;
    private float Jumptimer;
    public bool isGrounded = true;
    public GameObject CurrentStage;
    private TerrainGenerator StageSpawn;

    // Use this for initialization
    void Start () {
        CurrentStage = GameObject.Find("Stage1_1");
        StageSpawn = GameObject.FindObjectOfType<TerrainGenerator>();
    }
	
	// Update is called once per frame
	void Update () {
        InputCheck();
        if (transform.position.x >= CurrentStage.transform.Find("Ground").position.x)
        {
            //Generate new terrain
            StageSpawn.GenerateNewTerrain();
            CurrentStage = StageSpawn.NewStage;
        }
        //add timer to increment or decrement jump time and force as the game gets faster?
    }
    //called per physics update
    void FixedUpdate()
    {
        PerformJump();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isGrounded && col.collider.tag == "Ground")
        {
                isGrounded = true;
        }
    }
    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Jumping && isGrounded)
        {
            Jumping = true;
        }
    }
    void PerformJump()
    {
        if (Jumping) {
            isGrounded = false;
            Jumptimer = 0f;
            while (Jumptimer < JumpTime)
            {
                float JumpProgress = Jumptimer / JumpTime;
                Vector3 CurrentumpForce = Vector3.Lerp(new Vector3(0f, JumpForce, 0f), Vector3.zero, JumpProgress);
                GetComponent<Rigidbody2D>().AddForce(CurrentumpForce);
                Jumptimer += Time.fixedDeltaTime;
            }
            Jumping = false;
        }
    }
}

