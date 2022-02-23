using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HappyBookShelf : MonoBehaviour
{
  public string[] signboard = {"様々な種類の本が並んでいる。","どの本を手に取りますか？"};
  public string[] signboard1 = {"星の王子様だ！","スピカが初めて読んでくれた本だ！"
                        ,"大切な人と離れ離れになるのは悲しいよね","でも僕たちはこうしてずっと一緒にいられるから幸せだね！"};
    private float speakLine = 0.9f;
    //public GameObject button;
    public Transform plPos;
    public Sprite imagemade1;
    public Sprite imagemade2;
    public Sprite imagemade3;
    public Image myPhoto;
    public Image myPhoto2;
    //public Collider2D collider;
    [SerializeField]
  	private Message messageScript;
    private bool TriggerHBS;
    public ItemData itemData;
    public GameObject button;
  //  public GameObject bunki;
    private int n;
    private int a;
    private int p;


      // Start is called before the first frame update
      void Start()
      {
        //プレイヤーの座標取得
        plPos = GameObject.Find("Player").GetComponent<Transform>();
        myPhoto = GameObject.Find("b").GetComponent<Image>();
        myPhoto.enabled = false;
        //myPhoto2 = GameObject.Find("m").GetComponent<Image>();
      //  myPhoto2.enabled = false;
      }

      public void Onyes ()
      {
        string[] signboard = {"見覚えのある本を見つけた\n。星座図鑑を手に入れた"};

          //Message.Instance.NextFours();
          a = 8;
          Message.Instance.setEndFlag(false);
          SetSignboad(signboard);
          Message.Instance.NextFours();
          Debug.Log("mimimimi");
          p=1;

          //Message.Instance.message(signboard);
          button.SetActive(false);
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
        string[] signboard = {"星の王子様だ！","スピカが初めて読んでくれた本だ！"
                              ,"大切な人と離れ離れになるのは悲しいよね","でも僕たちはこうしてずっと一緒にいられるから幸せだね！"};

          Message.Instance.NextFours();
          Message.Instance.setEndFlag(false);
          SetSignboad(signboard);
          Message2.Instance.getItemposNum(4);
          Message.Instance.getItemposNum(4);
          a=6;
        //  n++;
          /*if(a==1)
          a=2;
          if(a==3){
          Message.Instance.setEndFlag(true);*/
          p=1;
          /*string[] signboard1 = {"様々な種類の本が並んでいる。","ここを調べよう？"};
          SetSignboad(signboard1);*/
        //}
    }
      // Update is called once per frame
      void Update()
      {
        //メッセージの表示条件
        if(TriggerHBS&&Input.GetKeyDown(KeyCode.Z)&&Message.Instance.coment||(p==1&&Message.Instance.coment/*&&Input.GetKeyDown(KeyCode.Z)*/)){
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
        p=0;
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
        string[] signboard = {"様々な種類の本が並んでいる。","どの本を手に取りますか？"};
        SetSignboad(signboard);
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
            TriggerHBS = true;
            Debug.Log("dddddddddd");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerHBS = false;
        }
    }
}
