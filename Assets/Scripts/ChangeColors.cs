using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    private bool backgroundBoolean;
    private bool characterBoolean;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = GameObject.Find("Main Camera");
        //mainCamera = Camera.main.gameObject;
        //player = GameObject.Find("Player");

        backgroundBoolean = false;
        characterBoolean = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j") && !backgroundBoolean)
        {
            backgroundBoolean = true;
            mainCamera.GetComponent<Camera>().backgroundColor = Color.green;
        }
        else if (Input.GetKeyDown("j") && backgroundBoolean)
        {
            backgroundBoolean = false;
            mainCamera.GetComponent<Camera>().backgroundColor = Color.cyan;
            
        }

        if (Input.GetKeyDown("k") && !characterBoolean)
        {
            characterBoolean = true;
            player.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (Input.GetKeyDown("k") && characterBoolean)
        {
            characterBoolean = false;
            player.GetComponent<SpriteRenderer>().color = Color.white;

        }
    }
}
