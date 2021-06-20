using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 150f;
    [Header("攻擊力"), Range(0, 100)]
    public float attack = 10f;
    [Header("攻擊冷卻"), Range(0, 30)]
    public float cd = 3;
    [Header("血量"), Range(0, 500)]
    public float hp = 200f;
    [Header("追蹤範圍"), Range(0, 50)]
    public float radiusTrack = 5;
    [Header("攻擊範圍"), Range(0, 30)]
    public float radiusAttack = 2;


    private Transform player;
    private Rigidbody2D rig;
    private Animator ani;
    /// <summary>
    /// 計時器 :紀錄攻擊冷卻
    /// </summary>
    private float timer;
    /// <summary>
    /// 原始速度
    /// </summary>
    private float speedOriginal;

    #endregion

    #region 事件
    private void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        //玩家 = 遊戲物件.尋找 ("物件名稱") - 搜尋場景內所有物件
        //transform.Find("子物件名稱") - 搜尋此物件的子物件
        player = GameObject.Find("玩家").transform;

        //讓敵人一開始就攻擊
        timer = cd;
        speedOriginal = speed;       //取得原始速度
    }
    [Header("偵測地板的位移與半徑")]
    public Vector3 groundOffset;
    public float groundRadius = 0.1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrack);

        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusAttack);

        Gizmos.color = new Color(0.6f, 0.9f, 1, 0.7f);
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);
    }

    private void Update()
    {
        Move();
    }

    #endregion

    #region 方法
    /// <summary>
    /// 移動: 偵測是否進入追蹤範圍
    /// </summary>
    private void Move()
    {
        //如果 玩家跟敵人的 距離 小於等於 追蹤範圍 就移動

        //距離 = 三為向量.距離(A點 . B點)
        float dis = Vector3.Distance(player.position, transform.position);

        //如果 距離 小於等於攻擊範圍 就攻擊
        if (dis <= radiusAttack)
        {
            Attack();
        }


        //如果玩家跟敵人的距離小於等於追蹤範圍就移動
        else if (dis <= radiusTrack)
        {
            rig.velocity = transform.right * speed * Time.deltaTime;
            ani.SetBool("走路開關", true);
            LookAtPlayer();
            CheckGround();
        }
        else
        {
            ani.SetBool("走路開關", false);
        }
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        //如果 計時器 <= 攻擊冷卻 就累加

        if (timer <= cd)
        {
            timer += Time.deltaTime;
        }

        //否則 攻擊 並將計時器冷卻
        else
        {
            timer = 0;
            ani.SetTrigger("攻擊觸發");
        }
    }

    /// <summary>
    /// 面向玩家
    /// </summary>
    private void LookAtPlayer()
    {
        //如果 敵人 x 大於 玩家 x  就代表玩家在左邊 角度 180
        if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //否則 敵人 x 小於 玩家 就代表玩家在右邊 角度0
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1 << 8);

        if (hit && (hit.name == "地板" || hit.name == "跳台"))
        {
       
            speed = speedOriginal;
        }

        else
        {

            speed = 0;
        }

    }
        #endregion

    
}
