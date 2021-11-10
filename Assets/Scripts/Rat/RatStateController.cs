using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateController : MonoBehaviour
{
    public bool isIdle = true;
    public bool isColliding = false;
    public bool isAgressive = false;
    public NightDay nightDayController;

    private void Start()
    {
        nightDayController=GameObject.Find("NightDayController").GetComponent<NightDay>();
    }
    private void Update()
    {
        IsAgressive();
    }

    private void IsAgressive()
    {
        if (nightDayController.isDay)
        {
            isAgressive = false;
        }
        else
        {
            isAgressive = true;
        }
    }
}
