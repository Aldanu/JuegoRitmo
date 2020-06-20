using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject marker;
    public GameObject[] gameObjects;
    public GameObject settings;

    private int selection;
    // Start is called before the first frame update
    void Start()
    {
        selection = 0;
        marker.transform.position = new Vector3(gameObjects[selection].transform.position.x, gameObjects[selection].transform.position.y-17, gameObjects[selection].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("return"))
        {
            optionSelected(selection);
        }
        else
        {
            if (Input.GetKeyUp("right"))
            {
                if (selection<gameObjects.Length-1)
                {
                    selection++;
                }
                else
                {
                    selection = 0;
                }
            }

            if (Input.GetKeyUp("left"))
            {
                if (selection>0)
                {
                    selection--;
                }
                else
                {
                    selection = gameObjects.Length-1;
                }
            }
            marker.transform.position = new Vector3(gameObjects[selection].transform.position.x, gameObjects[selection].transform.position.y-17, gameObjects[selection].transform.position.z);
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
                gameObject.SetActive(false);
                break;
            case 2:
                gameObject.SetActive(false);
                settings.SetActive(true);
                break;
            case 3:
                ExitGame();
                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
