using System;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
    public static string CurrentStageName = "Stage1_1";
    private PlayerController PlayerScript;
    public GameObject NewStage;
    private GameObject OldStage;
    private float CurrentStageWidth;
    private int NewStageIndex;
    private int CurrentStageIndex;
    private int StartStageIndex;
    private int EndStageIndex;

    void Start()
    {
        //find current stage and determine how much levels exists for this stage
        //FindNumberOfLevels();
        PlayerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void GenerateNewTerrain()
    {
        OldStage = GameObject.Find("Ground");
        NewStageIndex = UnityEngine.Random.Range(StartStageIndex, EndStageIndex);
        NewStage = (GameObject)Instantiate(Resources.Load("Stage" + "1" + "_" +  NewStageIndex));
        CurrentStageName = "Stage" + "1" + "_" + NewStageIndex;

        CurrentStageWidth = PlayerScript.CurrentStage.transform.Find("Ground").gameObject.GetComponent<Collider2D>().bounds.size.x;
        NewStage.transform.position = new Vector3(CurrentStageWidth - StageController.CurrentSpeed, 
                                                    PlayerScript.CurrentStage.transform.position.y, 
                                                    PlayerScript.CurrentStage.transform.position.z);
    }
    void FindNumberOfLevels()
    {
        //determine the current stage - placeholder for now
        CurrentStageName = "Stage1_1";
        //search for how much files or prefabs exist for this level - eg there is 2 pre fabs for stage 1_x right now

        //set start, current and end indexes based on prefabs found
       
        StartStageIndex = 1;
        EndStageIndex = 3;
}
}
