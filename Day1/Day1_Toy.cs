using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Day1_Toy : MonoBehaviour
{
    public Transform plPos;
    public int fbs = 0;

    //  public Transform pos;
    //public GameObject gameObject;
    //  private readonly Dictionary<string, CharacterView> viewDic = new Dictionary<string, CharacterView>();
    [SerializeField]
    private Message2 messageScript;
    private bool TriggerT;
    private idou pos;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
        //myPhoto.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerT && Input.GetKeyDown(KeyCode.Return) && fbs == 0)
        {
            //�~�j�Q�[���ֈڂ�
            fbs = 1;
            SceneManager.LoadScene("Day2minigame");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerT = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            TriggerT = false;
        }
    }
}
