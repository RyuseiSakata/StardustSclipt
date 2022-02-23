using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4_BookShelf : MonoBehaviour
{
  // Start is called before the first frame update
  public string[] signboard = {"背表紙はどれも焦げてしまって読めない。"
                                ,"棚の上に何かあるようだ。\nしかし手が届かない"};
  public string[] signboard1={"ボロボロの玩具箱のようだ。奥で何か光っている",
                     "ボロボロの人形を手に入れた。"};

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    public Transform chPos;
    public Transform chePos;
  //  public Transform pos;
    //public GameObject gameObject;
    private int fbsf = 0;
    [SerializeField]
    private ItemData itemData;
    private Message2 messageScript;
    private bool TriggerBS;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
        chPos = GameObject.Find("Chest").GetComponent<Transform>();
        chePos = GameObject.Find("ChestEvent").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(fbsf==0&&TriggerBS&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){
        Debug.Log("bbb");

        Message2.Instance.StartCoroutine("WriteRoutine",signboard);

    }
    else if(chPos==chePos&&TriggerBS){
      Message.Instance.EndFours();
      //CharacterView.Instance.SetCharacterImage(m7);
      Message2.Instance.StartCoroutine("WriteRoutine",signboard1);
      itemData.item[14].Flag = true;
      fbsf=-1;
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
