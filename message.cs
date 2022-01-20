using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    /* インスタンス */
    private static Message instance;
    public static Message Instance
    {
        get
        {
            //instanceがあるか判定
            if(instance == null)
            {
                instance = (Message)FindObjectOfType(typeof(Message));

                //取得できなければエラーを返す
                if(instance == null)
                {
                    Debug.LogError(typeof(Message) + "is nothing(キャンバスのオブジェクトが見つかりません)");
                }
            }
            return instance;
        }
    }

    /* パラメータ */
    public int wn;
    private int viewNum = 0;        //表示文字数制限用
    private int nowText = 0;        //表示中のテキスト番号
    private bool isSpeak = false;   //会話中フラグ
    private bool isEvent = false;   //イベントフラグ
    private bool isOneTime = false; //ワンタイムフラグ
    private bool isComanndo = true;
    public int a;
    public int sn;
    public bool coment;
    private bool ismove = false;
    public GameObject button;
    private Canvas canvas;          //メッセージ用のキャンバス


    /* コンポーネントの取得 */
    private void Start()
    {
        canvas = GameObject.Find("MessageCanvas").GetComponent<Canvas>();
        canvas.enabled = false;
        coment = true;
    }

    public void getItemposNum(int n){
      this.a = n;
      //Debug.Log(a);
    }

    public bool GetStartFlag(){
      return ismove;
    }

    public void setBFlag(int n){
      this.sn = n;
      Debug.Log(a);
    }

    public int getBFlag(){
      return sn;
    }

    public int SendItemposNum(){
      return a;
    }

    public int getWindowNum(){
      return wn;
    }

    public void setWindowNum(int x){
      this.wn = x;
    }


    //メッセージの開始＆送り条件（デフォルトはZキー）
    private bool StartFlag()
    {
        //手動開始条件
        if (Input.GetKeyDown(KeyCode.Z))
        {
            return true;
        }
        return false;
    }

    public int getNowtext(){
      return nowText;
    }

    public void setEndFlag(bool isComanndo)
    {
        this.isComanndo = isComanndo;
        //Debug.Log(isComanndo);
    }

    public bool getEndFlag()
    {
        //Debug.Log(isComanndo);
        return isComanndo;
    }

    public void EndFours(){
      Debug.Log(isComanndo);
      if(getEndFlag()){
        //テキスト番号初期化
        Debug.Log("a");
        nowText = 0;

        //メッセージ初期化
        canvas.transform.Find("MessageText").GetComponent<Text>().text = null;

        //表示文字数初期化
        viewNum = 0;

        //会話終了
        isSpeak = false;

        //メッセージウィンドウ非表示
        canvas.enabled = false;
        button.SetActive(false);
        isComanndo = false;
      }
    }
    public void NextFours(){
      //if(getEndFlag()){
        //テキスト番号初期化
        Debug.Log("k");
        nowText = 0;
        //表示文字数初期化
        viewNum = 0;

        //isComanndo = false;
        //メッセージ初期化
        canvas.transform.Find("MessageText").GetComponent<Text>().text = null;
        button.SetActive(false);
        //表示文字数初期化

      //}
    }


    public IEnumerator WriteRoutine(string[] s)
    {
       ismove = true;
      if(!canvas.enabled){
        canvas.enabled = true;
      }

      if(nowText != 0){
        canvas.transform.Find("MessageText").GetComponent<Text>().text = null;
      }

     if(nowText == s.Length)
      {
          //テキスト番号初期化
          button.SetActive(false);
          nowText = 0;

          ismove = false;

          //メッセージ初期化
          canvas.transform.Find("MessageText").GetComponent<Text>().text = null;

          //表示文字数初期化
          viewNum = 0;

          //会話終了
          isSpeak = false;

          //メッセージウィンドウ非表示
          canvas.enabled = false;
          //button.SetActive(false);
          isComanndo = false;
          wn++;
      }
      else{
        //ismove=true;
        //書いている途中の状態にする
        //isWriting = true;
        //渡されたstringの文字の数だけループ
        for (var i = 0; i < s[nowText].Length; i++)
        {
          coment = false;
            //テキストにi番目の文字を付け足して表示する
            canvas.transform.Find("MessageText").GetComponent<Text>().text += s[nowText].Substring(i, 1);
            //次の文字を表示するまで少し待つ
            yield return new WaitForSeconds(0.1f);
        }

        //if (viewNum > s[nowText].Length){
          //表示文字数を初期化
          viewNum = 0;
          coment = true;
          if(nowText==1){
            button.SetActive(true);
          }
         nowText++;

        //書いている途中の状態を解除する
        //isWriting = false;
      }
    }






    /* フラグ管理 */
    /// <summary>
    /// return bool 会話フラグを返します
    /// メッセージの表示終了とともにfalseを返す
    /// </summary>
    /// <returns></returns>

    public void setSpeakFlag(bool isSpeak)
    {
        isSpeak = isSpeak;
    }

    public bool getSpeakFlag()
    {
        return isSpeak;
    }
    /// <summary>
    /// return bool 会話イベントフラグを返します
    /// メッセージの最後を表示した状態でfalseを返す
    /// </summary>
    /// <returns></returns>
    public bool getEventFlag()
    {
        return isEvent;
    }



    /* メッセージの表示 */
    /// <summary>
    /// 会話（string[] 会話内容,string 名前）
    /// 表示は1フレーム1文字
    /// </summary>
    public void message(string[] viewMessage, string name = null)
    {
        //会話開始&amp;進行条件
        if (StartFlag())
        {
            //会話中か判断
            if (!getSpeakFlag())
            {
                //会話フラグON
                isSpeak = true;

                //メッセージウィンドウ表示
                canvas.enabled = true;
            }
            else
            {
                //表示文字の判定
                if (viewNum < viewMessage[nowText].Length)
                {
                    if(name == null)
                    {
                        //文字をすべて表示する
                        canvas.transform.Find("MessageText").GetComponent<Text>().text = viewMessage[nowText];
                    }
                    else
                    {
                        //文字をすべて表示する
                        canvas.transform.Find("MessageText").GetComponent<Text>().text = $"{name}\n{viewMessage[nowText]}";
                    }

                    //表示数を最大にする
                    viewNum = viewMessage[nowText].Length;
                }
                else
                {
                    //表示文字数を初期化
                    viewNum = 0;

                    //次の会話へ
                    nowText++;
                  // if(getSpeakFlag()){
                    button.SetActive(getEndFlag());
                    //isComanndo = true;
                  //}
                }
            }
        }
        //isComanndo = false;
        //会話中処理
        if (getSpeakFlag())
        {

            //終了条件
            if (nowText == viewMessage.Length)
            {
                //テキスト番号初期化
                nowText = 0;

                //メッセージ初期化
                canvas.transform.Find("MessageText").GetComponent<Text>().text = null;

                //表示文字数初期化
                viewNum = 0;

                //会話終了
                isSpeak = false;

                //メッセージウィンドウ非表示
                canvas.enabled = false;
                button.SetActive(false);
                isComanndo = false;
                wn++;
            }

            else
            {
                if (viewNum < viewMessage[nowText].Length)
                {
                    //表示文字数を増加
                    viewNum++;

                    if (name == null)
                    {
                        //文字をすべて表示する
                        canvas.transform.Find("MessageText").GetComponent<Text>().text = viewMessage[nowText].Substring(0, viewNum);
                    }
                    else
                    {
                        //文字をすべて表示する
                        canvas.transform.Find("MessageText").GetComponent<Text>().text = $"{name}\n{viewMessage[nowText].Substring(0, viewNum)}";
                    }
                    //isComanndo = false;
                }
                //イベント中&amp;最後のメッセージ&amp;文字の表示がすべて終わりなら
                else if (isEvent && viewNum == viewMessage[nowText].Length && nowText == viewMessage.Length - 1)
                {
                    //isComanndo = false;
                    isEvent = false;
                }

            }
        }
    }

    /// <summary>
    /// イベント会話（string[] 会話内容,string 名前）
    /// 発生条件の中に記入 表示は1フレーム1文字
    /// </summary>
    /// <param name="viewMessage"></param>
    public void EventMessage(string[] viewMessage, string name = null)
    {
        //表示されているか判定
        if (!isSpeak || !canvas.enabled)
        {
            //イベントフラグON
            isEvent = true;

            //会話フラグON
            isSpeak = true;

            //メッセージウィンドウ表示
            canvas.enabled = true;
        }

        //メッセージの表示
        message(viewMessage, name);
    }
}
