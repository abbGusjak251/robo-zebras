using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Color col;
    private Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[3];
        colors[0] = Color.red;
        colors[1] = new Color32( 143 , 0 , 254, 1 );
        colors[2] = Color.green;
        col = colors[Random.Range(0, colors.Length)];
        GetComponent<Renderer>().material.SetColor("_Color", col);
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "lightsaber") {
            other.gameObject.GetComponent<voiscooterDestroy>().gainCrystal(col);
            Destroy(gameObject);
        }
    }
}
