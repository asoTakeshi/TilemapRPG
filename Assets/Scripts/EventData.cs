using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class EventData
{
    /// <summary>
    /// �C�x���g�̎��
    /// </summary>
    public enum EventType
    {
        Talk,
        Search,
    }

    public EventType eventType;   // �C�x���g�̎��
    public int no;               // �ʂ��ԍ�
    public string title;        // �^�C�g���BNPC �̖��O�A�T���Ώە��̖��O�A�Ȃ�

    [Multiline]
    public string dialog;      // NPC �̃��b�Z�[�W�A�Ώە��̃��b�Z�[�W�A�Ȃ�
    public Sprite sprite;      // �C�x���g�̉摜�f�[�^   
}
