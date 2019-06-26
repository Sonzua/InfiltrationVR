using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slider : MonoBehaviour
{
    public GameObject scriptreperage;
    public float percent = 0;

    public float OldValue;

    float NewMax=2f;

    public Text TextDetection;

    string TextToShow = "hi";

    public float valuetoint;
    public int value;
    public RectTransform fillRect;
    public object direction;

    public Image targetGraphic { get; set; }
    public static object Direction { get; set; }

    void Start()
    {

    }
    void Update()
    {

        OldValue = GameManager.instance.timer;

        percent = OldValue / NewMax;

        GetComponent<Image>().fillAmount = percent;

        //GetComponent<Image>().color = Color.Lerp(Color.green, Color.red, percent);

        valuetoint = percent * 100;



        if (valuetoint < 50)
        {
            if (valuetoint < 10)
            {
                FindObjectOfType<AuidoManager>().Play("Alerte", 0);
            }
            GetComponent<Image>().color = new Color(0, 0.7f, 1);
        }
        if (valuetoint > 50)
        {
            FindObjectOfType<AuidoManager>().Play("Alerte", valuetoint / 100);

            GetComponent<Image>().color = new Color(1, 0.1f, 0);
            
        }


        TextToShow = ((int)valuetoint).ToString();



        if (valuetoint >= 0 && !(valuetoint > 100.99f ))
        {
            
            TextDetection.text = TextToShow;

        }

    }

}