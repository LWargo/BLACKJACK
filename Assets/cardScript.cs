using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int value = 0;
    public int GetValue(){
        return value;
    } 
    public void SetValue( int newVal){
        value = newVal;
    }
    public void SetSprite( Sprite newSprite){
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

    }
    public string GetSpriteName(){
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void Reset(){
        Sprite back = GameObject.Find("DeckController").GetComponent<cards_script>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }


}
