using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float Speed =10.5f;
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




}
