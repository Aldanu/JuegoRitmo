using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public new GameObject name;
    public GameObject image;
    public int selected;
    public Sprite kaladin;
    public Sprite jasnah;
    
    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
        name.GetComponent<Text>().text = "Kaladin";
        image.GetComponent<Image>().sprite = kaladin;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (selected == 0)
            {
                selected = 1;
            }
            else
            {
                selected = 0;
            }
            Change(selected);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (selected == 1)
            {
                selected = 0;
            }
            else
            {
                selected = 1;
            }
            Change(selected);
        }

        
        if (Input.GetKeyUp("return"))
        {
            optionSelected(selected);
        }
    }

    private void Change(int selected)
    {
        if (selected == 0)
        {
            name.GetComponent<Text>().text = "Kaladin";
            image.GetComponent<Image>().sprite = kaladin;
        }

        if (selected == 1)
        {
            name.GetComponent<Text>().text = "Jasnah";
            image.GetComponent<Image>().sprite = jasnah;
        }
    }
    
    void optionSelected(int selection)
    {
        switch (selection)
        {
            case 0:
                SceneManager.LoadScene("InGame");
                break;
            case 1:
                SceneManager.LoadScene("InGameB");
                break;
        }
    }
}
