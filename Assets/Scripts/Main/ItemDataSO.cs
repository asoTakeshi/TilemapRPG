using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OneLine;　　　　//　<=　①　宣言を追加してください

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Create ItemDataSO")]
public class ItemDataSO : ScriptableObject
{


    [Serializable]
    public class ItemData
    {
        public int itemNo;             // アイテムの通し番号
        public Sprite itemSprite;      // アイテムの Image 画像
        public ItemName itemName;      // アイテムの名前
        public ItemType itemType;      // アイテムの種類
        public string itemInfo;        // アイテムの情報

        // TODO 必要な情報を追加する
    }
    [OneLine] // <=　②　OneLine 属性か、OneLineWithHeader 属性のいずれかを追加してください
    public List<ItemData> itemDataList = new List<ItemData>();  // 複数のItemDataを１つの変数内でまとめて管理を行う

}
