using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class voiscooterDestroy : MonoBehaviour
{
    public GameObject partSystem;
    // Start is called before the first frame update
    void Start()

    {

    }

    // Update is called once per frame
    void Update()

    {

    }

    private void OnCollisionEnter(Collision collision){
       if(collision.gameObject.tag == "voi-scooter") {
           Transform pos = collision.gameObject.transform;
           GameObject partInstance = Instantiate(partSystem, pos);
           partInstance.GetComponent<ParticleSystem>().Play();
           Destroy(collision.gameObject);
       }
    }
};