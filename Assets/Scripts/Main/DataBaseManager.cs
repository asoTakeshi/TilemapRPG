using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;　　　　　
using System;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    [SerializeField]
    private EventDataSO eventDataSO;

    [SerializeField]
    public ItemDataSO itemDataSO;    //　<=　ItemDataSO スクリプタブル・オブジェクトをアサインして登録するための変数


    // ItemType ごとに分類した List

    [SerializeField]
    private List<ItemDataSO.ItemData> equipItemDatasList = new List<ItemDataSO.ItemData>();   //　<=　ItemType が Equip である ItemData クラスだけを管理する List 

    [SerializeField]
    private List<ItemDataSO.ItemData> saleItemDatasList = new List<ItemDataSO.ItemData>();

    [SerializeField]
    private List<ItemDataSO.ItemData> valuablesItemDatasList = new List<ItemDataSO.ItemData>();

    [SerializeField]
    private List<ItemDataSO.ItemData> useItemDatasList = new List<ItemDataSO.ItemData>();


    // ItemType ごとに分類したアイテムの名前の List

    [SerializeField]
    private List<string> equipItemNamesList = new List<string>();　　　　　　　　　　　　　　　　　//　<=　ItemType が Equip である文字列だけを管理する List 

    [SerializeField]
    private List<string> saleItemNamesList = new List<string>();

    [SerializeField]
    private List<string> valuablesItemNamesList = new List<string>();

    [SerializeField]
    private List<string> useItemNamesList = new List<string>();

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
        // アイテムの種類別の List を作成
        CreateItemTypeLists();

        // アイテムの名前をアイテムの種類ごとに分類して List を作成
        CreateItemNamesListsFromItemData();

    }


    /// <summary>
    ///  NPC 用のデータから EventData を取得
    /// </summary>
    /// <param name="npcEventNo"></param>
    /// <returns></returns>


    public EventData GetEventDataFromNPCEvent(int npcEventNo)
    {
        // EventDataSO スクリプタブル・オブジェクトの eventDatasList の中身(EventData)を１つずつ順番に取り出して、eventData 変数に代入
        foreach (EventData eventData in eventDataSO.eventDatasList)
        {
            // eventData の情報を判定し、EventType が Talk かつ、引数で取得している npcEventNo と同じ場合
            if (eventData.eventType == EventData.EventType.Talk && eventData.no == npcEventNo)
            {
                // 該当する EvenData であると判定し、その情報を戻す
                return eventData;
            }
        }

        // 上記の処理の結果、該当する EvenData の情報がスクリプタブル・オブジェクト内にない場合には、null を戻す
        return null;
    }

    /// <summary>
    /// entDataSO から指定した EventType と EventNo の EventData を照合して取得
    /// </summary>
    /// <param name="searchEventType"></param>
    /// <param name="searchEventNo"></param>
    /// <returns></returns>
    public EventData GetEventDataFromEventTypeAndEventNo(EventData.EventType searchEventType, int searchEventNo)
    {
        foreach (EventData eventData in eventDataSO.eventDatasList)
        {
            if (eventData.eventType == searchEventType && eventData.no == searchEventNo)
            {
                return eventData;
            }
        }
        return null;
    }

    /// <summary>
    ///  ItemNo から ItemData を取得
    /// </summary>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    public ItemDataSO.ItemData GetItemDataFromItemNo(int itemNo)
    {
        // ItemDataSO スクリプタブル・オブジェクト内の ItemData の情報を１つずつ順番に取り出して itemData 変数に代入
        foreach (ItemDataSO.ItemData itemData in itemDataSO.itemDataList)
        {
            // 現在取り出している ItemData の itemNo 変数の値と引数で届いている itemNo の値が同じである場合
            if (itemData.itemNo == itemNo)
            {
                // 条件に合致したので、itemData の値を戻す
                return itemData;
            }
        }
        // 上記の検索結果、スクリプタブル・オブジェクト内に該当する情報がない場合、null を戻す
        return null;
    }

    /// <summary>
    /// ItemName から ItemData を取得
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns></returns>
    public ItemDataSO.ItemData GetItemDataFromItemName(ItemName itemName)
    {
        // 上段にある GetItemDataFromItemNo メソッドと同じ内容の処理を、検索対象を itemName にして実行して取得
        return itemDataSO.itemDataList.FirstOrDefault(x => x.itemName == itemName);
    }

    /// <summary>
    /// ItemData の 最大要素数を取得
    /// </summary>
    /// <returns></returns>
    public int GetItemDataSOCount()
    {
        return itemDataSO.itemDataList.Count;
    }

    /// <summary>
    /// アイテムの種類別の List を作成
    /// </summary>

    private void CreateItemTypeLists()
    {
        // ItemDataSO スクリプタブル・オブジェクト内の ItemData の情報を１つずつ順番に取り出して itemData 変数に代入
        foreach (ItemDataSO.ItemData itemData in itemDataSO.itemDataList)
        {

            // 現在取り出している itemData 変数の ItemType の値がどの case と合致するかを判定
            switch (itemData.itemType)
            {

                // itemData.itemType == ItemType.Equip の場合には、equipItemDatasList 変数に itemData 変数の値を追加する
                case ItemType.Equip:
                    equipItemDatasList.Add(itemData);
                    break;

                case ItemType.Sele:
                    saleItemDatasList.Add(itemData);
                    break;

                case ItemType.Valuables:
                    valuablesItemDatasList.Add(itemData);
                    break;

                case ItemType.Use:
                    useItemDatasList.Add(itemData);
                    break;
            }
        }
    }
    private void CreateItemNamesListsFromItemData()
    {

        // ItemName 型の enum に登録されている列挙子をすべて取り出して文字列の配列にして取得し、values 変数に代入
        string[] values = Enum.GetNames(typeof(ItemName));

        // ItemDataSO スクリプタブル・オブジェクト内の ItemData の情報を１つずつ順番に取り出して itemData 変数に代入
        foreach (ItemDataSO.ItemData itemData in itemDataSO.itemDataList)
        {

            // values 配列変数の中を先頭から順番に検索し、現在取り出している itemData 変数の itemName と合致した値があれば 
            if (!string.IsNullOrEmpty(values.FirstOrDefault(x => x == itemData.itemName.ToString())))
            {

                // 最初に合致した値を文字列として代入
                string itemName = itemData.itemName.ToString();

                // 現在取り出している itemData 変数の ItemType の値がどの case と合致するかを判定(ここは上のメソッドの switch 文と同じ分岐にしても実装できます。学習のためにキャスト処理を入れています)
                switch ((int)itemData.itemType)
                {

                    // itemData.itemType == 0(ItemType 型の列挙子の最初のもの)
                    case 0:
                        equipItemNamesList.Add(itemName);
                        break;
                    case 1:
                        saleItemNamesList.Add(itemName);
                        break;
                    case 2:
                        valuablesItemNamesList.Add(itemName);
                        break;
                    case 3:
                        useItemNamesList.Add(itemName);
                        break;
                }
            }
        }
    }
}
