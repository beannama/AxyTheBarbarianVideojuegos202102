using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkenSkeletonArrowThrow : MonoBehaviour
{
    public GameObject Arrow;
    Vector2 pos;
    public float AttackSpeed = 1f;
    public int intRange = 3;

    void Start()
    {
        pos = transform.position;
        StartCoroutine(ThrowArrowLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThrowArrowLoop()
    {
        Vector2 newPos = RandomVectorInRange(intRange);
        GameObject InstantiatedArrow = Instantiate(Arrow, newPos, Quaternion.identity);
        InstantiatedArrow.name = "Arrow";
        InstantiatedArrow.transform.Rotate(new Vector3(0, 0, -90));
        yield return new WaitForSeconds(1f/AttackSpeed);
        Destroy(InstantiatedArrow);

        StartCoroutine(ThrowArrowLoop());

    }

    Vector2 RandomVectorInRange(int range)
    {
        Vector2 returnedVector2;

        int xSkeletonPosition = (int)pos.x;
        int ySkeletonPosition = (int)pos.y;

        float xRange = Random.Range(xSkeletonPosition - range, xSkeletonPosition + range) + 0.5f;
        float yRange = Random.Range(ySkeletonPosition - range, ySkeletonPosition + range) + 0.5f;

        returnedVector2 = new Vector2(xRange, yRange); 

        return returnedVector2;
    }
}
