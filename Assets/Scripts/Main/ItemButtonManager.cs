using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemButtonManager : MonoBehaviour
{
    public ItemButtonDetail itemButtonDetailPrefab;
    public List<ItemButtonDetail> itemButtonDetailList = new List<ItemButtonDetail>();
    public Transform itemAreaTran;
    public Button btnItemSelectWindow;
    public Button btnExitItemWindow;
    

    void Start()
    {
        btnItemSelectWindow.onClick.AddListener(CreateItemButtonDetails);

        btnExitItemWindow.onClick.AddListener(DestoyItemButtonDetails);
    }

    /// <summary>
    /// アイテムインベントリーを作成
    /// </summary>
    public void CreateItemButtonDetails()
    {
        Debug.Log("作成");
        DestoyItemButtonDetails();

        // 所持しているアイテムの分だけインスタンスする
        for (int i = 0; i < GameData.instance.GetItemInventryListCount(); i++)
        {
            ItemButtonDetail itemButtonDetail = Instantiate(itemButtonDetailPrefab, itemAreaTran, false);
            GameData.ItemInventryData itemInventryData = GameData.instance.GetItemInventryData(i);
            itemButtonDetail.SetUpItemButtonDetail(DataBaseManager.instance.GetItemDataFromItemName(itemInventryData.itemName), itemInventryData.count);
            itemButtonDetailList.Add(itemButtonDetail);
        }
    }

    /// <summary>
    /// アイテムリストを削除
    /// </summary>
    public void DestoyItemButtonDetails()
    {
        if (itemButtonDetailList.Count > 0)
        {

            for (int i = 0; i < itemButtonDetailList.Count; i++)
            {
                Destroy(itemButtonDetailList[i].gameObject);
            }
        }
        itemButtonDetailList.Clear();
    }
}
