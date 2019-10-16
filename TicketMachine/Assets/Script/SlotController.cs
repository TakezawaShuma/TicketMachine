using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{

    bool hitflag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// 支払い口にお金が触れた時フラグを立てる
    /// </summary>
    /// <param name="_collision"></param>
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (transform.tag == _collision.tag)
        {
            hitflag = true;
            Debug.Log("Enter");
        }
    }

    /// <summary>
    /// 支払い口からお金が離れたらフラグを下げる
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (transform.tag == _collision.tag)
        {
            hitflag = false;
            Debug.Log("Exit");
        }
    }

    /// <summary>
    /// ヒットフラグを取得する
    /// </summary>
    /// <returns></returns>
    public bool HitFlag { get { return hitflag; } }
}
