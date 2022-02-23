using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
  public string[] signboard = {"ふかふかのベッドだ。\nよく見るとしたから何かはみ出している。",
                     "・・・・・・","梯子のようだ。しかし足場が何箇所か抜け落ちている。"
                     ,"代わりになるものを持ってこよう"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
  	private Message2 messageScript;
    private bool TriggerB;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(TriggerB&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){
        //Debug.Log(Message.Instance.SendItemposNum());

          Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        Message.Instance.getItemposNum(3);
        Message2.Instance.getItemposNum(3);

    }
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerB = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerB = false;
        }
    }
}
