using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalBook : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] signboard = {"所々本が焦げている",
                       "焦げた星座図鑑に何か挟まっている。","リゲルとスピカの写真を手に入れた。"};
    /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                       "これを調べますか？"};*/

      private float speakLine = 0.9f;

      public GameObject button;
      public Transform plPos;
      public int fbs = 0;
      private int a;

    //  public Transform pos;
      //public GameObject gameObject;
      [SerializeField]
      private Message2 messageScript;
      private bool TriggerBS;
      private idou pos;
      public ItemData itemData;

      // Start is called before the first frame update
      void Start()
      {
          plPos = GameObject.Find("Player").GetComponent<Transform>();

      }

      public int getSwengkit(){
        return fbs;
      }

      // Update is called once per frame
      void Update()
      {
        if(TriggerBS&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){
          Debug.Log("bbb");
          Message2.Instance.StartCoroutine("WriteRoutine",signboard);
          a = Message2.Instance.getNowtext();
          switch (a) {
            case 0:
            if(Message2.Instance.getSpeakFlag())

            Debug.Log("無表情");
            break;
            case 1:
            Debug.Log("驚き");

            break;
            case 2:
            Debug.Log("なし");
            itemData.item[5].Flag = true;
            break;
          }
          fbs=1;
      }
      fbs=0;
  }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("aaa");
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
