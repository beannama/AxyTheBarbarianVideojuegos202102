using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static GameObject Player = null;
    // Start is called before the first frame update
    static public void AttachToPlayer()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player!=null)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y,-10);
        }
    }
}
