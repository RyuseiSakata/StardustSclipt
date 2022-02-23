using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyDoor : MonoBehaviour
{
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
    private bool TriggerHD;


      // Start is called before the first frame update
      void Start()
      {
        //プレイヤーの座標取得
        plPos = GameObject.Find("Player").GetComponent<Transform>();
      }

      public void Onyes ()
      {
      string[] signboard = {"存在しない"};

        Message.Instance.NextFours();
        Message.Instance.setEndFlag(false);
        SetSignboad(signboard);
        //Message.Instance.message(signboard);
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
        if(TriggerHD&&Input.GetKeyDown(KeyCode.Z)&&Message.Instance.coment){
        //if(collider.gameObject.tag=="Player"){
          Debug.Log("aaaa");

          Message.Instance.StartCoroutine("WriteRoutine",signboard);

        }

        }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerHD = true;
            Debug.Log("dddddddddd");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerHD = false;
        }
    }


}
