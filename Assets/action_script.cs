using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class action_script : MonoBehaviour
{
    public cards_script cards_Script;
    public cardScript cardScript; 

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
        hand[cIndex].GetComponent<Renderer>().enabled = true;
        handVal = handVal + cardValu;
        if(cardValu == 1){
            aces.Add(hand[cIndex].GetComponent<cardScript>());
        }
        //acefunc();
        cIndex++;
        return handVal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
