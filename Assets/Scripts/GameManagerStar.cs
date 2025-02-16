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

        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        Vector3 Starpos = new Vector3(Random.Range(minX, maxX), Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 1f, 0);
        GameObject Star = Instantiate(StarPrefab, Starpos, Quaternion.Euler(0f, 0f, 180f));
        Destroy(Star, StarDestroyTime);
    }
 
}