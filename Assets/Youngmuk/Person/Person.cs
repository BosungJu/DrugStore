using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    //이동할 목표 오브젝트
    [Header("도착오브젝트")]
    public GameObject target;
    static bool arrive = false; //도착여부

    //이동속도
    [Header("이동속도")]
    public float speed;

    [Header("애니메이터")]
    public Animator ani;

    void Start()
    {
        
    }

    void Update()
    {
        Ani();
        Move();
    }

    //애니메이션
    void Ani()
    {
        ani.SetBool("Move", !arrive);
    }

    //이동
    void Move()
    {
        if (!arrive)
        {
            if (!target) { Debug.LogError("Target이 지정되지않았습니다. "); return; }
            Vector2 dic = target.transform.position - transform.position;
            dic = dic.normalized;
            GetComponent<Rigidbody2D>().velocity = dic * speed;
            if (Vector2.Distance(target.transform.position, transform.position) < speed/60f)
                arrive = true;
        }
        else
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
