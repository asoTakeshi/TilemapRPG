using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;�@�@�@�@�@
using System;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;

    [SerializeField]
    private EventDataSO eventDataSO;

    [SerializeField]
    public ItemDataSO itemDataSO;    //�@<=�@ItemDataSO �X�N���v�^�u���E�I�u�W�F�N�g���A�T�C�����ēo�^���邽�߂̕ϐ�


    // ItemType ���Ƃɕ��ނ��� List

    [SerializeField]
    private List<ItemDataSO.ItemData> equipItemDatasList = new List<ItemDataSO.ItemData>();   //�@<=�@ItemType �� Equip �ł��� ItemData �N���X�������Ǘ����� List 

    [SerializeField]
    private List<ItemDataSO.ItemData> saleItemDatasList = new List<ItemDataSO.ItemData>();

    [SerializeField]
    private List<ItemDataSO.ItemData> valuablesItemDatasList = new List<ItemDataSO.ItemData>();

    [SerializeField]
    private List<ItemDataSO.ItemData> useItemDatasList = new List<ItemDataSO.ItemData>();


    // ItemType ���Ƃɕ��ނ����A�C�e���̖��O�� List

    [SerializeField]
    private List<string> equipItemNamesList = new List<string>();�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�@<=�@ItemType �� Equip �ł��镶���񂾂����Ǘ����� List 

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
        // �A�C�e���̎�ޕʂ� List ���쐬
        CreateItemTypeLists();

        // �A�C�e���̖��O���A�C�e���̎�ނ��Ƃɕ��ނ��� List ���쐬
        CreateItemNamesListsFromItemData();

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

    /// <summary>
    /// entDataSO ����w�肵�� EventType �� EventNo �� EventData ���ƍ����Ď擾
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
    ///  ItemNo ���� ItemData ���擾
    /// </summary>
    /// <param name="itemNo"></param>
    /// <returns></returns>
    public ItemDataSO.ItemData GetItemDataFromItemNo(int itemNo)
    {
        // ItemDataSO �X�N���v�^�u���E�I�u�W�F�N�g���� ItemData �̏����P�����ԂɎ��o���� itemData �ϐ��ɑ��
        foreach (ItemDataSO.ItemData itemData in itemDataSO.itemDataList)
        {
            // ���ݎ��o���Ă��� ItemData �� itemNo �ϐ��̒l�ƈ����œ͂��Ă��� itemNo �̒l�������ł���ꍇ
            if (itemData.itemNo == itemNo)
            {
                // �����ɍ��v�����̂ŁAitemData �̒l��߂�
                return itemData;
            }
        }
        // ��L�̌������ʁA�X�N���v�^�u���E�I�u�W�F�N�g���ɊY�������񂪂Ȃ��ꍇ�Anull ��߂�
        return null;
    }

    /// <summary>
    /// ItemName ���� ItemData ���擾
    /// </summary>
    /// <param name="itemName"></param>
    /// <returns></returns>
    public ItemDataSO.ItemData GetItemDataFromItemName(ItemName itemName)
    {
        // ��i�ɂ��� GetItemDataFromItemNo ���\�b�h�Ɠ������e�̏������A�����Ώۂ� itemName �ɂ��Ď��s���Ď擾
        return itemDataSO.itemDataList.FirstOrDefault(x => x.itemName == itemName);
    }

    /// <summary>
    /// ItemData �� �ő�v�f�����擾
    /// </summary>
    /// <returns></returns>
    public int GetItemDataSOCount()
    {
        return itemDataSO.itemDataList.Count;
    }

    /// <summary>
    /// �A�C�e���̎�ޕʂ� List ���쐬
    /// </summary>

    private void CreateItemTypeLists()
    {
        // ItemDataSO �X�N���v�^�u���E�I�u�W�F�N�g���� ItemData �̏����P�����ԂɎ��o���� itemData �ϐ��ɑ��
        foreach (ItemDataSO.ItemData itemData in itemDataSO.itemDataList)
        {

            // ���ݎ��o���Ă��� itemData �ϐ��� ItemType �̒l���ǂ� case �ƍ��v���邩�𔻒�
            switch (itemData.itemType)
            {

                // itemData.itemType == ItemType.Equip �̏ꍇ�ɂ́AequipItemDatasList �ϐ��� itemData �ϐ��̒l��ǉ�����
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

        // ItemName �^�� enum �ɓo�^����Ă���񋓎q�����ׂĎ��o���ĕ�����̔z��ɂ��Ď擾���Avalues �ϐ��ɑ��
        string[] values = Enum.GetNames(typeof(ItemName));

        // ItemDataSO �X�N���v�^�u���E�I�u�W�F�N�g���� ItemData �̏����P�����ԂɎ��o���� itemData �ϐ��ɑ��
        foreach (ItemDataSO.ItemData itemData in itemDataSO.itemDataList)
        {

            // values �z��ϐ��̒���擪���珇�ԂɌ������A���ݎ��o���Ă��� itemData �ϐ��� itemName �ƍ��v�����l������� 
            if (!string.IsNullOrEmpty(values.FirstOrDefault(x => x == itemData.itemName.ToString())))
            {

                // �ŏ��ɍ��v�����l�𕶎���Ƃ��đ��
                string itemName = itemData.itemName.ToString();

                // ���ݎ��o���Ă��� itemData �ϐ��� ItemType �̒l���ǂ� case �ƍ��v���邩�𔻒�(�����͏�̃��\�b�h�� switch ���Ɠ�������ɂ��Ă������ł��܂��B�w�K�̂��߂ɃL���X�g���������Ă��܂�)
                switch ((int)itemData.itemType)
                {

                    // itemData.itemType == 0(ItemType �^�̗񋓎q�̍ŏ��̂���)
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
