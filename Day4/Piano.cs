using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
  public string[] signboard = {"立派なピアノだよく手入れされている。"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;
    public GameObject button;
    public Transform plPos;
    //public Collider2D collider;
    [SerializeField]
  	private Message messageScript;
    private bool TriggerP;


      // Start is called before the first frame update
      void Start()
      {
        //プレイヤーの座標取得
        plPos = GameObject.Find("Player").GetComponent<Transform>();
      }

      public void Onyes ()
      {
      Debug.Log("ここでシーンを移動する");
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
        if(TriggerP&&Message.Instance.coment&&Input.GetKeyDown(KeyCode.Z)){
        //if(collider.gameObject.tag=="Player"){
          Debug.Log("aaaa");

          Message.Instance.message(signboard);

        }

        }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("aaa");
            TriggerP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerP = false;
        }
    }
}
