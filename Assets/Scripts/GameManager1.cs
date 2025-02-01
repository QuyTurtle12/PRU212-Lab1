using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;
    public GameObject Meteor1Prefab;
    public float minInstantiatevalue;
    public float maxInstantiatevalue;

    public float Meteor1DestroyTime = 10f;

    [Header("Particle Effects")]
    public GameObject explosion;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating("InstantiateMeteor1", 1f, 2f);
    }


    void InstantiateMeteor1()
    {
        Vector3 Meteor1pos = new Vector3(Random.Range(minInstantiatevalue, maxInstantiatevalue), 8f);
        GameObject Meteor1 = Instantiate(Meteor1Prefab, Meteor1pos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(Meteor1, Meteor1DestroyTime);
    }
 
}