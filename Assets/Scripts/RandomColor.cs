using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Color col;
    Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.red;
        colors[1] = new Color32( 143 , 0 , 254, 1 );
        colors[2] = Color.green;
        col = colors[Random.Range(0, colors.Length-1)];
    }
}
