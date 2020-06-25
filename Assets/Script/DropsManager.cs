using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropsManager : MonoBehaviour
{
    public GameObject[] myObjects;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], new Vector3(-2.581f, 6.195f, 0), Quaternion.identity) as GameObject;
        instantiatedObject.SetActive(true);
    }


}
