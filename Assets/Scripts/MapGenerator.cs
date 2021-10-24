using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Wall = null;
    public GameObject Exit = null;
    private string Load;
    private string id;
    // Start is called before the first frame update
    void Start ()
    {
        TextAsset t1 = (TextAsset)Resources.Load("lvlt", typeof(TextAsset));
        string s = t1.text;
        int i;
        int y = 10;
        int x = -20;
        s = s.Replace("\n","");
        for (i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            { 
                GameObject t;
                t = (GameObject)(Instantiate (Wall, new Vector2(x, y), Quaternion.identity));
                x += 1;
            }
            else if (s[i] == '2')
            {
                GameObject t;
                t = (GameObject)(Instantiate (Exit, new Vector2(x, y), Quaternion.identity));
                x += 1;
            }
            else if (s[i] == '*')
            {
                y -= 1;
                x = -21;
            }
            else {
                x += 1;
            }
            
        }
    }
}