using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameData : MonoBehaviour
{
    public static GameData instance;        // �V���O���g���f�U�C���p�^�[���̃N���X�ɂ��邽�߂̕ϐ�
    public int randomEncountRate;           // �G���J�E���g�̔�����
    public bool isEncouting;                // �G���J�E���g���Ă����Ԃ��ǂ����̔���p�Btrue �̏ꍇ�G���J�E���g���Ă�����
    public bool isDebug;                    // �f�o�b�O�p�̕ϐ��Btrue �Ȃ�΁A�G���J�E���g���Ă����Ԃ����Z�b�g�ł���
    private Vector3 currentPlayerPos;       // �G���J�E���g���̃v���C���[�L�����̈ʒu�̏���ێ����邽�߂̕ϐ�
    private Vector2 currentLookDirection;    // �G���J�E���g���̃v���C���[�L�����̕����̏���ێ����邽�߂̕ϐ�


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �G���J�E���g���̃v���C���[�L�����̈ʒu�ƕ����̏���ێ�
    /// </summary>
    /// <param name="encountPlayerPos"></param>
    /// <param name="encountLookDirection"></param>

    public void SetEncountPlayerPosAndDirection(Vector3 encountPlayerPos, Vector2 encountLookDirection)
    {
        // �G���J�E���g���̃v���C���[�L�����̈ʒu�ƕ����̏�񂪈����œ͂��̂ŁA������ϐ��ɕێ�
        currentPlayerPos = encountPlayerPos;
        currentLookDirection = encountLookDirection;

        Debug.Log("�v���C���[�̃G���J�E���g�ʒu���X�V");
    }

    /// <summary>
    /// �G���J�E���g���̃v���C���[�L�����̈ʒu����߂�
    /// </summary>
    /// <returns></returns>

    public Vector3 GetCurrentPlayerPos()
    {
        // �ێ����Ă������߂�
        return currentPlayerPos;
    }


    /// <summary>
    /// �G���J�E���g���̃v���C���[�L�����̕�����߂�
    /// </summary>
    /// <returns></returns>
    public Vector2 GetCurrentLookDirection()
    {
        // �ێ����Ă������߂�
        return currentLookDirection;
    }
}
