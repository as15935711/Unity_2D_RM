using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIStaic : MonoBehaviour
{
    //認識靜態API
    //包含關鍵 static 就是靜態

    
    private void Start()
    {
        #region 認識靜態屬性與方法
        //練習取得靜態屬性 Static Properties
        //語法
        //類別名稱. 靜態屬性
        float r = Random.value;
        print("隨機值:" + r);                    //隨機.值 
          

        //練習存放靜態屬性 Static Properties
        //有顯示Read Only 的屬性不能存放
        //語法
        //類別名稱.靜態屬性名稱 指定 值;
        Cursor.visible = false;                  //指標 可見度

        // 練習使用靜態方法 Static Methods
        //語法
        //類別名稱.靜態屬性 (應對的參數)
        int attack = Random.Range(100, 300);
        print("隨機攻擊力:" + attack);

        float n = Mathf.Abs(-99.9f);
        print("絕對值結果 :" + n);
        #endregion

        #region 練習
        /*int count = Camera.allCameras.Length;
        print("所有攝影機的數量" + count + "Cameras");*/

        print("攝影機數量:" + Camera.allCamerasCount);
        print("重力:" + Physics2D.gravity);
        print("2D的重力大小設定為" + Physics2D.gravity);
       



        #endregion
    }
    private void Update()
    {
        #region 練習
        print("是否按下任意鍵:" + Input.anyKeyDown);
        print("遊戲時間:" + Time.time);
        #endregion
    }
}
