using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3_BedsideChest : MonoBehaviour
{
  public string[] signboard = {"綺麗なチェストだ。引き出しは開かない。",
                     "何かが引っかかっているようだ。"};
  public string[] signboard1 = {"綺麗なチェストだ。","引き出しの中に何かある。\nランプの絵のようだ。","黄色のクレヨンで描かれている。子供が描いたのだろうか?"};

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    public int fbs = 0;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript;
    private idou pos;
    private bool TriggerBC;
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

      if(Message2.Instance.getWindowNum()==0&&TriggerBC&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){


          Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        Message2.Instance.EndFours();
        Debug.Log(Message2.Instance.getWindowNum());
        Message2.Instance.getItemposNum(1);
        Message.Instance.getItemposNum(1);
        if(Message2.Instance.getSpeakFlag()){
        fbs=1;
      }
    }

    else if(Message2.Instance.getWindowNum()==1&&TriggerBC&&Input.GetKeyDown(KeyCode.Z)){


        Message2.Instance.StartCoroutine("WriteRoutine",signboard1);
        //Message.Instance.EndFours();

        Debug.Log(fbs);
          if(!Message.Instance.getEndFlag()){
            fbs=2;
          //  Message2.Instance.setWindowNum(0);
        }
    }

    else if(fbs == 2){
          Message2.Instance.setWindowNum(0);
    fbs=-1;
}
}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerBC = true;
            Debug.Log("dddddddddd");
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
