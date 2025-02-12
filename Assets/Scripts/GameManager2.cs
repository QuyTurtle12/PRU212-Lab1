using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;
    public GameObject Meteor2Prefab;
    public float minInstantiatevalue;
    public float maxInstantiatevalue;

    public float Meteor2DestroyTime = 10f;

    [Header("Particle Effects")]
    public GameObject explosion;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating("InstantiateMeteor2", 1f, 2f);
    }


    void InstantiateMeteor2()
    {
        Vector3 Meteor2pos = new Vector3(Random.Range(minInstantiatevalue, maxInstantiatevalue), 8f);
        GameObject Meteor2 = Instantiate(Meteor2Prefab, Meteor2pos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(Meteor2, Meteor2DestroyTime);
    }
 
}