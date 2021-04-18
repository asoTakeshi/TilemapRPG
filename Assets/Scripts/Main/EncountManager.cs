using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncountManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;


    void Start()
    {
        // PlayerController �N���X�� EncountManager �N���X�̏���n��
        playerController.SetUpPlayerController(this);
    }

    /// <summary>
    /// �����_���G���J�E���g�̔���
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
            //Debug.Log("�G���J�E���g : " + encountRate);

            GameData.instance.isEncouting = true;

            //  �v���C���[�L�����̈ʒu�ƕ����̏���ۑ�
            GameData.instance.SetEncountPlayerPosAndDirection(playerController.transform.position, playerController.GetLookDirection());
            // Battle �V�[���֑J��
            SceneStateManager.instance.NextScene(SceneStateManager.SceneType.Battle);
        }
    }

    void Update()
    {
        // �f�o�b�O�p(GameData �N���X�� isDebug �� true (�C���X�y�N�^�[��ł̓`�F�b�N���I���̏��)�̏ꍇ�� Left Shift �L�[���������Ƃœ��삷��)
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameData.instance.isDebug)
        {
            Debug.Log("�G���J�E���g�I��");

            GameData.instance.isEncouting = false;
        }
    }
}
