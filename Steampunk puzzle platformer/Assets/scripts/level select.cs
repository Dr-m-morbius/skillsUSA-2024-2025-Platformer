using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class levelselect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public int LevelOne;
public int Leveltwo;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnlvloneButtonPressed()
    {
        SceneManager.LoadScene(LevelOne);
    }
    public void OnlvltwoButtonPressed()
    {
        SceneManager.LoadScene(Leveltwo);
    }
}
