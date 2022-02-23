using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createblock : MonoBehaviour
{
  public string[] signboard = {"色とりどりの積み木がある",
                     "長い円柱の積み木を手に入れた"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    public int fc = 0;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    public ItemData itemData;
  	private Message2 messageScript;
    private bool TriggerCB;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(TriggerCB&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){
        Debug.Log("bbb");

          Message2.Instance.StartCoroutine("WriteRoutine",signboard);

        itemData.item[8].Flag = true;
    }
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerCB = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerCB = false;
        }
    }
}
