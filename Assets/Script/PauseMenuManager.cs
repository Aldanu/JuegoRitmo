using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    public GameObject marker;
    public GameObject[] gameObjects;
    public GameObject settings;
    public GameObject player;

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
            print("Apreto enter el seleccion: "+selection);
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
        print("Seleccion: "+selection);
        switch (selection)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                gameObject.SetActive(false);
                settings.SetActive(true);
                break;
            case 2:
                print("Volver al menu");
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
