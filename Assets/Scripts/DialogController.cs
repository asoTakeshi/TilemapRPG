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

    //[SerializeField]�@�@�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���
    //private string titleName = "����";�@�@�@�@//�ϐ�TitleName�ɕ�����@"����"�@������

    //[SerializeField]�@�@�@�@�@�@�@�@�@�@�@�@�@//�C���X�y�N�^�[�E�C���h�E�ŕҏW�ł���悤�ɂ���
    //private string dialog = "����ɂ���";�@�@//�ϐ�TitleName�ɕ�����@"����ɂ���"�@������

    [SerializeField]                           //������ꂽ���m�F�ł���悤�ɃC���X�y�N�^�[�ɕ\������B�m�F���I��������ASerializeField���� �͍폜���Ă��悢�ł�
    private EventData eventData;               // NonPlayerCharacter �X�N���v�g���� EventData �̏�񂪃��\�b�h�̈�����ʂ��ē͂��܂��̂ŁA����������邽�߂̕ϐ�

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
        //txtTitleName.text = titleName;�@�@//txtTitleName.text��titleName�̕ϐ�"����"�������邱�Ƃɂ��E�C���h�E�ɕ\��������

        // EventData ��������
        eventData = null;
    }

    /// <summary>
    /// �_�C�A���O�̕\��
    /// </summary>

    public void DisplayDialog(EventData eventData)
    {
        if (this.eventData == null)
        {
            this.eventData = eventData;

        }
        //canvasGroup��alpha��0.5�b�����ĂP(�ő�l)�ɂ���
        canvasGroup.DOFade(1.0f, 0.5f);       //alpha(�����x)���ő�l�ɂ��邱�Ƃɂ��A�E�C���h�E��\������

        txtTitleName.text = this.eventData.title;   //�B Title �Ƃ��ĕ\������^�C�g��(NPC �̖��O)�̓��e�� EventData �̓��e�ɕύX���܂�

        // txtDialog.DOText��DOText��dialog��b�����ĕ\������B���Ԋu
        txtDialog.DOText(this.eventData.dialog, 1.0f).SetEase(Ease.Linear);�@//dialog �̓��e��1�������A1�b�����ē����ŉ�ʂɕ\������B

        // TODO �摜�f�[�^������ꍇ�ɂ́AImage �^�̕ϐ���p�ӂ��� eventData.eventSprite ��������
    }

    /// <summary>
    /// �_�C�A���O�̔�\��
    /// </summary>
    public void HideDialog()
    {
        //canvasGroup��alpha��0.5�b������0(�ŏ��l)�ɂ���
        canvasGroup.DOFade(0.0f, 0.5f);�@//alpha(�����x)���ő�l�ɂ��邱�Ƃɂ��A�E�C���h�E���\������B�@�@

        //txtDialog.text��("")����
        txtDialog.text = "";       //txtDialog.text ���̕�������폜
    }
}
