using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private GameObject player;
    private int damage;
    private int left;
    public int Health = 30;

    [Header("Attack Distance Settings")]
    public float Coldown;
    private float _coldown;
    public GameObject BulletPrefab;
    public float BulletForce;
    public float BulletTime;
    
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        damage= (int)(player.GetComponent<Player>().damage);
        _coldown = Coldown;
    }

    // Update is called once per frame
    void Update()
    {
        AttackDistance();
    }

    void AttackDistance()
    {
        Coldown -= Time.deltaTime;
        if (Coldown <= 0)
        {
            GameObject newBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            newBullet.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.forward * BulletForce, ForceMode2D.Impulse);
            newBullet.gameObject.tag = "EnemyBullet";
            newBullet.transform.rotation = Quaternion.Euler(0,0,0);
            Coldown = _coldown;
            Destroy (newBullet, BulletTime);
        }
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
