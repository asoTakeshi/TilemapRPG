using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("移動スピード")]
    public float moveSpeed;

    private Rigidbody2D rb;   //コンポーネントの取得用

    private float horizontal;  //x軸(水平・横）方向の入力値の値の代入用
    private float vertical;    //y 軸(垂直・縦)方向の入力の値の代入用
    
    void Start()
    {
        // このスクリプトがアタッチされているゲームオブジェクトにアタッチされているコンポーネントの中から、<指定>したコンポーネントの情報を取得して、左辺に用意した変数に代入
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // InputManager の Horizontal に登録してあるキーが入力されたら、水平(横)方向の入力値として代入
        horizontal = Input.GetAxis("Horizontal");

        // InputManager の Vertical に登録してあるキーが入力されたら、水平(横)方向の入力値として代入
        vertical = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate()
    {
        // 移動
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // velocity(速度)に新しい値を代入して、ゲームオブジェクトを移動させる
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
    
}

