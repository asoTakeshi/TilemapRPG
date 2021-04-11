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

    //[SerializeField]　　　　　　　　　　　　　//インスペクターウインドウで編集できるようにする
    //private string titleName = "少女";　　　　//変数TitleNameに文字列　"少女"　をを代入

    //[SerializeField]　　　　　　　　　　　　　//インスペクターウインドウで編集できるようにする
    //private string dialog = "こんにちは";　　//変数TitleNameに文字列　"こんにちは"　をを代入

    [SerializeField]                           //代入されたか確認できるようにインスペクターに表示する。確認が終了したら、SerializeField属性 は削除してもよいです
    private EventData eventData;               // NonPlayerCharacter スクリプトから EventData の情報がメソッドの引数を通じて届きますので、それを代入するための変数

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
        //txtTitleName.text = titleName;　　//txtTitleName.textにtitleNameの変数"少女"を代入することによりウインドウに表示させる

        // EventData を初期化
        eventData = null;
    }

    /// <summary>
    /// ダイアログの表示
    /// </summary>

    public void DisplayDialog(EventData eventData)
    {
        if (this.eventData == null)
        {
            this.eventData = eventData;

        }
        //canvasGroupのalphaを0.5秒かけて１(最大値)にする
        canvasGroup.DOFade(1.0f, 0.5f);       //alpha(透明度)を最大値にすることにより、ウインドウを表示する

        txtTitleName.text = this.eventData.title;   //③ Title として表示するタイトル(NPC の名前)の内容を EventData の内容に変更します

        // txtDialog.DOTextのDOTextのdialog一秒かけて表示する。一定間隔
        txtDialog.DOText(this.eventData.dialog, 1.0f).SetEase(Ease.Linear);　//dialog の内容を1文字ずつ、1秒かけて等速で画面に表示する。

        // TODO 画像データがある場合には、Image 型の変数を用意して eventData.eventSprite を代入する
    }

    /// <summary>
    /// ダイアログの非表示
    /// </summary>
    public void HideDialog()
    {
        //canvasGroupのalphaを0.5秒かけて0(最小値)にする
        canvasGroup.DOFade(0.0f, 0.5f);　//alpha(透明度)を最大値にすることにより、ウインドウを非表示する。　　

        //txtDialog.textに("")を代入
        txtDialog.text = "";       //txtDialog.text 内の文字列を削除
    }
}
