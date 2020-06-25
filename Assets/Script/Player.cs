using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject canvas;
    public Animator anim;
    public Text lifeText;
    public float speed = 1.0f;
    public float life;
    public float attack;
    public float range;
    public ArrayList upgrades=new ArrayList();
    public GameObject music;
    public GameObject beater;
    private bool beated=true;
    
    // Use this for initialization
    void Start()
    {
        lifeText.text = "Vida: " + life;
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            keys();
        }

        if (life < 1)
        {
            gameObject.GetComponent<SceneChange>().scene = "GameOver";
            gameObject.GetComponent<SceneChange>().startSceneGame();
        }
        beating();
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }

    private void keys()
    {
        if (Input.GetKeyDown("escape"))
        {
            paused();
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            anim.SetTrigger("Left");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            anim.SetTrigger("Down");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            anim.SetTrigger("Up");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            anim.SetTrigger("Right");
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("Attack");
        }    
    }
    
    private void beating()
    {
        
        if (beater.transform.localScale.x > 4.4)
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("ataque");
                life += 3;
            }
            else if(beated)
            {
                beated = false;
                life--;
            }
            
        }
        else
        {
            beated = true;
            if (Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("miss");
                life--;
            }
        }
        lifeText.text = "Vida: " + life;
    }

    private void paused()
    {
        if (!isPaused)
        {
            print("Paused");
            Time.timeScale = 0.0f;
            isPaused = true;
            canvas.SetActive(true);
            music.GetComponent<AudioSource>().Pause();
        }
        else if (isPaused)
        {
            print("Unpaused");
            Time.timeScale = 1.0f;
            isPaused = false;
            canvas.SetActive(false);
            music.GetComponent<AudioSource>().Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Debug.Log("Recogido: "+other.gameObject.name);
            PowerUp(other.gameObject.name);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Collider"))
        {
            other.isTrigger=true;
            other.enabled = true;
        }
        
    }

    private void PowerUp(String name){
        if (name.Equals("Armor(Clone)"))
        {
            upgrades.Add(0);
            life += 35;
        }
        if (name.Equals("Boots(Clone)"))
        {
            upgrades.Add(1);
            speed += 2;
        }
        if (name.Equals("Brazalete(Clone)"))
        {
            upgrades.Add(2);
            attack += 1;
        }
        if (name.Equals("Brazalete 2(Clone)"))
        {
            upgrades.Add(3);
            attack += 2;
        }
        if (name.Equals("Casco(Clone)"))
        {
            upgrades.Add(4);
            life += 15;
        }
        if (name.Equals("Collar(Clone)"))
        {
            upgrades.Add(5);
            speed += 1;
        }
        if (name.Equals("Glove 2(Clone)"))
        {
            upgrades.Add(6);
            range += 2;
        }
        if (name.Equals("Glove(Clone)"))
        {
            upgrades.Add(7);
            range += 1;
        }
    }
}