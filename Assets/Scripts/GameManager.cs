using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject MeteorPrefab;
    public float minInstantiatevalue;
    public float maxInstantiatevalue;

    public float MeteorDestroyTime = 10f;

    [Header("Particle Effects")]
    public GameObject explosion;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating("InstantiateMeteor", 1f, 2f);
    }


    void InstantiateMeteor()
    {
        Vector3 Meteorpos = new Vector3(Random.Range(minInstantiatevalue, maxInstantiatevalue), 8f);
        GameObject Meteor = Instantiate(MeteorPrefab, Meteorpos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(Meteor, MeteorDestroyTime);
    }
 
}