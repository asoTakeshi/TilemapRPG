using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateItemButton : MonoBehaviour
{

	//�@��l���L�����N�^�[�̃X�e�[�^�X
	private StatusWindowStatus statusWindowStatus;
	//�@�A�C�e���f�[�^�x�[�X
	private StatusWindowItemDataBase statusWindowItemDataBase;
	//�@�A�C�e���{�^���̃v���n�u
	public GameObject itemPrefab;
	//�@�A�C�e���{�^�������Ă����Q�[���I�u�W�F�N�g
	private GameObject[] item;

	//�@�Q�[���I�u�W�F�N�g���A�N�e�B�u�ɂȂ��������s
	void OnEnable()
	{
		statusWindowStatus = Camera.main.GetComponent<StatusWindowStatus>();
		statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
		item = new GameObject[statusWindowItemDataBase.GetItemTotal()];

		//�@�A�C�e���������A�C�e���{�^�����쐬
		for (var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
		{
			item[i] = GameObject.Instantiate(itemPrefab) as GameObject;
			item[i].name = "Item" + i;
			//�@�A�C�e���{�^���̐e�v�f�����̃X�N���v�g���ݒ肳��Ă���Q�[���I�u�W�F�N�g�ɂ���
			item[i].transform.SetParent(transform);
			//�@�A�C�e���������Ă��邩�ǂ���
			if (statusWindowStatus.GetItemFlag(i))
			{
				//�@�A�C�e���f�[�^�x�[�X�̏�񂩂�X�v���C�g���擾���A�C�e���{�^���̃X�v���C�g�ɐݒ�
				item[i].transform.GetChild(0).GetComponent<Image>().sprite = statusWindowItemDataBase.GetItemData()[i].GetItemSprite();
			}
			else
			{
				//�@�A�C�e���{�^����UI.Image��s���ɂ��A�}�E�X��L�[����ňړ����Ȃ��悤�ɂ���
				item[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
				item[i].transform.GetChild(0).GetComponent<Button>().interactable = false;
			}
			//�@�{�^���Ƀ��j�[�N�Ȕԍ���ݒ�i�A�C�e���f�[�^�x�[�X�ԍ��ƑΉ��j
			item[i].transform.GetChild(0).GetComponent<ItemButton>().SetItemNum(i);
		}
	}

	void OnDisable()
	{
		//�@�Q�[���I�u�W�F�N�g����A�N�e�B�u�ɂȂ鎞�ɍ쐬�����A�C�e���{�^���C���X�^���X���폜����
		for (var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
		{
			Destroy(item[i]);
		}
	}
}
