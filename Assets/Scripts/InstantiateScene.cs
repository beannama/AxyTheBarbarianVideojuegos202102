using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScene : MonoBehaviour
{
    //Prefabs
    public GameObject Axy;
    public GameObject Gazer;
    public GameObject DrunkenSkeleton;
    //Initial positions
    public Vector2 AxyInitialPos = new Vector2(0,0);
    public Vector2 GazerInitialPos = new Vector2(-10,-10);
    public Vector2 DrunkenSkeletonInitialPos = new Vector2(10,10);

    void Start()
    {
        GameObject InstantiatedAxy = Instantiate(Axy,AxyInitialPos,Quaternion.identity);
        transform.GetComponent<ChangeColors>().player = InstantiatedAxy;
        InstantiatedAxy.AddComponent<Movement>();
        Instantiate(Gazer, GazerInitialPos, Quaternion.identity);
        Instantiate(DrunkenSkeleton, DrunkenSkeletonInitialPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
