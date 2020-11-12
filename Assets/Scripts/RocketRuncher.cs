using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class RocketRuncher : MonoBehaviour
{
    public GameObject grenadePrefab;

    public float propusionForce;

    private Transform mytransform;

    public AudioSource reload;

    void Start()
    {
        SetInitialReferences();
    }

    void Update()
    {

    }

    public void SpawnGrenade()
    {
        GameObject granade = (GameObject)Instantiate(grenadePrefab, mytransform.transform.TransformPoint(0, -.05f, 0), mytransform.rotation);
        granade.GetComponent<Rigidbody>().AddForce(mytransform.forward * propusionForce, ForceMode.Impulse);
        Destroy(granade, 1f);
    }

    void SetInitialReferences()
    {
        mytransform = transform;
    }
}
