using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class cardBack : MonoBehaviour
{

    public GameObject cardback1;
    public GameObject cardback2;
    public GameObject cardback3;
    public Button select1;
    public Button select2;
    public Button select3;
    public Button goBack;
    public int playerChoice = 1;
    // Start is called before the first frame update
    void Start()
    {
        select1.onClick.AddListener( () => PlayerPrefs.SetInt("playerChoice", 1));
        select2.onClick.AddListener( () => PlayerPrefs.SetInt("playerChoice", 2));
        select3.onClick.AddListener( () => PlayerPrefs.SetInt("playerChoice", 3));
        goBack.onClick.AddListener( () => goMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateChoice(int selected){
        Debug.Log(playerChoice);
        PlayerPrefs.SetInt("playerChoice", selected);
    }
    public void goMenu(){
        SceneManager.LoadScene("Menu" , LoadSceneMode.Single);

    }
    public int getPlayerSelection(){
        return playerChoice;
    }
}
