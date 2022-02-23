using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day4_Door : MonoBehaviour
{
  public string[] signboard = {"ずっしりと高級感のあるドアだ。","三日月のマークが彫られている。","鍵が閉まっているようだ。"};
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
    private bool TriggerD;
    private idou pos;

    [SerializeField] public Button dasshutuButton;
    [SerializeField] public GameObject dasshutuSelect;
    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        if (TriggerD && EventFlag.dasshutuFlag&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment)
        {
            Debug.Log("bbb");

              Message2.Instance.StartCoroutine("WriteRoutine",signboard);
            //itemData.item[0] = true;
            Message2.Instance.getItemposNum(2);
            Message.Instance.getItemposNum(2);
        }
        else if (TriggerD && !EventFlag.dasshutuFlag)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dasshutuSelect.SetActive(true);
                dasshutuButton.Select();
            }

            //itemData.item[0] = true;
            Message2.Instance.getItemposNum(2);
            Message.Instance.getItemposNum(2);
        }

        else if(TriggerD != true && (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow))){
            Message2.Instance.getItemposNum(0);
            Message.Instance.getItemposNum(0);
        }
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("aaa");
            TriggerD = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerD = false;
        }
    }
}
