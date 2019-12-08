using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [Header("도착오브젝트")]
    public GameObject target;
    static bool arrive = false; //도착여부

    [Header("손님종류")]
    public Customer.CustomerType type;

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

    #region [애니메이션]
    void Ani()
    {
        ani.SetBool("Move", !arrive);
    }
    #endregion

    #region [이동]

    void Move()
    {
        if (!arrive)
        {
            if (!target)
            {
                /*Debug.LogError("Target이 지정되지않았습니다. ");*/
                return;
            }

            Vector2 dic = target.transform.position - transform.position;
            dic = dic.normalized;
            GetComponent<Rigidbody2D>().velocity = dic * speed * Time.deltaTime;
            if (Vector2.Distance(target.transform.position, transform.position) < speed / 60f)
                arrive = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Debug.Log("End");
        }
    }

    #endregion
}
