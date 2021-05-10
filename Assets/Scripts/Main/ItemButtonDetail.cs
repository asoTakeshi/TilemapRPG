using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonDetail : MonoBehaviour
{
    [SerializeField]
    private Text txtItemName;
    [SerializeField]
    private Text txtItemInfo;
    [SerializeField]
    private Text txtItemCount;
    [SerializeField]
    private Image imgItem;
    [SerializeField]
    private Button btnItem;
    [SerializeField]
    private ItemDataSO.ItemData itemData;

    /// <summary>
    /// ItemButtonDetail の設定(外部のスクリプトから呼び出される前提のメソッド)
    /// </summary>
    /// <param name="itemData"></param>
    /// <param name="count"></param>
    public void SetUpItemButtonDetail(ItemDataSO.ItemData itemData, int count)
    {
        this.itemData = itemData;

        txtItemName.text = this.itemData.itemName.ToString();

        txtItemInfo.text = count.ToString();

        imgItem.sprite = this.itemData.itemSprite;
    }


    /// <summary>
    /// ボタンのアクティブ状態の切り替え
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwitchActivateItemButtonDetail(bool isSwitch)
    {
        imgItem.enabled = isSwitch;

        btnItem.interactable = isSwitch;
    }

    /// <summary>
    /// アイテムボタンが押された時の処理
    /// </summary>
    public void OnSelected()
    {
        txtItemInfo.text = this.itemData.itemInfo;
    }

    /// <summary>
    /// アイテムボタンから移動したときの処理
    /// </summary>
    public void OnDeselected()
    {
        txtItemInfo.text = "";
    }
}
