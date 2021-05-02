using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

	private Text informationText;
	private StatusWindowItemDataBase itemDataBase;
	private int itemNum;

	void Start()
	{
		itemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
		informationText = transform.parent.parent.parent.Find("Information/Text").GetComponent<Text>();
	}
	//�@�A�C�e���{�^�����I�����ꂽ�����\��
	public void OnSelected()
	{
		informationText.text = itemDataBase.GetItemData()[itemNum].GetItemInformation();
	}
	//�@�A�C�e���{�^������ړ�����������폜
	public void OnDeselected()
	{
		informationText.text = "";
	}

	public void SetItemNum(int number)
	{
		itemNum = number;
	}

	public int GetItemNum()
	{
		return itemNum;
	}
}
