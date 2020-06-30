using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroler : MonoBehaviour
{
    private GameObject player;
    private int damage;
    private int left;
    public int Health = 20;

    [Header("Patroling Settings")] 
    public Transform[] Points;
    public float Speed;
    public float MinDistance;
    private int _index;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        damage= (int)(player.GetComponent<Player>().damage);
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, Points[_index].position) < MinDistance)
        {
            if (_index == Points.Length - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }
        }

        transform.position = Vector3.Lerp(transform.position, Points[_index].position, Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            if (Health > 0)
            {
                Health -= damage;
            }
            else
            {
                player.GetComponent<Player>().enemies=(player.GetComponent<Player>().enemies-1);
                left = player.GetComponent<Player>().enemies;
                player.GetComponent<Player>().enemiesLeft.text = "Derrota a:\n" + (left-1) + " enemigos";
                Destroy(gameObject);
            }
            
        }
    }
}
