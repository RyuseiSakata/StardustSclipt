using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookShelf : MonoBehaviour
{
  public string[] signboard = {"様々な種類の本が並んでいる。","ここを調べよう？"};
  public string[] signboard1 = {"棚の上を調べたい","手を伸ばしてみたが届かなかった"};
    private float speakLine = 0.9f;
    //public GameObject button;
    public Transform plPos;
    //public Collider2D collider;
    [SerializeField]
  	private Message messageScript;
    private bool TriggerBS;
    public ItemData itemData;
    public GameObject button;
  //  public GameObject bunki;
    private int n;
    private int a;


      // Start is called before the first frame update
      void Start()
      {
        //プレイヤーの座標取得
        plPos = GameObject.Find("Player").GetComponent<Transform>();
      }

      public void Onyes ()
      {
      string[] signboard = {"・・・","本を並べ替えることができそうだ。"};

        //Message.Instance.NextFours();
        a = 8;
        Message.Instance.setEndFlag(false);
        SetSignboad(signboard);
        Message.Instance.NextFours();
        Debug.Log("mimimimi");

        //Message.Instance.message(signboard);
        //button.SetActive(false);
        Message.Instance.EndFours();
        if(Message.Instance.getEndFlag()){
          Debug.Log("ここでミニゲームに移動できたらなぁ");
          //Message.Instance.EndFours();
          n++;
        }
      }

      public void SetSignboad(string[] ca_sighnboard){
        this.signboard = ca_sighnboard;
      }

      public string[] GetSignboad(){
        return signboard;
      }



      public void Onno()
      {

        string[] signboard = {"手を伸ばしてみたが届かなかった"};

          Message.Instance.NextFours();
          Message.Instance.setEndFlag(false);
          SetSignboad(signboard);
          Message2.Instance.getItemposNum(4);
          Message.Instance.getItemposNum(4);
          a=6;
          n++;
          if(a==1)
          a=2;
          if(a==3){
          Message.Instance.setEndFlag(true);
          string[] signboard1 = {"様々な種類の本が並んでいる。","ここを調べよう？"};
          SetSignboad(signboard1);
        }

    }
      // Update is called once per frame
      void Update()
      {
        //メッセージの表示条件
        if(TriggerBS&&Input.GetKeyDown(KeyCode.Z)&&Message.Instance.coment){
        //if(collider.gameObject.tag=="Player"){
          Debug.Log("aaaa");
          Message2.Instance.getItemposNum(4);
          Message.Instance.getItemposNum(4);
          //.SetMessagePanel (message);
        //  signboard = GetSignboad();
        //button.GetComponent<Text1> ().text = "棚を調べる";
        /*Message.Instance.setBFlag(1);
        button.GetComponentInChildren<Text>().text = "棚を調べる";
        button.GetComponentInChildren<Text> ().text = "棚の上を調べる";
        if(Message.Instance.getWindowNum()==0)*/
        if(n<=1){
          //Message.Instance.EndFours();
        Message.Instance.StartCoroutine("WriteRoutine",signboard);
        if(a==6&&Message.Instance.getWindowNum()==1){
          a=2;
          Message.Instance.setWindowNum(0);
        }
        if(a==9){
          a=2;
        }
      }
      if(a==2){
        Message.Instance.setEndFlag(true);
        string[] signboard = {"様々な種類の本が並んでいる。","ここを調べよう？"};
        SetSignboad(signboard);
      }
        if(a==8&&Message.Instance.getWindowNum()==1){
          Debug.Log("ここでミニゲームに移動できたらなぁ");
          Message.Instance.EndFours();
          SceneManager.LoadScene ("Day2minigame");
          n++;
        }
        if(n>1){
          Message2.Instance.EndFours();
          Message2.Instance.message2(signboard1);
        }
        /*Message2.Instance.getItemposNum(4);
        Message.Instance.getItemposNum(4);*/
          //messageScript.SetMessagePanel (message);
        //  Debug.Log(Message.Instance.message(signboard));

        }

        }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerBS = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerBS = false;
        }
    }

}
