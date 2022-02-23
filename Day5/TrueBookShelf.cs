using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueBookShelf : MonoBehaviour
{
  public string[] signboard = {"背表紙はどれも焦げてしまって読めない。",
                     "一冊手に取って、ぱらぱらとめくってみる。","写真を手に入れた。"};
  /*public string[] signboard1={"ここに今にも壊れそうな円がある。",
                     "これを調べますか？"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
  	private Message2 messageScript;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();



    }

    // Update is called once per frame
    void Update()
    {
      if((plPos.position - transform.position).magnitude <= speakLine&&Input.GetKeyDown(KeyCode.Z)&&Message.Instance.coment){
        Debug.Log("bbb");

        Message2.Instance.StartCoroutine("WriteRoutine",signboard);

    }
}
}
