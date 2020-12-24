using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour {
    public Animator anim;
    public Animator Setting;
    public Animator Social;
    bool isanimated=true;
    bool isSocial = false;
    bool isSetting = false;
    public Text hS;
    public ShowAds ads;
    public AudioSource audio;

    public GameObject exitpanel;

    //check for the animator
    void Start()
    {
        //Google Play Game
       
        if (exitpanel == null)
        {
            return;
        }else
        {
            exitpanel.SetActive(false); 
        }
           


        ads = FindObjectOfType<ShowAds>();
        if(anim==null)
        {
            return;
        }
        highScore();
    }


    //check if the back button is pressed
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitpanel.SetActive(true);
        }
    }

    public void exitNO()
    {
        exitpanel.SetActive(false);
    }
    public void exitYes()
    {
        Application.Quit();
    }

    //go to the play Screen
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    // go to the facebook
   public void Facebook()
    {
        Application.OpenURL("https://www.facebook.com/thephaseofgame");
    }
    //go to the twitter
    public void Twitter()
    {
        Application.OpenURL("https://www.twitter.com/thephaseofgame");
    }
    //go the the google+
    public void GooglePlus()
    {
        Application.OpenURL("https://plus.google.com/u/1/114423983730128372098");
    }
   
    // play about animation
    public void About()
    {
        anim.SetBool("About", true);
    }
    public void AboutDisable()
    {
        anim.SetBool("About", false);
    }
    //social
    public void SocialEnable()
    {
        if(!isSocial)
        {
            Social.SetBool("social", true);
            isSocial = true;
        }else
        {
            Social.SetBool("social", false);
            isSocial = false;
        }
      
      
    }
    //setting
    public void SettingEnable()
    {
        if(!isSetting)
        {
            Setting.SetBool("setting", true);
            isSetting = true;
        }else
        {
            Setting.SetBool("setting", false);
            isSetting = false;
        }
    }
     // go the home
    public void Home()
    {
        ads.Show();
        SceneManager.LoadScene("mainMenu");
        
    }
    //go the gameScene
    public void Game()
    {
        SceneManager.LoadScene("GamePlay");
    }
    //Quit Game
    public void Quit()
    {
        exitpanel.SetActive(true);
    }

    //himanshu fb
    public void himanshu()
    {
        Application.OpenURL("https://www.facebook.com/ht.himanshu.ht");
    }
    //tarun fb
    public void tarun()
    {
        Application.OpenURL("https://www.facebook.com/TarunBishtTari");
    }
    //gaurav fb
    public void Gaurav()
    {
        Application.OpenURL("https://www.facebook.com/100008714046573");
    }
    // sound Manager()
    public void Sound()
    {
        if(audio.isPlaying)
        {
            audio.Stop();
        }else
        {
            audio.Play();
        }
    }

    public void highScore()
    {
       
        hS.text = "" + PlayerPrefs.GetFloat("Score").ToString("0");
    }


    public void Webstite()
    {
        Application.OpenURL("http://thephaseofgame.wordpress.com");
    }


    //check for google play Services

  


}
