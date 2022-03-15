using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{   
    public GameObject saber;
    Renderer saberRenderer;
    // Start is called before the first frame update
    void Start()
    {
        saberRenderer = saber.GetComponent<Renderer>();
        saberRenderer.material.SetColor("_Color", Color.red);
        Debug.Log(saberRenderer.material.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
