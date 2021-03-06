using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncountManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;


    void Start()
    {
        // PlayerController クラスに EncountManager クラスの情報を渡す
        playerController.SetUpPlayerController(this);
    }

    /// <summary>
    /// ランダムエンカウントの発生
    /// </summary>
    public void JudgeRandomEncout()
    {
        if (GameData.instance.isEncouting)
        {
            return;
        }

        int encountRate = Random.Range(0, GameData.instance.randomEncountRate);

        if (encountRate == 5)
        {
            //Debug.Log("エンカウント : " + encountRate);

            GameData.instance.isEncouting = true;

            //  プレイヤーキャラの位置と方向の情報を保存
            GameData.instance.SetEncountPlayerPosAndDirection(playerController.transform.position, playerController.GetLookDirection());
            // Battle シーンへ遷移
            SceneStateManager.instance.NextScene(SceneStateManager.SceneType.Battle);
        }
    }

    void Update()
    {
        // デバッグ用(GameData クラスの isDebug が true (インスペクター上ではチェックがオンの状態)の場合に Left Shift キーを押すことで動作する)
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameData.instance.isDebug)
        {
            Debug.Log("エンカウント終了");

            GameData.instance.isEncouting = false;
        }
    }
}
