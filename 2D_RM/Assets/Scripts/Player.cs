using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float Speed = 10.5f;
    [Header("跳越高度"), Range(0, 3000)]
    public int Jumph = 100;
    [Range(0, 200)]
    public float HP = 100;
    [Header("是否在地板上"), Tooltip("這是否在地板上")]
    public bool isGrounded = false;
    [Header("子彈"), Tooltip("這是子彈")]
    public GameObject Bullet;
    [Header("子彈生成點"), Tooltip("這是子彈生成點")]
    public Transform traB;
    [Range(0, 5000)]
    public int BulletSpeed = 800;
    [Header("開槍音效"), Tooltip("這是開槍音效")]
    public AudioClip BiuAudio;
    private AudioSource Aud;
    private Rigidbody2D rig;
    private Animator Ani;
    #endregion

    #region 事件
    private void Start()
    {
        //利用程式取的元件
        //傳回元件 取得元件<元件名稱>() - <泛型>
        //取得跟此腳本同一層的原件
        rig = GetComponent<Rigidbody2D>();
    }

    //一秒約執行60次
    private void Update()
    {
        Move();
        Jump();
    }

    [Header("判斷地板碰撞的位移與半徑")]
    public Vector3 groundOffset;
    public float groundRafius = 0.2f;

    //繪製圖式 - 輔助編輯時的圖形線條
    private void OnDrawGizmos()
    {
        // 1. 指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        // 2. 繪製圖形
        //transform 可以抓到此腳本同一層的變形元件
        //繪製球體(中心點.半徑)
        //物件的右方 X 軸 : transform.right
        //物件的右方 Y 軸 : transform.up
        //物件的右方 Z 軸 : transform.forward
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y , groundRafius);
    }
    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //1. 要抓到玩家按下左右鍵的資訊
       float h = Input.GetAxis("Horizontal");
        print("水平的值: " + h);
        //2. 使用左右鍵的資訊控制腳色
        //剛體.加速度 = 二維向量(水平 * 速度 * 一幀的時間, 指定回原本的 Y 軸加速度 )
        //一幀的時間 - 解決不同效能的裝置速度差問題
        rig.velocity = new Vector2(h * Speed * Time.deltaTime, rig.velocity.y);

        //如果按下 D 面向右邊 0 0 0
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }    
        //否則 如果按下A面向左邊 0 180 0
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //如果 玩家 按下 空白鍵 就 往上跳躍
        //判斷式C#
        //傳回值為布林值的方法可以當成布林值使用
        //@ 判斷布林值是否等於true寫法
        //1. isGrounded == true(原本寫法)
        //2. isGrounded (簡寫)
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            //剛體.添加推力(二維向量)
            rig.AddForce(new Vector2(0,Jumph));
        }
        //碰到的物件= 2D物理.覆蓋圓形(中心點.半徑)
        //圖層語法 : 1<< 圖層邊號(LayerMask int)
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRafius, 1 << 8);

        print("碰到的物件:" + hit.name);

        //如果碰到的物件 存在 並且 碰到的物件名撐 等於 地板 就代表在地板上
        //並且&& (SHIFT+7)
        //等於 ==
        //或者 || (SHIFT + \)
        //或者 名稱 等於 跳台

        if (hit && (hit.name =="地板" || hit.name == "跳台"))
        {
            isGrounded = true;
        }
        //否則不在地板上
        //否則 else
        //語法: else{ 程式區塊 } - 僅能寫在 if 下方
        else
        {
            isGrounded = false;
        }
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {
        
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="hurt">造成的傷害</param>
    private void Hit(float hurt)
    {
        
    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <returns>是否死亡</returns>
    private bool Dead()
    {
        return false;
    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="pro">道具名稱</param>
    private void EatProp (string prop)
        {
        
        }


#endregion
}
