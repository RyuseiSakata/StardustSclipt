using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day3_BookShelf : MonoBehaviour
{
  public string[] signboard = {"綺麗なチェストだ。引き出しは開かない。",
                     "何かが引っかかっているようだ。"};
  public string[] signboard1={"・・・・・","星座図鑑を調べてみようか"};
    private float speakLine = 0.9f;
    public string[] sighnboad2= {"様々な種類の本がある。","奥に何かある。","バールを手に入れた。"};

    public GameObject button;
    public Transform plPos;
    public int fbs = 0;
    public Sprite imagemade1;
    public Sprite imagemade2;
    public Image myPhoto;
    public int count =0;
    //private SighnBoard sighnboad;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript;
    private idou pos;
    private bool TriggerBS;
    public ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    public int getSwengkit(){
      return fbs;
    }

    public void Onyes(){
      string[] signboard = {"星座図鑑を取り出した。","間に何か挟まっているようだ。","手紙を手に入れた。"};

        Message.Instance.NextFours();
        Message.Instance.setEndFlag(false);
        SetSignboad(signboard);
        itemData.item[7].Flag = true;
        //Message.Instance.message(signboard);
        //Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        fbs=0;
        if(Message.Instance.getEndFlag()){
          Debug.Log("ここで１に戻せたらなぁ");
        //  Message2.Instance.setWindowNum(1);
        }



    }
    public void SetSignboad(string[] ca_sighnboard){
      this.signboard = ca_sighnboard;
    }

    public void Onno(){
      string[] signboard = {"・・・・・"};

        Message.Instance.NextFours();
        Message.Instance.setEndFlag(false);
        SetSignboad(signboard);



    }

    // Update is called once per frame
    void Update()
    {
      if(fbs==0&TriggerBS&&Message2.Instance.coment&&Input.GetKeyDown(KeyCode.Z))
        {


        Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        //Message2.Instance.EndFours();
        Debug.Log(Message2.Instance.getWindowNum());

        if(count==1&&Message2.Instance.getEndFlag()){
        fbs=1;
      }
        if(count==4){
          fbs=2;
        }
        count ++;
    }

    else if(fbs==2&&TriggerBS&&Message2.Instance.coment&&Input.GetKeyDown(KeyCode.Z))
        {
      Debug.Log(fbs);
     Message.Instance.EndFours();
        Message2.Instance.StartCoroutine("WriteRoutine",sighnboad2);
      if(Message.Instance.getEndFlag()){
        fbs=-2;
    }
      Message2.Instance.setWindowNum(0);
    }

    else if(fbs==1&&TriggerBS&&Message.Instance.coment&&Input.GetKeyDown(KeyCode.Z)){

        Message2.Instance.EndFours();
        Message.Instance.StartCoroutine("WriteRoutine",signboard1);
        button.SetActive(false);
        //Message.Instance.EndFours();
        Debug.Log(fbs);

    }

    else if(fbs == -2){
      Message2.Instance.setWindowNum(0);
    fbs=-1;
}
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
