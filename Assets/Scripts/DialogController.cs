using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;　　　　//UIを使うため
using DG.Tweening;　　　　　//DG.Tweeningを使う


public class DialogController : MonoBehaviour
{
    [SerializeField]　　　　　　　　　　　//インスペクターウインドウで編集できるようにする　
    private Text txtDialog = null;　　　//変数txtDialogにnull(無し)を代入

    [SerializeField]　　　　　　　　　　　　//インスペクターウインドウで編集できるようにする
    private Text txtTitleName = null;　　　//変数txtTitleNameにnull(無し)を代入

    [SerializeField]　　　　　　　　　　　　　　//インスペクターウインドウで編集できるようにする
    private CanvasGroup canvasGroup = null;　　//変数にcanvasGroupnull(無し)を代入

    [SerializeField]　　　　　　　　　　　　　//インスペクターウインドウで編集できるようにする
    private string titleName = "少女";　　　　//変数TitleNameに文字列　"少女"　をを代入

    [SerializeField]　　　　　　　　　　　　　//インスペクターウインドウで編集できるようにする
    private string dialog = "こんにちは";　　//変数TitleNameに文字列　"こんにちは"　をを代入

    private void Start()
    {
        SetUpDialog();　　　//メゾット呼び出し

    }

    /// <summary>
    /// ダイアログの設定
    /// </summary>
    private void SetUpDialog()
    {
        //変数canvasGroup.alphaにalpha代入
        canvasGroup.alpha = 0.0f;    //canvasGroup.alphaに0.0fを入れることにより常にウインドウを非表示にする。

        //変数 txtTitleName.textのtextに"少女"を代入
        txtTitleName.text = titleName;　　//txtTitleName.textにtitleNameの変数"少女"を代入することによりウインドウに表示させる
    }

    /// <summary>
    /// ダイアログの表示
    /// </summary>

    public void DisplayDialog()
    {
        //canvasGroupのalphaを0.5秒かけて１(最大値)にする
        canvasGroup.DOFade(1.0f, 0.5f);       //alpha(透明度)を最大値にすることにより、ウインドウを表示する


        // txtDialog.DOTextのDOTextのdialog一秒かけて表示する。一定間隔
        txtDialog.DOText(dialog, 1.0f).SetEase(Ease.Linear);　//txtDialog.DOTextの中のテキストを一定間隔で一秒かけて表示する

    }

    /// <summary>
    /// ダイアログの非表示
    /// </summary>
    public void HideDialog()
    {
        //canvasGroupのalphaを0.5秒かけて0(最小値)にする
        canvasGroup.DOFade(0.0f, 0.5f);　//alpha(透明度)を最大値にすることにより、ウインドウを非表示する。　　

        //txtDialog.textに("")を代入
        txtDialog.text = "";
    }
}
