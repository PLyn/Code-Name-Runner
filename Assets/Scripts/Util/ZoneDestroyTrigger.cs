using UnityEngine;
using System.Collections;

public class ZoneDestroyTrigger : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D col)
    {
        //change over to pooling in the future so it doesnt have to be recreated each time. currently destroys prefab when it hits it 
        Destroy(col.transform.root.gameObject);
    }
}
