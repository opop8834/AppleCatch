using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;     // 주사위를 던져서 10까지 나오는 수중 2이하가 나오면 폭탄이 나오게 해줄 것이다.
    float speed = -0.03f;
    // Start is called before the first frame update
    public void SetParameter(float span, float speed, int ratio)  // 난이도 일괄조정을 위해 선언
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1,11); // 1부터 10까지의 주사위
            if (dice <= this.ratio)   //2이하의 수가 나오면 폭탄
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else{
                item = Instantiate(applePrefab) as GameObject;
            }
            float x = Random.Range(-1, 2);    // -1부터 1까지의 범위이다
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;


        }
    }
}
