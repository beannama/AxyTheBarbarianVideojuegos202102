using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScene : MonoBehaviour
{
    //Prefabs
    public GameObject Axy;
    public GameObject Gazer;
    public GameObject DrunkenSkeleton;
    public GameObject Arrow;
    //Initial positions
    public Vector2 AxyInitialPos = new Vector2(0,0);
    public Vector2 GazerInitialPos = new Vector2(2,-3);
    public Vector2 DrunkenSkeletonInitialPos = new Vector2(10,10);

    GameObject InstantiatedGazer;
    GameObject InstantiatedDrunkenSkeleton;
    void Start()
    {
        GameObject InstantiatedAxy = Instantiate(Axy,AxyInitialPos,Quaternion.identity);
        transform.GetComponent<ChangeColors>().player = InstantiatedAxy;

        InstantiatedGazer = Instantiate(Gazer, GazerInitialPos, Quaternion.identity);

        InstantiatedDrunkenSkeleton = Instantiate(DrunkenSkeleton, DrunkenSkeletonInitialPos, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InstantiatedGazer.GetComponent<GazerMovement>().speed>0)
        {
            InstantiatedDrunkenSkeleton.GetComponent<DrunkenSkeletonArrowThrow>().AttackSpeed = 1f / InstantiatedGazer.GetComponent<GazerMovement>().speed;
        }
    }
}
