using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneFinder2 : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject prefab;
    private Vector3 offset;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Update()
    {

    }

   
    public void Place()
    {
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits))
        {
            if (hits.Count > 0)
            {
                offset = new Vector3(Random.Range(-1,1),0,Random.Range(-1,1));
                Instantiate(prefab, hits[0].pose.position + offset, Quaternion.identity, transform);
            }
        }
    }
}
