using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedsidechest : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] signboard = {"綺麗なチェストだ引き出しに何か入っている。",
                       "裁縫セットを手に入れた。"};
    /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                       "これを調べますか？"};*/

      private float speakLine = 0.9f;

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
        if(TriggerBC&&Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment){
          Debug.Log("bbb");

            Message2.Instance.StartCoroutine("WriteRoutine",signboard);
          itemData.item[4].Flag = true;
      }

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
