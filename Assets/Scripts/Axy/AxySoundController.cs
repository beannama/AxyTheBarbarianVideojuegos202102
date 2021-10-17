using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AxySoundController : MonoBehaviour
{
    AudioSource audioSrc; // not used yet

    public void MakeSound(string log)
    {
        EditorApplication.Beep();
        //audioSrc.Play(); //For further use
        Debug.Log(log);

    }
}
