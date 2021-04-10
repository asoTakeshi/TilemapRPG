using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;�@�@�@�@//UI���g������
using DG.Tweening;�@�@�@�@�@//DG.Tweening���g��


public class DialogController : MonoBehaviour
{
    [SerializeField]�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���@
    private Text txtDialog = null;�@�@�@//�ϐ�txtDialog��null(����)����

    [SerializeField]�@�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���
    private Text txtTitleName = null;�@�@�@//�ϐ�txtTitleName��null(����)����

    [SerializeField]�@�@�@�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���
    private CanvasGroup canvasGroup = null;�@�@//�ϐ���canvasGroupnull(����)����

    [SerializeField]�@�@�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���
    private string titleName = "����";�@�@�@�@//�ϐ�TitleName�ɕ�����@"����"�@������

    [SerializeField]�@�@�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���
    private string dialog = "����ɂ���";�@�@//�ϐ�TitleName�ɕ�����@"����ɂ���"�@������

    private void Start()
    {
        SetUpDialog();�@�@�@//���]�b�g�Ăяo��

    }

    /// <summary>
    /// �_�C�A���O�̐ݒ�
    /// </summary>
    private void SetUpDialog()
    {
        //�ϐ�canvasGroup.alpha��alpha���
        canvasGroup.alpha = 0.0f;    //canvasGroup.alpha��0.0f�����邱�Ƃɂ���ɃE�C���h�E���\���ɂ���B

        //�ϐ� txtTitleName.text��text��"����"����
        txtTitleName.text = titleName;�@�@//txtTitleName.text��titleName�̕ϐ�"����"�������邱�Ƃɂ��E�C���h�E�ɕ\��������
    }

    /// <summary>
    /// �_�C�A���O�̕\��
    /// </summary>

    public void DisplayDialog()
    {
        //canvasGroup��alpha��0.5�b�����ĂP(�ő�l)�ɂ���
        canvasGroup.DOFade(1.0f, 0.5f);       //alpha(�����x)���ő�l�ɂ��邱�Ƃɂ��A�E�C���h�E��\������


        // txtDialog.DOText��DOText��dialog��b�����ĕ\������B���Ԋu
        txtDialog.DOText(dialog, 1.0f).SetEase(Ease.Linear);�@//txtDialog.DOText�̒��̃e�L�X�g�����Ԋu�ň�b�����ĕ\������

    }

    /// <summary>
    /// �_�C�A���O�̔�\��
    /// </summary>
    public void HideDialog()
    {
        //canvasGroup��alpha��0.5�b������0(�ŏ��l)�ɂ���
        canvasGroup.DOFade(0.0f, 0.5f);�@//alpha(�����x)���ő�l�ɂ��邱�Ƃɂ��A�E�C���h�E���\������B�@�@

        //txtDialog.text��("")����
        txtDialog.text = "";
    }
}
