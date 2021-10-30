using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Wall = null;
    public GameObject Exit = null;
    public GameObject Gazer = null;
    public GameObject Skeleton = null;
    public GameObject Player = null;
    private string Load;
    private string id;
    // Start is called before the first frame update
    void Start ()
    {
        TextAsset t1 = (TextAsset)Resources.Load("lvlt", typeof(TextAsset));
        string s = t1.text;
        int i;
        float y = 10.5f;
        float x = -20.5f;
        s = s.Replace("\n","");
        for (i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            { 
                GameObject t;
                t = (GameObject)(Instantiate (Wall, new Vector2(x, y), Quaternion.identity));
                t.name = "Wall";
                x += 1f;
            }
            else if (s[i] == '2')
            {
                GameObject t;
                t = (GameObject)(Instantiate (Exit, new Vector2(x, y), Quaternion.identity));
                t.name = "Exit";
                x += 1f;
            }
            else if (s[i] == 'G')
            {
                GameObject t;
                t = (GameObject)(Instantiate(Gazer, new Vector2(x, y), Quaternion.identity));
                t.name = "Gazer";
                x += 1f;
            }
            else if (s[i] == 'S')
            {
                GameObject t;
                t = (GameObject)(Instantiate(Skeleton, new Vector2(x, y), Quaternion.identity));
                t.name = "DrunkenSkeleton";
                x += 1f;
            }
            else if (s[i] == 'P')
            {
                GameObject t;
                t = (GameObject)(Instantiate(Player, new Vector2(x, y), Quaternion.identity));
                t.name = "Player";
                x += 1f;
            }
            else if (s[i] == '*')
            {
                y -= 1f;
                x = -21.5f;
            }
            else {
                x += 1f;
            }
            
        }
        GlobalController.Instantiate();
        CameraMovement.AttachToPlayer();
    }
}