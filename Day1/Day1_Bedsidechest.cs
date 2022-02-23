using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1_Bedsidechest : MonoBehaviour
{
  public string[] signboard = {"綺麗なチェストだ。引き出しの取っ手の部分に鍵がかかっている。",
                     "裁縫セットを手に入れた。"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 1.0f;

    public GameObject button;
    public Transform plPos;
    public int fbs = 0;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript;
    private bool TriggerBC;
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
      if(TriggerBC&&Input.GetKeyDown(KeyCode.Return)&&Message2.Instance.coment)
        {
        Debug.Log("bbb");

        Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        fbs=1;
        itemData.item[4].Flag = true;
        Message2.Instance.getItemposNum(1);
        Message.Instance.getItemposNum(1);
    }
      /*Message2.Instance.getItemposNum(0);
      Message.Instance.getItemposNum(0);*/
    fbs=0;
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerBC = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerBC = false;
        }
    }
}
