using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Create ItemDataSO")]
public class ItemDataSO : ScriptableObject
{


    [Serializable]
    public class ItemData
    {
        public int itemNo;             // �A�C�e���̒ʂ��ԍ�
        public Sprite itemSprite;      // �A�C�e���� Image �摜
        public ItemName itemName;      // �A�C�e���̖��O
        public ItemType itemType;      // �A�C�e���̎��
        public string itemInfo;        // �A�C�e���̏��

        // TODO �K�v�ȏ���ǉ�����
    }

    public List<ItemData> itemDataList = new List<ItemData>();  // ������ItemData���P�̕ϐ����ł܂Ƃ߂ĊǗ����s��

}
