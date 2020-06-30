using UnityEngine;

public class EnemySeeker : MonoBehaviour
{
    private GameObject player;
    private int damage;
    private int left;
    public int Health = 15;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        damage= (int)(player.GetComponent<Player>().damage);
        
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
