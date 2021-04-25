using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [Header("汽車的 cc 數")]
    [Tooltip("這是汽車的 cc 數")]
    [Range(1000,5000)]
    public int cc = 2000;
    [Header("汽車的重量"), Tooltip("這是汽車的重量。"), Range(0.5f,10)]
    public float weight = 1.5f;
    [Header("汽車的品牌")]
    public string brand = "BMW";
    [Header("有沒有天窗")]
    public bool hasWindow =true ;


    public Color color;
    public Color red = Color.red;
    public Color mycolor =new Color(0.3f, 0 ,0.6f);
    public Color mycolor2 = new Color(0, 0.5f, 0.5f, 0.5f);

    //座標二維-四維 Vector2 Vector3 Vector4
    public Vector2 v2;
    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2my = new Vector2(7, 9);

    public Vector3 v3 = new Vector3(1, 2, 3);
    public Vector4 v4 = new Vector4(1, 2, 3, 4);

    public KeyCode key1;
    public KeyCode key2 = KeyCode.A;      //不指定為 None (無)
    public KeyCode key3 = KeyCode.Mouse0; //左0 右1 滾輪2
    public KeyCode key4 = KeyCode.Joystick1Button0;

    //遊戲物件 與元件
    //遊戲物件 GameObject
    public GameObject obj1;
    public GameObject obj2;
    //元件 Component - 屬性面板上可摺疊的
    public Transform tra;
    public SpriteRenderer spr;

}
 