using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public int cutscene;
    public GameObject dialogBox;
    public GameObject dialogText;
    public string[] sentences;
    [SerializeField] private int index;
    [SerializeField] private float[] typingSpeed;
    [SerializeField] private bool sentenceComplete = true;
    [SerializeField] private bool dialog;
    [SerializeField] private bool interactRange;
    public float interactTopBounds;
    public float interactBottomBounds;
    public float interactLeftBounds;
    public float interactRightBounds;
    public TextMeshProUGUI textDisplay;
    public Animator animator_dialogText;
    public Animator animator_dialogBox;
    public Animator pp;
    public Animator dp;
    public Animator op;
    public GameObject black;

    public GameObject background;

    public AudioSource line1;
    public AudioSource line2;
    public AudioSource line3;
    public AudioSource line4;
    public AudioSource line5;
    public AudioSource line6;
    public AudioSource line7;
    public AudioSource line8;
    public AudioSource line9;
    public AudioSource line10;
    public AudioSource line11;
    public AudioSource line12;
    public AudioSource line13;
    public AudioSource line14;
    public AudioSource line15;
    public AudioSource line16;
    public AudioSource line17;
    public AudioSource line18;

    public bool dialogDone = false;

    public AudioSource click;

    public AudioSource intro;
    public AudioSource outro;

    void Start()
    {
       
        if(cutscene == 1){
            sentences = new string[8];
            sentences[0] = "Hold, adventurer!  What business have you in the Lord Araphel’s castle?";
            sentences[1] = "Well if you need to know, old-timer, I am on my way to conscript his aid. Because of all my traveling, I've caught some disease not a single doctor could get rid of.  I figured this Araphel character might be able to cure what ails me with one of his potions.";
            sentences[2] = "You ought to know, traveler, that Araphel is not a kind man known for charity.  His abode is ripe with all manner of foul beasts and ghouls.  Nary a single warrior has emerged from the castle alive, and quite honestly, I doubt you will be the first.  I would recommend you turn away now.  Go home and greet Death with open arms in peace.";
            sentences[3] = "Death?  Look at me old man!  I am the most capable fighter this rotten hamlet has ever seen!  There is not a scratch upon my armor nor a scar on my face.  Death has not so much as whispered my name aloud, let alone get anywhere near me!  Hell, if I saw Death, I would cut him down where he stood, the same as any other cur!";
            sentences[4] = "With enthusiasm such as that, you will meet your end soon enough.  I will pray the beast that makes your end has the decency to do so quickly and cleanly.";
            sentences[5] = "Save your prayers, old man.  I may just liberate this rat pit from its bastard of a lord.";
            sentences[6] = "Poor, poor traveler...";
            sentences[7] = " ";
        }

        if(cutscene == 3){
            sentences = new string[11];
            sentences[0] = "That should be… the last of them… Had me worried for a bit there… now to find Araphel...";
            sentences[1] = "Well done traveler.  I suppose I misjudged you in a few places.";
            sentences[2] = "Old timer?  What are you doing here? Do you work for Araphel?";
            sentences[3] = "I have come to collect.  I congratulate you on your victory over Araphel’s forces, young heroine.  Even still, you should have listened to me before.  Now it is too late to greet me with open arms.";
            sentences[4] = "Greet you?  What are you talking about?";
            sentences[5] = "Come with me, young heroine.  You must accept what has come to pass.";
            sentences[6] = "There is still time!  I just have to find the cure!  It has to be here among Araphel’s tonics…";
            sentences[7] = "My afflictions have no cure.  Join me in the abyss.  There is no escape.";
            sentences[8] = "I’ll not go quietly!  I’ve avoided you for this long.  If you want my life, you’ll have to take it!";
            sentences[9] = "So be it. ";
            sentences[10] = " ";
        }
        StartCoroutine(BoxIn());
        Player = GameObject.Find("FirstPersonPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index]){
                sentenceComplete = true;
                index++;
            }

        if(sentenceComplete){
            if(Input.GetKeyDown(KeyCode.Return)){
                sentenceComplete = false;
                NextSentence();

                if(cutscene == 1 && index == 1){
                    line2.Play();
                    pp.Play("PortraitIn");
                    op.Play("PortraitOut");
                }
                if(cutscene == 1 && index == 2){
                    line3.Play();
                    op.Play("PortraitIn");
                    pp.Play("PortraitOut");
                }
               if(cutscene == 1 && index == 3){
                   line4.Play();
                    pp.Play("PortraitIn");
                    op.Play("PortraitOut");
                }
                if(cutscene == 1 && index == 4){
                    line5.Play();
                    op.Play("PortraitIn");
                    pp.Play("PortraitOut");
                }
                if(cutscene == 1 && index == 5){
                    line6.Play();
                    pp.Play("PortraitIn");
                    op.Play("PortraitOut");
                }
                if(cutscene == 1 && index == 6){
                    line7.Play();
                    op.Play("PortraitIn");
                    pp.Play("PortraitOut");
                }
                if(cutscene == 1 && index == 7){
                    StartCoroutine(BoxOut());
                }



               if(cutscene == 3 && index == 1){
                    line9.Play();
                    pp.Play("PortraitOut");
                    op.Play("PortraitFullIn");
                }
                if(cutscene == 3 && index == 2){
                    line10.Play();
                    op.Play("PortraitOut");
                    pp.Play("PortraitIn");
                }
                if(cutscene == 3 && index == 3){
                    line11.Play();
                    pp.Play("PortraitOut");
                    op.Play("PortraitIn");
                }
                if(cutscene == 3 && index == 4){
                    line12.Play();
                    pp.Play("PortraitIn");
                    op.Play("PortraitOut");
                }
                if(cutscene == 3 && index == 5){
                    line13.Play();
                    op.Play("PortaitHalfOut");
                    dp.Play("PortraitFullIn");
                    pp.Play("PortraitOut");
                }
                if(cutscene == 3 && index == 6){
                    line14.Play();
                    dp.Play("PortraitOut");
                    pp.Play("PortraitIn");
                }
                if(cutscene == 3 && index == 7){
                    line15.Play();
                    dp.Play("PortraitIn");
                    pp.Play("PortraitOut");
                }
                if(cutscene == 3 && index == 8){
                    line16.Play();
                    dp.Play("PortraitOut");
                    pp.Play("PortraitIn");
                }
                if(cutscene == 3 && index == 9){
                    line17.Play();
                    dp.Play("PortraitIn");
                    pp.Play("PortraitOut");
                    StartCoroutine(EndGame());
                }
            }
        }
    }

    public void NextSentence(){
        if(index < sentences.Length-1){
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else{
                StartCoroutine(BoxOut());
                textDisplay.text = "";
            }
    }

    IEnumerator EndDialog(){
        //outro.Play();
        index = 0;
        sentenceComplete = true;
        animator_dialogBox.Play("out");
        animator_dialogText.Play("out");
        yield return new WaitForSeconds(0.2f);
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
    }

    IEnumerator BoxIn(){
        //Time.timeScale = 0f;
        yield return new WaitForSeconds(1f);
        animator_dialogBox.Play("SlideIn");
        animator_dialogText.Play("SlideIn");
        yield return new WaitForSeconds(1.5f);
        if(cutscene == 1){
            op.Play("PortraitHalf");
            pp.Play("PortraitHalf");
        }
        if(cutscene == 3){
            pp.Play("PortraitFullIn");
        }
        yield return new WaitForSeconds(1.2f);
        if(cutscene == 1)
        op.Play("PortraitIn");

         sentenceComplete = false;
         if(cutscene == 1)
         line1.Play();

         if(cutscene == 3)
         line8.Play();
                NextSentence();

    }

     IEnumerator BoxOut(){
         cutscene = 2;
        //Time.timeScale = 0f;
        op.Play("PortaitHalfOut");
        pp.Play("PortaitHalfOut");
        yield return new WaitForSeconds(1f);
        animator_dialogBox.Play("SlideOut");
        animator_dialogText.Play("SlideOut");
        black.SetActive(true);
        yield return new WaitForSeconds(1f);
        background.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        //black.Play("FadeOut");
        dialogDone = true;
        
    }

    IEnumerator EndGame(){
        yield return new WaitForSeconds(2f);
        black.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    IEnumerator Type(){
        foreach (char letter in sentences[index].ToCharArray()){ 
            textDisplay.text += letter;
            //click.Play();
            yield return new WaitForSeconds(typingSpeed[index]);
        }

    }
}
