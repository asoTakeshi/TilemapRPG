using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OperationStatusWindow : MonoBehaviour
{
	[SerializeField]
	private GameObject propertyWindow;
	//�@�X�e�[�^�X�E�C���h�E�̑S���̉��
	[SerializeField]
	private GameObject[] windowLists;

	void Update()
	{
		//�@�X�e�[�^�X�E�C���h�E�̃I���E�I�t
		if (Input.GetButtonDown("Start"))
		{
			propertyWindow.SetActive(!propertyWindow.activeSelf);
			//�@MainWindow���Z�b�g
			ChangeWindow(windowLists[0]);
		}
	}

	//�@�X�e�[�^�X��ʂ̃E�C���h�E�̃I���E�I�t���\�b�h
	public void ChangeWindow(GameObject window)
	{
		foreach (var item in windowLists)
		{
			if (item == window)
			{
				item.SetActive(true);
				EventSystem.current.SetSelectedGameObject(null);
			}
			else
			{
				item.SetActive(false);
			}
			//�@���ꂼ��̃E�C���h�E��MenuArea�̍ŏ��̎q�v�f���A�N�e�B�u�ȏ�Ԃɂ���
			EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").GetChild(0).gameObject);
		}
	}
}
