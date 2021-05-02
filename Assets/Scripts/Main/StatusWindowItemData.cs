using UnityEngine;
using System.Collections;

public class StatusWindowItemData : object
{

	//�@�A�C�e����Image�摜
	private Sprite itemSprite;
	//�@�A�C�e���̖��O
	private string itemName;
	//�@�A�C�e���̃^�C�v
	private StatusWindowItemDataBase.Item itemType;
	//�@�A�C�e���̏��
	private string itemInformation;

	public StatusWindowItemData(Sprite image, string itemName, StatusWindowItemDataBase.Item itemType, string information)
	{
		this.itemSprite = image;
		this.itemName = itemName;
		this.itemType = itemType;
		this.itemInformation = information;
	}

	public Sprite GetItemSprite()
	{
		return itemSprite;
	}

	public string GetItemName()
	{
		return itemName;
	}

	public StatusWindowItemDataBase.Item GetItemType()
	{
		return itemType;
	}

	public string GetItemInformation()
	{
		return itemInformation;
	}

}
