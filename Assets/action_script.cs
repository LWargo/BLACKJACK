using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class action_script : MonoBehaviour
{
    public cards_script cards_Script;
    public cardScript cardScript; 
    public GamePlay gamePlay;
    public int handVal = 0;

    
    //int randy2 = 0;
    private int money = 0 ;
    public GameObject[] hand;
    public int cIndex = 0; //card index
    public int aCount = 0; //counting aces
    List<cardScript> aces = new List<cardScript>();
    // Start is called before the first frame update
    void Start()
    {
       // randy2 = Random.Range(100,901);
        money = Random.Range(100,901); 
        
    }
    public void startHand(){
        getCard();
        getCard(); 
    }

    public int getCard(){
        Debug.Log(cIndex);
        int cardValu = cards_Script.Deal(hand[cIndex].GetComponent<cardScript>());
        Debug.Log("card value: " + cardValu);
        Debug.Log("hand val pre card value : " + handVal);
        hand[cIndex].GetComponent<Renderer>().enabled = true;
        handVal = handVal + cardValu;
        Debug.Log("hand value post adding card value: " + handVal);
        if(cardValu == 1){
            aces.Add(hand[cIndex].GetComponent<cardScript>());
        }
        Acefunc();
        cIndex++;
        return handVal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void adjustMoney(int amount){
        money = money + amount;
    }
    public int GetMoney(){
        return money;
    }

    public void Acefunc(){
        foreach(cardScript ace in aces){
            if (handVal + 10 < 22 && ace.GetValue() == 1){
                ace.SetValue(11);
                handVal = handVal + 10;
            }else if(handVal > 21 && ace.GetValue() == 1){
                ace.SetValue(1);
                handVal = handVal - 10;
            }
        }
    }

    public void ResetGame(){
        for(int i = 0; i < hand.Length; i++){
            hand[i].GetComponent<cardScript>().Reset();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cIndex = 0;
        handVal = 0;
        aces = new List<cardScript>();
       // adjustMoney(gamePlay.pot); 
       // gamePlay.pot = 0;
    }
}


