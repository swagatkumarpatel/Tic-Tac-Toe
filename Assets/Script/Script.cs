
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
    int Turn;
    public Sprite[] Tick_Cross_Image;  
    public Button[] Buttons;
    public int[] Store_Who_Clicked;
    public Text Show_Winner;
    public GameObject[] Red_Lines;
    int Input_Count;
    void Start()
    {
        Turn = 0;
        Input_Count = 0;
       for(int i=0;i<Store_Who_Clicked.Length;i++)
        {
            Store_Who_Clicked[i] =10;
        }
    }

    public void Call_When_Button_Pressed(int Button_Number)
    {
        Buttons[Button_Number].image.sprite = Tick_Cross_Image[Turn];
        Buttons[Button_Number].interactable = false;
        Store_Who_Clicked[Button_Number] = Turn + 1;
        Input_Count = Input_Count + 1;
        
        if (Turn == 0)
        {
            Turn = 1;
        }
         else
        {
            Turn = 0;
          }
        int HU = Store_Who_Clicked[0] + Store_Who_Clicked[1] + Store_Who_Clicked[2];
        int HM = Store_Who_Clicked[3] + Store_Who_Clicked[4] + Store_Who_Clicked[5];
        int HD = Store_Who_Clicked[6] + Store_Who_Clicked[7] + Store_Who_Clicked[8];
        int VL = Store_Who_Clicked[0] + Store_Who_Clicked[3] + Store_Who_Clicked[6];
        int VM = Store_Who_Clicked[1] + Store_Who_Clicked[4] + Store_Who_Clicked[7];
        int VR = Store_Who_Clicked[2] + Store_Who_Clicked[5] + Store_Who_Clicked[8];
        int D1 = Store_Who_Clicked[0] + Store_Who_Clicked[4] + Store_Who_Clicked[8];
        int D2 = Store_Who_Clicked[2] + Store_Who_Clicked[4] + Store_Who_Clicked[6];
        int []checkwinner = { HU, HM, HD, VL, VM, VR, D1, D2 };
        for (int i = 0; i < checkwinner.Length; i++)
        {
            if (checkwinner[i] == 3)
            {
                Show_Winner.text = "PLAYER 1 WINS";
                Show_Lines(i);
;            }
            if (checkwinner[i] == 6)
            {
                Show_Winner.text = "PLAYER 2 WINS";
                Show_Lines(i);
            }
            if (Input_Count == 9 && checkwinner[i] != 3  && checkwinner[i] != 6)
            {
                SceneManager.LoadScene("Tic Tac Toe");
            }
        }
       
     }
    void Show_Lines( int linenumber)
    {
        Red_Lines[linenumber].gameObject.SetActive(true);
        for(int i=0;i<Buttons.Length;i++)
        {
            Buttons[i].interactable = false;
        }
    }
    public void loadscene()
    {
        SceneManager.LoadScene("Tic Tac Toe");
    }
}
