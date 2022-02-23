using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1_Bookshelf : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] signboard = {"様々な種類の本が並んでいる。",
                       "・・・・・！","星座図鑑を手に入れた。"};
    /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                       "これを調べますか？"};*/

      private float speakLine = 0.9f;

      public GameObject button;
      public Transform plPos;
      public int fbs = 0;
      private int a;
    public Sprite imagemade1;
    public Sprite imagemade2;
    public Sprite imagemade3;
    public Image myPhoto;
    //  public Transform pos;
      //public GameObject gameObject;
    //  private readonly Dictionary<string, CharacterView> viewDic = new Dictionary<string, CharacterView>();
      [SerializeField]
      private Message2 messageScript;
      private bool TriggerBS;
      private idou pos;
      public ItemData itemData;

      // Start is called before the first frame update
      void Start()
      {
          plPos = GameObject.Find("Player").GetComponent<Transform>();
          myPhoto = GameObject.Find("m").GetComponent<Image>();
          //myPhoto.enabled = false;
      }

      public int getSwengkit(){
        return fbs;
      }


      // Update is called once per frame
      void Update()
      {
        if(TriggerBS&&Input.GetKeyDown(KeyCode.Return)&&Message2.Instance.coment){
          Debug.Log("bbb");
          myPhoto.sprite = imagemade3;
            Message2.Instance.StartCoroutine("WriteRoutine",signboard);
          a = Message2.Instance.getNowtext();
          switch (a) {
            case 0:
            if(Message2.Instance.getSpeakFlag())
            //myPhoto.enabled = true;
            myPhoto.sprite = imagemade3;
            Debug.Log("無表情");
            break;
            case 1:
            Debug.Log("驚き");
            //viewDic["m"].SetCharacterImage(EmotionType.m7, true);
            myPhoto.sprite = imagemade2;
            break;
            case 2:
            Debug.Log("なし");
            itemData.item[5].Flag = true;
            myPhoto.sprite = imagemade3;
            break;
          }
          fbs=1;
          //myPhoto.sprite = imagemade3;
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
