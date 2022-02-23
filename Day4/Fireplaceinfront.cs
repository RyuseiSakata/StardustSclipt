using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplaceinfront : MonoBehaviour
{
    // Start is called before the first frame update
      public Transform plPos;
      private float speakLine = 0.9f;
      public string[] signboard = {"ここに今にも壊れそうなsikakuがある。",
                         "これを調べますか？"};
     [SerializeField]
      private Message2 messageScript;
      
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if((plPos.position - transform.position).magnitude <= speakLine){
        Message2.Instance.getItemposNum(13);
        Message.Instance.getItemposNum(13);
        Message2.Instance.message2(signboard);

    }
    Message2.Instance.getItemposNum(0);
    Message.Instance.getItemposNum(0);
    }
}
