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
    private GameObject CurrentStage;
    private int CurrentLevel;
    private UnityEngine.Object[] AllLevels = new UnityEngine.Object[10];

    void Start()
    {
        //find current stage and determine how much levels exists for this stage
        FindNumberOfLevels();

        PlayerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void GenerateNewTerrain()
    {
        OldStage = GameObject.Find("Ground");
        NewStageIndex = UnityEngine.Random.Range(StartStageIndex, EndStageIndex);
        NewStage = (GameObject)Instantiate(Resources.Load("Stage" + CurrentLevel + "_" +  NewStageIndex));
        CurrentStageName = "Stage" + "1" + "_" + NewStageIndex;

        CurrentStageWidth = PlayerScript.CurrentStage.gameObject.GetComponent<BoxCollider2D>().bounds.size.x;
        NewStage.transform.position = new Vector3(CurrentStageWidth - (StageController.Acceleration) - 1, 
                                                    PlayerScript.CurrentStage.transform.position.y, 
                                                    PlayerScript.CurrentStage.transform.position.z);
    }
    void FindNumberOfLevels()
    {
        //determine the current stage - placeholder for now

        CurrentStage = GameObject.FindWithTag("Stage");
        CurrentStageName = CurrentStage.ToString().Substring(0, 8);
        CurrentLevel = Convert.ToInt32(CurrentStage.ToString().Substring(5, 1));

        //search for how much files or prefabs exist for this level - eg there is 2 pre fabs for stage 1_x right now
        AllLevels = Resources.LoadAll("");
        //set start, current and end indexes based on prefabs found
        
        StartStageIndex = 1;
        EndStageIndex = 3;
}
}
