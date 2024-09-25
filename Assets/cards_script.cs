using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;



public class cards_script : MonoBehaviour
{
    public Sprite[] allCards;
    public int[] cardValues = new int[53];
    public Sprite [] allBacks;
    private int valueIndex;

    public cardBack CB;
    public Sprite back1;
    public Sprite back2;
    public Sprite back3;

    // Start is called before the first frame update
    void Start()
    {
       
        AssignValue();
        checkPlayerChoice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AssignValue(){
        int val = 0; //original valye
        for(int i = 0; i < allCards.Length; i++){ //go through all card
            val = i;
            val = val % 13; //divide by 13 bc 13 in a suite
            if(val == 10 || val == 0){ //if jack, queen, or king then always 10
                val = 10;
            }
            cardValues[i] = val++;
        }
        valueIndex++;
    }
    public void Shuffle(){
        //int tot = allCards.Length;
        for(int i = (allCards.Length  - 1); i > 0; i--){
            int ii = Mathf.FloorToInt(Random.Range(0f,1f) * (allCards.Length - 1)) + 1; //random val to swap with
            Sprite front = allCards[i]; //temp value for sprite
            allCards[i] = allCards[ii]; //swap value
            allCards[ii] = front; //assign temp
            int vali = cardValues[i]; //temp variable for value
            cardValues[i] = cardValues[ii]; //swap value
            cardValues[ii] = vali; //assign temp
        }
        Debug.Log("deck was shuffled; prep for takeoff");
    }

    public int Deal(cardScript cardScript){
        

      //  Debug.Log("starting to deal");
        cardScript.SetSprite(allCards[valueIndex]);
     //   Debug.Log("sprites set");

        cardScript.SetValue(cardValues[valueIndex]);
        Debug.Log("values set");

        valueIndex++;
        return cardScript.GetValue();

    }
    public Sprite GetCardBack(){
        
        return allCards[0];
    }

    public Sprite selectedBacking(){
        int p = PlayerPrefs.GetInt("playerChoice");
        if(p == 1){
            GameObject bb; 
            bb = GameObject.Find("Base");
            bb.transform.localScale = new Vector3(15f, 15f, 0);
            GameObject hh;
            hh = GameObject.Find("Hidden_pig_card");
            hh.transform.localScale = new Vector3(15f, 15f, 0);
            return back1;
        }
        if(p == 2){
            GameObject bb; 
            bb = GameObject.Find("Base");
            bb.transform.localScale = new Vector3(5f, 5f, 0);
            GameObject hh;
            hh = GameObject.Find("Hidden_pig_card");
            hh.transform.localScale = new Vector3(5f, 5f, 0);
            return back2;
        }
        if(p == 3){
             GameObject bb; 
            bb = GameObject.Find("Base");
            bb.transform.localScale = new Vector3(5f, 5f, 0);
            GameObject hh;
            hh = GameObject.Find("Hidden_pig_card");
            hh.transform.localScale = new Vector3(5f, 5f, 0);
            return back3;
        }
        else{
            
            return back1;
        }
        
    }
     public void checkPlayerChoice(){
        //SpriteRenderer front;
       // Debug.Log("card back selection: " + p);
        GetComponent<SpriteRenderer>().sprite = selectedBacking();
        GetComponent<SpriteRenderer>().sprite = selectedBacking();


    }
  
}
