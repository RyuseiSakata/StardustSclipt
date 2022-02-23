using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokenDoll : MonoBehaviour
{
  public string[] signboard = {"・・・・・・","可愛らしい人形だ。しかし腕の部分から綿がはみ出ている。"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
  	private Message2 messageScript;
    private bool TriggerBD;
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
      if(TriggerBD&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){
        Debug.Log("立ち絵を出したいな");
          Message2.Instance.StartCoroutine("WriteRoutine",signboard);
        Message2.Instance.getItemposNum(9);
        Message.Instance.getItemposNum(9);

    }
  /*  Message2.Instance.getItemposNum(0);
    Message.Instance.getItemposNum(0);*/
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerBD = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerBD = false;
        }
    }
}
