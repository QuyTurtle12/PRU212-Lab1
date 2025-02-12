using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStar : MonoBehaviour
{
    public static GameManager instance;
    public GameObject StarPrefab;
    public float minInstantiatevalue;
    public float maxInstantiatevalue;

    public float StarDestroyTime = 10f;

   
 
    private void Start()
    {
        InvokeRepeating("InstantiateStar", 1f, 2f);
    }


    void InstantiateStar()
    {
        Vector3 Starpos = new Vector3(Random.Range(minInstantiatevalue, maxInstantiatevalue), 8f);
        GameObject Star = Instantiate(StarPrefab, Starpos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(Star, StarDestroyTime);
    }
 
}