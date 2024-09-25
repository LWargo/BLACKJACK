using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GamePlay : MonoBehaviour
{

    public Button dealbutt;
    public Button hitbutt;
    public Button staybutt;
    public Button callbutt;
    public Button betbutt;
    public Button resetbutt;
    public action_script PS;
    public action_script DS;
    private int stayCount = 0;

    public Text Moneytxt;
    public Text Handtxt;
    public Text Bettext;
    public Text StateText;
    public bool roundEnded = false;
    public GameObject hid;
    public GameObject bird;
  //  public Text sbt; 
    //public Text announcement;

    public int pot = 0;
//    public cardBack CB;
    

    

    // Start is called before the first frame update
    void Start()
    {

        dealbutt.onClick.AddListener( () => dealFunc() );
        hitbutt.onClick.AddListener( () => hitFunc() );
        staybutt.onClick.AddListener( () => stayFunc() );
        betbutt.onClick.AddListener( () => betFunc());
        callbutt.onClick.AddListener( () => CheckCondition());
        resetbutt.onClick.AddListener( () => firstset());
        resetbutt.gameObject.SetActive(false);
        StateText.gameObject.SetActive(false);
        PS.ResetGame();
        DS.ResetGame();
        bird.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void dealFunc(){
        DS.ResetGame();
        PS.ResetGame();
        Debug.Log("Dealing Cards");
        GameObject.Find("Base").GetComponent<cards_script>().Shuffle();
        PS.startHand();
        DS.startHand();
        Handtxt.text ="Hand: " + PS.handVal.ToString();
        Bettext.text = "Bet: " + pot.ToString();
        Moneytxt.text = "Money: " + PS.GetMoney().ToString();
        pot = 50;
     //   Bettext.text = "Pot: $" + pot.ToString();
        PS.adjustMoney(-25);
        Moneytxt.text = "Money: " + PS.GetMoney().ToString();
    }
    private void hitFunc(){
        Debug.Log("Hitting you with a CARD");
        if(PS.getCard() < 10){
            PS.getCard();
        }
        Handtxt.text ="Hand: " + PS.handVal.ToString();
        dealerHitFunc();
       // CheckCondition();
    }
    private void stayFunc(){
        Debug.Log("Bro thinks he has a good hand; staying");
        stayCount++;
        dealerHitFunc();
      //  sbt.text = "Call";
    }

    private void dealerHitFunc(){
        hid.gameObject.SetActive(false);
        while(DS.handVal < 16 && DS.cIndex < 6){
            DS.getCard();
            //update Scores
        }
        CheckCondition();
    }

    public void CheckCondition(){
        bool playerBust = false;
        if( PS.handVal > 21) { playerBust = true;}
        bool dealerBust = false;
        if( DS.handVal > 21) { dealerBust = true;}
        bool p21 = false;
        if (PS.handVal == 21){p21 = true; }
        bool d21 = false;
        if(DS.handVal == 21 ) { d21 = true;}
        Debug.Log("checking for a win.....");

        if(playerBust == true && dealerBust == true){
                    hid.gameObject.SetActive(false);

            StateText.text = "EVERYONE LOST ";
            bird.gameObject.SetActive(true);
            StateText.gameObject.SetActive(true);
            PS.adjustMoney(pot/2);
            roundEnded = true;

        }else if (d21 == true|| PS.handVal == DS.handVal || playerBust == true || dealerBust == false && DS.handVal > PS.handVal){
            hid.gameObject.SetActive(false);
            bird.gameObject.SetActive(true);
            StateText.text = "House Wins!";
            StateText.gameObject.SetActive(true);
            roundEnded = true;
            pot = 0;

        } else if (p21 == true || dealerBust == true || DS.handVal < PS.handVal){
            hid.gameObject.SetActive(false);
            StateText.text = "Player Wins!!!";
            StateText.gameObject.SetActive(true);
            bird.gameObject.SetActive(true);
            PS.adjustMoney(pot + 25);
            pot = 0;
            roundEnded = true;
        } else if (PS.handVal == DS.handVal){
            hid.gameObject.SetActive(false);
            StateText.text = "TIE STATE";
            StateText.gameObject.SetActive(true);
            bird.gameObject.SetActive(true);
            PS.adjustMoney(pot/2);
            pot = 0;
            roundEnded = true;

        } else if (stayCount >= 2){
            roundEnded = true;
        }
        else {
            roundEnded = false;
        }
        if(roundEnded == true){
            
            Debug.Log("resetting the game");
            resetbutt.gameObject.SetActive(true);
            bird.gameObject.SetActive(true);

       //     Thread.Sleep(4000);
        //    StateText.gameObject.SetActive(false);
         //   Thread.Sleep(3500);
         //   PS.ResetGame();
         //   DS.ResetGame();
        }
    }

    public void betFunc(){
        PS.adjustMoney(-25);
        Moneytxt.text = "Money: " + PS.GetMoney().ToString();
        pot = pot + 50;
        
        Bettext.text = "Bet: $" + (pot-50).ToString();
    }

    public void firstset(){
        StateText.gameObject.SetActive(false);
        resetbutt.gameObject.SetActive(false);
        hid.gameObject.SetActive(true);
        bird.gameObject.SetActive(false);
        PS.ResetGame();
        DS.ResetGame();
    }
   
}
