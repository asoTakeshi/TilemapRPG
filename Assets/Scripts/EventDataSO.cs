using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EventDataSO", menuName = "Create EventDataSO")]
public class EventDataSO : ScriptableObject
{
    public List<EventData> eventDatasList = new List<EventData>();   // ������ EventData ���P�̕ϐ����ł܂Ƃ߂ĊǗ����s��
}
