using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day4_Lump : MonoBehaviour
{
    public Image BrightnessPanel;
    public AudioClip sound_on;
    public AudioClip sound_off;
    AudioSource audioSource;
    private bool TriggerL;
    private bool Light_ON;
    public bool BrokenLump;

    public string[] signboard = {"�����肪���Ȃ�...",
                     "�����Ă����悤���B"};

    public float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
    //  public Transform pos;
    //public GameObject gameObject;
    [SerializeField]
    private Message2 messageScript;
    private bool TriggerSB2;
    private idou pos;

    [SerializeField] public GameObject eventManager;

    // Start is called before the first frame update
    void Start()
    {
        Light_ON = true;
        BrokenLump = true;
        audioSource = GetComponent<AudioSource>();
        //BrightnessPanel.color = new Color(Bred, Bgreen, Bblue, 60);

        plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  */
        if (TriggerL && Input.GetKeyDown(KeyCode.Z)&&Message2.Instance.coment)//Z�L�[���ΏۂɂȂ��Ă܂�
        {
            if (Light_ON && !BrokenLump)
            {
                audioSource.PlayOneShot(sound_off);
                Light_ON = false;
            }
            else if(!BrokenLump)
            {
                audioSource.PlayOneShot(sound_on);
                Light_ON = true;
            }
            else
            {
                Debug.Log("This Lump is broken.");
                Message2.Instance.StartCoroutine("WriteRoutine", signboard);
            }
        }

        if (TriggerL && EventFlag.day4Ramp)
        {
            BrokenLump = false;
        }

        if (Light_ON)
        {
            BrightnessPanel.color = new Color32(60, 60, 40, 60);
        }
        else
        {
            BrightnessPanel.color = new Color32(0, 0, 0, 180);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("aaa");
            TriggerL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SearchPoint"))
        {
            Debug.Log("iii");
            TriggerL = false;
        }
    }
}
