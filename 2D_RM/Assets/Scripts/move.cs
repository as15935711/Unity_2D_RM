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
    public mycolor =now Color(0.3, 0 ,0.6f);


}
