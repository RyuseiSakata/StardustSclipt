using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Message2 : MonoBehaviour
{
    // Start is called before the first frame update
    private static Message2 instance;

     public static Message2 Instance
     {
         get
         {
             //instanceがあるか判定
             if(instance == null)
             {
                 instance = (Message2)FindObjectOfType(typeof(Message2));

                 //取得できなければエラーを返す
                 if(instance == null)
                 {
                     Debug.LogError(typeof(Message2) + "is nothing(キャンバスのオブジェクトが見つかりません)");
                 }
             }
             return instance;
         }
     }

     public int a;
     public int wn;
     public bool coment;
     [Header("メッセージウィンドウ")]
     private Canvas canvas;          //メッセージ用のキャンバス
     private int viewNum = 0;        //表示文字数制限用
     private int nowText;            //表示中のテキスト番号
     private bool isSpeak = false;   //会話中フラグ
     private bool isComanndo = true;
     private bool ismove = false;

     //private Canvas canvas;

     private void Start()
     {
         canvas = GameObject.Find("MessageCanvas").GetComponent<Canvas>();
         canvas.enabled = false;
         nowText = 0;
         coment = true;
         //表示文字数初期化
         viewNum = 0;
     }

     private IEnumerator DelayCoroutine(float seconds, UnityAction callback)
     {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
     }

     public bool GetStartFlag(){
       return ismove;
     }

     public bool StartFlag()
     {
         //手動開始条件
         if (Input.GetKeyDown(KeyCode.Z))
         {
             return true;
         }
         return false;
     }

     public void getItemposNum(int n){
       this.a = n;
     }

     public int SendItemposNum(){
       return a;
     }

     public bool getEndFlag()
     {
         Debug.Log(isComanndo);
         return isComanndo;
     }

     public int getNowtext(){
       return nowText;
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
         //button.SetActive(false);
         isComanndo = false;
       }
     }

     public int getWindowNum(){
       return wn;
     }

     public void setWindowNum(int x){
       this.wn = x;
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
         //button.SetActive(false);
         //表示文字数初期化

       //}
     }

     //会話フラグの受け渡し
     public bool getSpeakFlag()
     {
         return isSpeak;
     }

     /*public void messagetest(string[] viewMessage){
       if(StartFlag()){
       for(int i =0;i<viewMessage[nowText].Length;i++){
       canvas.transform.Find("MessageText1").GetComponent<Text>().text = viewMessage[nowText].Substring(0, i);
     }
     nowText++;
    }
   }*/

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
        nowText++;
       //書いている途中の状態を解除する
       //isWriting = false;
     }
   }



     /// <summary>
     /// 会話（string[] 会話内容）
     /// Zキーを押すと次のテキストを表示する　表示は1フレーム1文字
     /// </summary>
     public void message2(string[] viewMessage, string name = null)
     {
        //StartCoroutine(DelayCoroutine(0.5f, () => {
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
                       for(int j=0;j<viewNum;j++){
                         StartCoroutine(DelayCoroutine(0.1f, () => {
                       canvas.transform.Find("MessageText1").GetComponent<Text>().text = viewMessage[nowText];
                         }));
                   }
                 }
                   else
                   {
                       //文字をすべて表示する
                       canvas.transform.Find("MessageText1").GetComponent<Text>().text = $"{name}\n{viewMessage[nowText]}";
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
                   //button.SetActive(getEndFlag());
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
               canvas.transform.Find("MessageText1").GetComponent<Text>().text = null;

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

           else
           {
               if (viewNum < viewMessage[nowText].Length)
               {
                   //表示文字数を増加
                   Debug.Log(viewNum);
                  // StartCoroutine(DelayCoroutine(0.1f, () => {
                   viewNum++;
                  // }));
                   int i=0;
                   if (name == null)
                   {
                       //文字をすべて表示する
                      // StartCoroutine(DelayCoroutine(1.0f, () => {
                              //cocoa.SetActive(false);
                      //for(int j=0;j<viewMessage[nowText].Length;j++){
                      //StartCoroutine(DelayCoroutine(0.1f, () => {
                       canvas.transform.Find("MessageText1").GetComponent<Text>().text = viewMessage[nowText].Substring(0, viewNum);
                       //viewNum++;
                        //  }));
                       //canvas.transform.Find("MessageText1").GetComponent<Text>().text = viewMessage[nowText].Substring(0, viewNum);
                     //}
                   }
                   else
                   {
                       //文字をすべて表示する
                       canvas.transform.Find("MessageText1").GetComponent<Text>().text = $"{name}\n{viewMessage[nowText].Substring(0, viewNum)}";
                   }
                   //isComanndo = false;
                   i++;
               }
               //イベント中&amp;最後のメッセージ&amp;文字の表示がすべて終わりなら
               /*else if (isEvent && viewNum == viewMessage[nowText].Length && nowText == viewMessage.Length - 1)
               {
                   //isComanndo = false;
                  isEvent = false;
               }*/

           }
       }
        //}));
     }


   }
