using UnityEngine;
using System.Collections;

public class StatusWindowItemDataBase : MonoBehaviour
{

	public enum Item
	{
		Sword,
		HandGun,
		ShotGun,
		UseItem
	};

	private StatusWindowItemData[] itemLists = new StatusWindowItemData[4];

	void Awake()
	{
		//�@�A�C�e���̑S�����쐬
		itemLists[0] = new StatusWindowItemData(Resources.Load("FlashLight", typeof(Sprite)) as Sprite, "�����d��", Item.Sword, "����Ε֗��ȕӂ���Ƃ炷���C�g");
		itemLists[1] = new StatusWindowItemData(Resources.Load("Sword", typeof(Sprite)) as Sprite, "�i�C�t", Item.Sword, "�؂ꖡ����ǂ��i�C�t");
		itemLists[2] = new StatusWindowItemData(Resources.Load("Sword", typeof(Sprite)) as Sprite, "�u���[�h�\�[�h", Item.Sword, "�匕");
		itemLists[3] = new StatusWindowItemData(Resources.Load("Gun", typeof(Sprite)) as Sprite, "�n���h�K��", Item.HandGun, "�З͔��Q�n���h�K��");
	}

	public StatusWindowItemData[] GetItemData()
	{
		return itemLists;
	}

	public int GetItemTotal()
	{
		return itemLists.Length;
	}

}
