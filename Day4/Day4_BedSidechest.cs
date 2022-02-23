using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4_BedSidechest : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] signboard = {"今にも崩れそうなチェストだ。","引き出しは燃え落ち、炭と化している。"};
    public string[] signboard1={"奥で何か光っている。",
                       "ボロボロの懐中時計を手に入れた。"};

      private float speakLine = 0.9f;

      public GameObject button;
      public Transform plPos;
      public int fbs = 0;
    //  public Transform pos;
      //public GameObject gameObject;
      private int fbsf = 0;
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

      // Update is called once per frame
      void Update()
      {
        if(fbs==1&&TriggerBC&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){


              Message2.Instance.StartCoroutine("WriteRoutine",signboard1);
            //Message.Instance.EndFours();

            Debug.Log(fbs);
              if(!Message2.Instance.getEndFlag()&&Message2.Instance.getWindowNum()==1){
                //fbs=2;
                itemData.item[13].Flag=true;
              //  Message2.Instance.setWindowNum(0);
            }
        }
        else if(fbs==0&&TriggerBC&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){


            Message2.Instance.StartCoroutine("WriteRoutine",signboard);
          Debug.Log(Message2.Instance.getWindowNum());
          if(!Message2.Instance.getEndFlag()&&Message2.Instance.getWindowNum()==1){
          fbs=1;
        }
      }

            Message2.Instance.setWindowNum(0);




  }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("aaa");
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
