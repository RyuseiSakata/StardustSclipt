using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalCreate : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] signboard = {"���X�{���ł��Ă���",
                       "�ł��������}�ӂɉ������܂��Ă����B","���Q���ƃX�s�J�̎ʐ^�����ɓ��ꂽ�B"};
    /*public string[] signboard1={"�����ɍ��ɂ����ꂻ���ȉ~�������B",
                       "�����𒲂ׂ܂����H"};*/

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    public int fbs = 0;
    private int a;

    //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript;
    private bool TriggerBS;
    private idou pos;
    public ItemData itemData;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();

    }

    public int getSwengkit()
    {
        return fbs;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerBS&&Input.GetKeyDown(KeyCode.Z)&&Message.Instance.coment)
        {
            Debug.Log("bbb");
              Message2.Instance.StartCoroutine("WriteRoutine",signboard);
            a = Message2.Instance.getNowtext();
            switch (a)
            {
                case 0:
                    if (Message2.Instance.getSpeakFlag())
                      Debug.Log("�����");
                    break;
                case 1:
                    Debug.Log("����");

                    break;
                case 2:
                    Debug.Log("�Ȃ�");
                    itemData.item[5].Flag = true;
                    break;
            }
            fbs = 1;
        }
        fbs = 0;
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
