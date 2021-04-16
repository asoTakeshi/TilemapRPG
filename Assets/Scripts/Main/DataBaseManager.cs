using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    [SerializeField]
    private EventDataSO eventDataSO;

    private void Awake()
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
    ///  NPC �p�̃f�[�^���� EventData ���擾
    /// </summary>
    /// <param name="npcEventNo"></param>
    /// <returns></returns>


    public EventData GetEventDataFromNPCEvent(int npcEventNo)
    {
        // EventDataSO �X�N���v�^�u���E�I�u�W�F�N�g�� eventDatasList �̒��g(EventData)���P�����ԂɎ��o���āAeventData �ϐ��ɑ��
        foreach (EventData eventData in eventDataSO.eventDatasList)
        {
            // eventData �̏��𔻒肵�AEventType �� Talk ���A�����Ŏ擾���Ă��� npcEventNo �Ɠ����ꍇ
            if (eventData.eventType == EventData.EventType.Talk && eventData.no == npcEventNo)
            {
                // �Y������ EvenData �ł���Ɣ��肵�A���̏���߂�
                return eventData;
            }
        }

        // ��L�̏����̌��ʁA�Y������ EvenData �̏�񂪃X�N���v�^�u���E�I�u�W�F�N�g���ɂȂ��ꍇ�ɂ́Anull ��߂�
        return null;
    }
}
