using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4_music : MonoBehaviour
{
  public string[] signboard = {"古びたオルゴールだゼンマイを回しても動かない"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    private int a;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript2;
    private Message messageScript;
    private bool TriggerM;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
      if(TriggerM&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){

          Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        Message2.Instance.getItemposNum(13);
        Message.Instance.getItemposNum(13);
    }
  /*  Message2.Instance.getItemposNum(0);
    Message.Instance.getItemposNum(0);*/
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("aaa");
            TriggerM = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerM = false;
        }
    }
}
