using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schepertwtg : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i <= 1000; i++)
        {
            Instantiate(gameObjects[Random.Range(0,gameObjects.Count)], new Vector3(i * 2, 5, 0), Quaternion.identity);
        }
    }
}
