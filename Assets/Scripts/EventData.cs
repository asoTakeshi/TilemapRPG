using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class EventData
{
    /// <summary>
    /// イベントの種類
    /// </summary>
    public enum EventType
    {
        Talk,
        Search,
    }

    public EventType eventType;   // イベントの種類
    public int no;               // 通し番号
    public string title;        // タイトル。NPC の名前、探す対象物の名前、など

    [Multiline]
    public string dialog;      // NPC のメッセージ、対象物のメッセージ、など
    public Sprite sprite;      // イベントの画像データ   
}
