using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{[SerializeField] Text ScoreValueText;
   public void NextLevel(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
       Time.timeScale=1;
    
}
public void Restart(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       Time.timeScale=1;
    
}
public void AddScore(int score){
    int scoreValue=int.Parse(ScoreValueText.text);
    scoreValue+=score;
    ScoreValueText.text=scoreValue.ToString();

}
public void Quit(){
    Application.Quit();
}
public void Menu(){
    Time.timeScale=1;
    SceneManager.LoadScene(0);

}
public void Controls(){
    Time.timeScale=1;
    SceneManager.LoadScene(1);
}
public void Play(){
    Time.timeScale=1;
    SceneManager.LoadScene(2);
}
}
