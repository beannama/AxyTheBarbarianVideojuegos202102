using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AxySoundController : MonoBehaviour
{

    public void MakeSound(string log)
    {
        EditorApplication.Beep();
        Debug.Log(log);

    }
}
