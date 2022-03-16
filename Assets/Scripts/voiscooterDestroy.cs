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

    void Start() {
        StartCoroutine(crystalsInRange());
    }

    void gainCrystal(Color col) {
        GetComponent<Renderer>().material.SetColor("_EmissionColor", col);
        crystalSound.Play();
    }

    IEnumerator crystalsInRange() {
        GameObject[] crystals = GameObject.FindGameObjectsWithTag("crystal");
        foreach (var crystal in crystals)
        {
            float dist = Vector3.Distance(gameObject.transform.position, crystal.transform.position);
            if(dist < 10f) {
                gainCrystal(crystal.GetComponent<RandomColor>().col);
                Destroy(crystal);
            }
        }
        yield return new WaitForSeconds(2f);
        crystalsInRange();
    }
    private void OnCollisionEnter(Collision collision){
       if(collision.gameObject.tag == "voi-scooter") {
           Transform pos = collision.gameObject.transform;
           GameObject partInstance = Instantiate(partSystem, pos);
           partInstance.GetComponent<ParticleSystem>().Play();
           hitSound.Play();
           Destroy(collision.gameObject);
       }
    }
};