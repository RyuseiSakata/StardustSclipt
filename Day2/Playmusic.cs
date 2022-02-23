using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playmusic : MonoBehaviour
{
  public string[] signboard = {"ここに今にも壊れそうなsikakuがある。",
                     "これを調べますか？"};

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
  //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript;
    private bool TriggerPM;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
      if(TriggerPM){
        Debug.Log("ここでSEを流す");

      //  Message2.Instance.message2(signboard);

    }
}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerPM = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerPM = false;
        }
    }
}
