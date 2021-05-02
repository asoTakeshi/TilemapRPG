using UnityEngine;
using System.Collections;

public class StatusWindowStatus : MonoBehaviour
{

	//�@�A�C�e���������Ă��邩�ǂ����̃t���O
	[SerializeField]
	private bool[] itemFlags = new bool[6];

	private StatusWindowItemDataBase statusWindowItemDataBase;

	void Start()
	{
		statusWindowItemDataBase = GetComponent<StatusWindowItemDataBase>();
		SetItemData("�����d��");
		SetItemData("�n���h�K��");
	}

	//�@�A�C�e���������Ă��邩�ǂ���
	public bool GetItemFlag(int num)
	{
		return itemFlags[num];
	}

	//�@�A�C�e�����Z�b�g
	public void SetItemData(string name)
	{
		var itemDatas = statusWindowItemDataBase.GetItemData();
		for (int i = 0; i < itemDatas.Length; i++)
		{
			if (itemDatas[i].GetItemName() == name)
			{
				itemFlags[i] = true;
			}
		}
	}
}
