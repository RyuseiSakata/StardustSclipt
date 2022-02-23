using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SighnBoard : MonoBehaviour
{
  //表示テキスト
public string[] signboard = {"ここに今にも壊れそうな円がある。",
                   "これを調べますか？"};
/*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                   "これを調べますか？"};*/

  private float speakLine = 0.9f;
  public GameObject button;
  public Transform plPos;
  //public Collider2D collider;
  [SerializeField]
	private Message messageScript;


    // Start is called before the first frame update
    void Start()
    {
      //プレイヤーの座標取得
      plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void Onyes ()
    {
    string[] signboard = {"星座図鑑を取り出した",
    "・・・・！","間に何か挟まっているようだ","手紙を手に入れた"};

    //this.signboard = null;

      Message.Instance.NextFours();
      Message.Instance.setEndFlag(false);
      SetSignboad(signboard);
      Debug.Log("ここでミニゲームに移動できたらなぁ");
    //  Message.Instance.message(signboard);
      //button.SetActive(false);
    }
    public void SetSignboad(string[] ca_sighnboard){
      this.signboard = ca_sighnboard;
    }

    public string[] GetSignboad(){
      return signboard;
    }



    public void Onno()
    {
      Message.Instance.setEndFlag(true);
      Message.Instance.EndFours();
    }
    // Update is called once per frame
    void Update()
    {
      //メッセージの表示条件
      if((plPos.position - transform.position).magnitude <= speakLine){
      //if(collider.gameObject.tag=="Player"){
        Debug.Log("aaaa");
        //.SetMessagePanel (message);
      //  signboard = GetSignboad();
        Message.Instance.message(signboard);
        //messageScript.SetMessagePanel (message);
      //  Debug.Log(Message.Instance.message(signboard));
      }
      //離れたら消える処理(変わるかも)
      /*else if((plPos.position - transform.position).magnitude > speakLine){

        Message.Instance.EndFlag();
      }*/
      }
      //分岐ではいが押されたら





}
