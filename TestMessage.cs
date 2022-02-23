using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMessage : MonoBehaviour
{
  private int viewNum = 0;        //表示文字数制限用
  private int nowText = 0;        //表示中のテキスト番号
  private bool isSpeak = false;   //会話中フラグ
  private bool isEvent = false;   //イベントフラグ
  private bool isOneTime = false; //ワンタイムフラグ
  private bool isComanndo = true;
  private Canvas canvas;
  public Text text;
  private readonly TextLoader textLoader = new TextLoader();
  //private Dictionary<int, string> messages;
  string[] outputword;
  public int a;
  public int wn;

  private void Start()
  {
    //StartCoroutine("WriteRoutine");
    canvas = GameObject.Find("MessageCanvas").GetComponent<Canvas>();
    canvas.enabled = false;
  }
    // Start is called before the first frame update
    private static TestMessage instance;
    public static TestMessage Instance
    {
        get
        {
            //instanceがあるか判定
            if(instance == null)
            {
                instance = (TestMessage)FindObjectOfType(typeof(TestMessage));

                //取得できなければエラーを返す
                if(instance == null)
                {
                    Debug.LogError(typeof(TestMessage) + "is nothing(キャンバスのオブジェクトが見つかりません)");
                }
            }
            return instance;
        }
    }


      //ここからは番号などの取得

      private bool StartFlag()
      {
          //手動開始条件
          if (Input.GetKeyDown(KeyCode.Z))
          {
            Debug.Log("我々はzキーだ");
              return true;
          }
          return false;
      }
      public bool getSpeakFlag()
      {
          return isSpeak;
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


         public int getWindowNum(){
           return wn;
         }

         public void setWindowNum(int x){
           this.wn = x;
         }

         //ここは必要なければ使わない
        /* public bool getSpeakFlag()
         {
             return isSpeak;
         }*/


      public float writeSpeed = 0.1f;
      public bool isWriting;


      public IEnumerator WriteRoutine(string[] viewMessage)
      {
          //書いている途中の状態にする
        /*  for(int i=0; i < viewMessage.Length; i++)
    {
         outputword[i] = viewMessage[i];
    }*/
          name = null;
          Debug.Log("我々は宇宙人だ");
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

              else
              {
                  if (viewNum < viewMessage[nowText].Length)
                  {
                    //yield return new WaitForSeconds(writeSpeed);
                      //表示文字数を増加
                      viewNum++;
                        Debug.Log(viewMessage[nowText].Length);
                      if (name == null)
                      {
                          //文字をすべて表示する
                          for(int i = 0;i<viewMessage[nowText].Length;i++){
                          yield return new WaitForSeconds(writeSpeed);
                          canvas.transform.Find("MessageText").GetComponent<Text>().text += viewMessage[nowText].Substring(i, 1);

                      }

                    }
                      else
                      {
                          //文字をすべて表示する
                          for(int i = 0;i<viewMessage[nowText].Length;i++){
                          yield return new WaitForSeconds(writeSpeed);
                        //  canvas.transform.Find("MessageText").GetComponent<Text>().text += $"{name}\n{viewMessage[nowText].Substring(i, 1)}";
                        }
                      }
                      //isComanndo = false;
                      //StartCoroutine("WriteRoutine",viewMessage);
                  }
                  //イベント中&amp;最後のメッセージ&amp;文字の表示がすべて終わりなら
                  else if (isEvent && viewNum == viewMessage[nowText].Length && nowText == viewMessage.Length - 1)
                  {
                      //isComanndo = false;
                      isEvent = false;
                  }

              }
          }
              //次の文字を表示するまで少し待つ
              //yield return new WaitForSeconds(writeSpeed);
              //StartCoroutine("WriteRoutine");
      }

      //速さを調節する
      /*private void Write(string s)
      {

          if (highspeed == false)
          {
              //毎回、書くスピードを 0.2 に戻す------<戻したくない場合はここを消す>
              writeSpeed = 0.1f;
              StartCoroutine(WriteRoutine(s));
          }
          if (highspeed == true)
          {

              writeSpeed = 0.0f;
              StartCoroutine(WriteRoutine(s));

          }


      }*/

      /// テキストを消すメソッド
      private void Clean()
      {
          text.text = "";
      }

}
