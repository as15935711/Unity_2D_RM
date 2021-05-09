using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float Speed = 10.5f;
    [Header("跳越高度"), Range(0, 3000)]
    public int Jump = 100;
    [Range(0, 200)]
    public float HP = 100;
    [Header("是否在地板上"), Tooltip("這是否在地板上")]
    public bool inFloor = false;
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

    #region 方法
    private void Start()
    {
        //利用程式取的元件
        //傳回元件 取得元件<元件名稱>() - <泛型>
        //取得跟此腳本同一層的原件
        rig = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
    }
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

    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump_()
    {
       //如果 玩家 按下 空白鍵 就 往上跳躍
       //判斷式C#

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
