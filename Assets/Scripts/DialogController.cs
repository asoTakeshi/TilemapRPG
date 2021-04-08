using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DialogController : MonoBehaviour
{
    [SerializeField]
    private Text txtDialog = null;

    [SerializeField]
    private Text txtTitleName = null;

    [SerializeField]
    private CanvasGroup canvasGroup = null;

    [SerializeField]
    private string titleName = "����";

    [SerializeField]
    private string dialog = "����ɂ���";

    private void Start()
    {
        SetUpDialog();

    }

    /// <summary>
    /// �_�C�A���O�̐ݒ�
    /// </summary>
    private void SetUpDialog()
    {
        canvasGroup.alpha = 0.0f;

        txtTitleName.text = titleName;
    }

    /// <summary>
    /// �_�C�A���O�̕\��
    /// </summary>

    public void DisplayDialog()
    {
        canvasGroup.DOFade(1.0f, 0.5f);

        txtDialog.DOText(dialog, 1.0f).SetEase(Ease.Linear);

    }

    /// <summary>
    /// �_�C�A���O�̔�\��
    /// </summary>
    public void HideDialog()
    {
        canvasGroup.DOFade(0.0f, 0.5f);

        txtDialog.text = "";    }
}
