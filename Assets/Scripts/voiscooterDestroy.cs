using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class voiscooterDestroy : MonoBehaviour
{
    public GameObject partSystem;
    public AudioSource hitSound;
    public AudioSource crystalSound;

    private void OnCollisionEnter(Collision collision){
       if(collision.gameObject.tag == "voi-scooter") {
           GetComponent<ScoreCount>().ScooterDestroyed();
           Transform pos = collision.gameObject.transform;
           GameObject partInstance = Instantiate(partSystem, pos);
           partInstance.GetComponent<ParticleSystem>().Play();
           hitSound.Play();
           Destroy(collision.gameObject);
       }
    }
    public void gainCrystal(Color col) {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", col);
        crystalSound.Play();
    }
};