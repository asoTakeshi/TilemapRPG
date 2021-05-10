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
    /// ItemButtonDetail �̐ݒ�(�O���̃X�N���v�g����Ăяo�����O��̃��\�b�h)
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
    /// �{�^���̃A�N�e�B�u��Ԃ̐؂�ւ�
    /// </summary>
    /// <param name="isSwitch"></param>
    public void SwitchActivateItemButtonDetail(bool isSwitch)
    {
        imgItem.enabled = isSwitch;

        btnItem.interactable = isSwitch;
    }

    /// <summary>
    /// �A�C�e���{�^���������ꂽ���̏���
    /// </summary>
    public void OnSelected()
    {
        txtItemInfo.text = this.itemData.itemInfo;
    }

    /// <summary>
    /// �A�C�e���{�^������ړ������Ƃ��̏���
    /// </summary>
    public void OnDeselected()
    {
        txtItemInfo.text = "";
    }
}
