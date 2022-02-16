using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // save offset from view to lightsaber to have the lightsaber in the same place of the screen.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; // allways move lightsaber to the position of the phone + the offset
    }
}
