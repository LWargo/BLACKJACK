using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameRules : MonoBehaviour
{
    // Start is called before the first frame update

    public Button MenuBtn;
    void Start()
    {
        MenuBtn.onClick.AddListener( () => goMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goMenu(){
        SceneManager.LoadScene("Menu" , LoadSceneMode.Single);

    }
}
