using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int number;
    public float Coldown;
    public GameObject enemy;
    private float _coldown;
    // Start is called before the first frame update
    void Start()
    {
        _coldown = Coldown;
    }

    // Update is called once per frame
    void Update()
    {
        Coldown -= Time.deltaTime;
        if (Coldown <= 0 && number>0)
        {
            Instantiate(enemy, new Vector3(-13.5f, -6.65f, 0), Quaternion.identity);
            Coldown = _coldown;
            number--;
        }
    }
}
