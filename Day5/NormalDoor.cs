using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalDoor : MonoBehaviour
{
  public string[] signboard = {"待って！",
                     "もうちょっと一緒にいて欲しいな！"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    public int fbs = 0;
    private int a;
  public Sprite imagemade1;
  public Sprite imagemade2;
  public Image myPhoto;
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
        myPhoto = GameObject.Find("Image").GetComponent<Image>();
        myPhoto.enabled = false;
    }

    public int getSwengkit(){
      return fbs;
    }

    // Update is called once per frame
    void Update()
    {
      if(TriggerBS&&Input.GetKeyDown(KeyCode.Z)&&Message.Instance.coment){
        Debug.Log("bbb");
        Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        a = Message2.Instance.getNowtext();
        switch (a) {
          case 0:
          if(Message2.Instance.getSpeakFlag())
          myPhoto.enabled = true;
          myPhoto.sprite = imagemade1;
          Debug.Log("無表情");
          break;
          case 1:
          Debug.Log("驚き");
          myPhoto.sprite = imagemade2;
          break;
          case 2:
          Debug.Log("なし");
          itemData.item[5].Flag = true;
          myPhoto.enabled = false;
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
