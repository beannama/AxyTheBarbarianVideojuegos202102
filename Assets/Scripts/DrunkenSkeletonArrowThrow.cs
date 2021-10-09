using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkenSkeletonArrowThrow : MonoBehaviour
{
    public GameObject Arrow;
    public float AttackSpeed;
    public float Range = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowArrowLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThrowArrowLoop()
    {
        float xRandom = Random.Range(transform.position.x - Range / 2, transform.position.x + Range / 2);
        float yRandom = Random.Range(transform.position.y - Range / 2, transform.position.y + Range / 2);
        GameObject InstantiatedArrow = Instantiate(Arrow,new Vector2(xRandom,yRandom),Quaternion.identity);
        InstantiatedArrow.transform.Rotate(new Vector3(0,0,-90));
        yield return new WaitForSeconds(AttackSpeed);
        Destroy(InstantiatedArrow);
        StartCoroutine(ThrowArrowLoop());
    }
}
