using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public Text time;
    public float timeleft = 20f;
    public santaDead dead;
    public Text ScoreText;
    public Text DeadText;
    private float scoreCounter;
    private SantaMove move;
    public Slider timerslider;
    public Image DamageImage;
    public Text HS;
    public GameObject timerpanel;

    void Start()
    {
       
        if(timerpanel==null)
        {
            return;
        }else
        {
            timerpanel.SetActive(false);
        }
     

        DamageImage.enabled = false;
        move = FindObjectOfType<SantaMove>();
        timeleft = 20f;
        //time.text = timeleft.ToString("0");
        scoreCounter = 0;
        ScoreText.text = "Score:- "+scoreCounter.ToString("0");
    }


    void Update()
    {

        if(dead.isDead==true)
        {
            highScore();
        }
        if(dead.isDead==false)
        {
            scoreCounter += Time.deltaTime;
            ScoreText.text ="Score:- "+ scoreCounter.ToString("0");
            timeleft -= Time.deltaTime;
            timerslider.value = timeleft*5;
            //time.text = timeleft.ToString("0");
            DeadText.text = "Your Score is:- " +scoreCounter.ToString("0");

            if(timerslider.value <=19)
            {
                timerpanel.SetActive(true);
            }

            if(timerslider.value>=22)
            {
                timerpanel.SetActive(false);
            }
            if (timerslider.value <= 0)
            {
               
               // timeleft = 0;
                dead.isDead = true;
                move.enabled = false;
                dead.OnDead();

                
            }
        }
       
    }

    public void TimerIncrease()
    {
        timeleft = timeleft + 3;
        DamageImage.enabled = false;
    }

    public void ScoreIncrease(int power)
    {
       
        scoreCounter = scoreCounter+power;
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Pause()
    {

        if(Time.timeScale==1)
        {
            Time.timeScale = 0.001f;
        }else
        {
            Time.timeScale = 1f;
        }
       
      
    }

    public void highScore()
    {
        if(PlayerPrefs.GetFloat("Score")<scoreCounter)
        {
           PlayerPrefs.SetFloat("Score", scoreCounter);
        }
        HS.text = "HIghscore:- "+PlayerPrefs.GetFloat("Score").ToString("0");
    }
   
}
