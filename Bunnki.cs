using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunnki : MonoBehaviour
{
    // Start is called before the first frame update

    public Text textA;
    public Text textB;
    public GameObject button;
    public int sn;
    public GameObject gameObject;
    public string[] signboard;
  //  GameObject AAA = Instantiate(Event) as GameObject;
  	//private SighnBoard sighnboard;
    //public GameObject messagecanvas;

    void Start()
    {
      button.SetActive(false);
      gameObject = GameObject.Find("Event");
    }

    public void Ontriggersinario(){
      if(Message.Instance.getEndFlag()){
        button.SetActive(true);

      }
      else {
      //  button.SetActive(false);
      }
    }

    public void SetSignboad(string[] ca_sighnboard){
      this.signboard = ca_sighnboard;
    }

    public void setBFlag(int x){
      Debug.Log(sn);
      this.sn = x;
    }

    public int getBFlag(){
      return sn;
    }

   public void SelectTextA()
   {
     button.SetActive(false);
     Message.Instance.setEndFlag(false);
     Debug.Log(getBFlag());

     this.gameObject.SendMessage("Onyes");
       Debug.Log("A押された!");

   }
   public void SelectTextB()
   {
     button.SetActive(false);
       Debug.Log("B押された!");
      
       this.gameObject.SendMessage("Onno");

   }
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        Debug.Log("押された!");  // ログを出力
    }

    // Update is called once per frame
    void Update()
    {
  //  Ontriggersinario();
    }
}
