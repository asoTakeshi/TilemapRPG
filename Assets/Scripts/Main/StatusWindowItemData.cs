using UnityEngine;
using System.Collections;

public class StatusWindowItemData : object
{

	//　アイテムのImage画像
	private Sprite itemSprite;
	//　アイテムの名前
	private string itemName;
	//　アイテムのタイプ
	private StatusWindowItemDataBase.Item itemType;
	//　アイテムの情報
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
