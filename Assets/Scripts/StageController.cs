using UnityEngine;
using System.Collections;

public class StageController : MonoBehaviour {
    private float step;
    private Vector3 StartPos;
    private Vector3 EndPos;
    public float MaxSpeed = 7.5f;
    public float Acceleration = 0.1f;
    public static float CurrentSpeed = 3f;
    private float SpeedUpdateIncrement = 5f;
    private float TimeToNextSpeedUpdate = 0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TimeToNextSpeedUpdate += Time.deltaTime;
        if(TimeToNextSpeedUpdate >= SpeedUpdateIncrement)
        {
            if (MaxSpeed > CurrentSpeed)
            {
                CurrentSpeed += Acceleration * Time.deltaTime;
            }
            TimeToNextSpeedUpdate = 0f;
        }


        step = CurrentSpeed * Time.deltaTime;
        StartPos = transform.position;
        EndPos = new Vector3(-(CurrentSpeed - transform.position.x), transform.position.y, transform.position.z);
        
        transform.position = Vector3.Lerp(StartPos, EndPos, step);
    }
}
