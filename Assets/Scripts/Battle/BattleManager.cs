using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private Button btnBattleEnd;
    void Start()
    {
        // ボタンのOnClickイベントに OnClickBattleEnd メソッドを追加する
        // ボタンを押下した際に実行するメソッドを登録だけなので、この時点ではメソッドは実行されない
        btnBattleEnd.onClick.AddListener(onClickBattleEnd);
    }



    private void onClickBattleEnd()
    {
        SceneStateManager.instance.NextScene(SceneStateManager.SceneType.Main);
    }
}
