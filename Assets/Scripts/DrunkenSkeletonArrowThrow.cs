using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkenSkeletonArrowThrow : MonoBehaviour
{
    public GameObject Arrow;
    Vector3 pos;
    public float AttackSpeed = 1f;
    public int intRange = 3;

    void Start()
    {
        StartCoroutine(ThrowArrowLoop());
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
    }

    IEnumerator ThrowArrowLoop()
    {
        Vector3 newPos = RandomVectorInRange(intRange);
        GameObject InstantiatedArrow = Instantiate(Arrow, newPos, Quaternion.identity);
        InstantiatedArrow.transform.Rotate(new Vector3(0, 0, -90));
        yield return new WaitForSeconds(AttackSpeed * Time.deltaTime);
        Destroy(InstantiatedArrow);

        StartCoroutine(ThrowArrowLoop());

    }

    Vector3 RandomVectorInRange(int range)
    {
        Vector3 returnedVector3;

        int xSkeletonPosition = (int)pos.x;
        int ySkeletonPosition = (int)pos.y;

        float xRange = Random.Range(xSkeletonPosition - range, xSkeletonPosition + range);
        float yRange = Random.Range(ySkeletonPosition - range, ySkeletonPosition + range);

        returnedVector3 = new Vector3(xRange, yRange, 0); 

        return returnedVector3;
    }
}
