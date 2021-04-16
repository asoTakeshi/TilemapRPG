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
        // �{�^����OnClick�C�x���g�� OnClickBattleEnd ���\�b�h��ǉ�����
        // �{�^�������������ۂɎ��s���郁�\�b�h��o�^�����Ȃ̂ŁA���̎��_�ł̓��\�b�h�͎��s����Ȃ�
        btnBattleEnd.onClick.AddListener(onClickBattleEnd);
    }



    private void onClickBattleEnd()
    {
        SceneStateManager.instance.NextScene(SceneStateManager.SceneType.Main);
    }
}
