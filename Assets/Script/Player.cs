using System.Collections;
using System.Collections.Generic;
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
    public int[] upgrades;
    
    // Use this for initialization
    void Start()
    {
        lifeText.text = "Vida: " + life;
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !isPaused)
        {
            print("Paused");
            Time.timeScale = 0.0f;
            isPaused = true;
            canvas.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && isPaused)
        {
            print("Unpaused");
            Time.timeScale = 1.0f;
            isPaused = false;
            canvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            anim.Play("sprite");
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("ataque");
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
    }
    

}