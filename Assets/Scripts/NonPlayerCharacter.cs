using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    [Header("会話イベント判定用")]
    public bool isTalking;         // true の場合は会話イベント中であるように扱う
    private DialogController dialogController;　　// DialogController スクリプトの情報を代入するための変数
    private Vector3 defaltPos;      //Vector3型に変数defaltPosを宣言
    private Vector3 offsetPos;　　　//Vector3型に変数offsetPosを宣言


    private void Start()
    {
        // 子オブジェクトにアタッチされている DialogController スクリプトを取得して変数に代入
        dialogController = GetComponentInChildren<DialogController>();
        //Vector3型の変数defaltPosに変数dialogControllerのtransform.positionを代入
        defaltPos = dialogController.transform.position;
        //Vector3型の変数offsetPosにdialogController.transform.position.xとdialogController.transform.position.y (yが- 5.5f)とdialogController.transform.position.zを代入
        offsetPos = new Vector3(dialogController.transform.position.x, dialogController.transform.position.y - 5.5f, dialogController.transform.position.z);
    }

    /// <summary>
    /// 会話開始
    /// </summary>
    public void PlayTalk(Vector3 playerPos)　　　// Vector3型のplayerPosの引数
    {

        // 会話イベントを行っている状態にする
        isTalking = true;

        //プレイヤーの位置を確認してウインドウを出す位置を決定する

        //プレイヤーの位置をPlayerController スクリプトより、プレイヤーキャラの位置情報が Vector3 型で届いてるため
        //playerPos.yの位置よりNPCのポジションが上の場合にif文を通る。NPCのポジションが上の場合はdialogController.transform.position
        //に代入された(offsetPos)の値を参考にしてウインドウを表示する。それ以外の場合は、(defaltPos)を参考にしてウインドウを表示する。

        if (playerPos.y < transform.position.y)    //playerPos.yがtransform.position.yより小さい時
        {
            //dialogController.transform.positionにoffsetPosを代入
            dialogController.transform.position = offsetPos; 
        }
        else
        {
            //それ以外の場合は、dialogController.transform.positionにdefaltPosを代入
            dialogController.transform.position = defaltPos;　　
        }

        // 会話イベントのウインドウを表示する
        dialogController.DisplayDialog();

        //Debug.Log("会話ウインドウを開く");

    }

    /// <summary>
    /// 会話終了
    /// </summary>
    public void StopTalk()
    {

        // 会話イベントをしていない状態にする
        isTalking = false;

        // 会話イベントのウインドウを閉じる
        dialogController.HideDialog();

        //Debug.Log("会話ウインドウを閉じる");
    }
}
