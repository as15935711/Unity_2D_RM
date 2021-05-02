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
    private Rigidbody2D Rig;
    private Animator Ani;
    #endregion

    #region 方法
   

    private void Start()
    {

    }
    /// <summary>
    /// 移動
    /// </summary>
    private void move()
    {
       
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump_()
    {
       
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
