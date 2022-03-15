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
    private int spawnRange = 3;
    private float spawnDelay = 5f;
    private float destroyDelay = 60f;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Place());
        StartCoroutine(Despawn());
    }
    IEnumerator Place()
    {
        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits))
        {
            if (hits.Count > 0)
            {
                offset = new Vector3(Random.Range(-1*spawnRange,spawnRange),0,Random.Range(-1*spawnRange,spawnRange));
                Quaternion rotation = Quaternion.Euler(0,Random.Range(0,360),0);
                Instantiate(prefab, hits[0].pose.position + offset, rotation, transform);
            }
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Place());
    }
    IEnumerator Despawn() {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
