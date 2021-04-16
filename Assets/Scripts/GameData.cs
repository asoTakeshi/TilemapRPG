using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameData : MonoBehaviour
{
    public static GameData instance;  // �V���O���g���f�U�C���p�^�[���̃N���X�ɂ��邽�߂̕ϐ�
    public int randomEncountRate;     // �G���J�E���g�̔�����
    public bool isEncouting;         // �G���J�E���g���Ă����Ԃ��ǂ����̔���p�Btrue �̏ꍇ�G���J�E���g���Ă�����
    public bool isDebug;              // �f�o�b�O�p�̕ϐ��Btrue �Ȃ�΁A�G���J�E���g���Ă����Ԃ����Z�b�g�ł���


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
}
