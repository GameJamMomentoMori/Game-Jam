using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public AudioSource click;

    public AudioSource intro;
    public AudioSource outro;

    void Start()
    {
        if(cutscene == 1){
            sentences[0] = "Hey! You're up!";
            sentences[1] = "You fell pretty hard over there. I saw the whole thing! I'm just glad I was here to help you out.";
            sentences[2] = "Anyways, there's no easy way out of this place. If you want to make it back to the surface, you'd better get going!";
            sentences[3] = "...Oh! And take this bag. It can only carry 3 things, but I'm sure it'll be useful!";
        }
        if(cutscene == 1){
            sentences = new string[3];
            sentences[0] = "You're getting better! Maybe try putting different stuff in that bag?";
            sentences[1] = "Don't worry though. I'll always be around to rescue you!";
        }
        if(cutscene == 1){
            sentences = new string[3];
            sentences[0] = "You know... if you're ever down on health, try throwing a coin into that fountain.";
            sentences[1] = "I'm sure you'll feel a lot better!";
        }
        if(cutscene == 1){
            sentences = new string[3];
            sentences[0] = "Did you meet the red things?";
            sentences[1] = "They don't move, but those weird orbs pack a serious punch!";
        }
        if(cutscene == 1){
            sentences = new string[4];
             sentences[0] = "...";
            sentences[1] = "You don't talk much, do you?";
            sentences[2] = "I'm just glad I know how to patch you up. You're good as new!";
        }
        if(cutscene == 1){
            sentences = new string[3];
            sentences[0] = "You know, if you ignore all the weird creatures that try and kill you...";
            sentences[1] = "It's actually pretty nice out there!";
        }
        if(cutscene == 1){
            sentences = new string[2];
            sentences[0] = "I've got no clue what those dumb coins do. No where seems to accept them!";
        }
        if(cutscene == 1){
            sentences = new string[2];
            sentences[0] = "Practice makes perfect!";
            sentences[1] = "You don't even want to THINK about what my first trip to the surface looked like...";
        }
        if(cutscene == 1){
            sentences = new string[3];
            sentences[0] = "I sincerely dislike those stationary blue baffoons.";
            sentences[1] = "I'm sure you've encountered them, no?";
        }
        if(cutscene == 1){
            sentences = new string[2];
            sentences[0] = "You're almost there... I can just feel it!";
        }
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index]){
                sentenceComplete = true;
                index++;
            }

        if(sentenceComplete){
            if(Input.GetKeyDown("e")){
                
                sentenceComplete = false;
                dialogBox.SetActive(true);
                dialogText.SetActive(true);
                NextSentence();
            }
        }
    }

    public void NextSentence(){
        if(index < sentences.Length-1){
                textDisplay.text = "";
                StartCoroutine(Type());
            }
            else{
                StartCoroutine(EndDialog());
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
    IEnumerator Type(){
        foreach (char letter in sentences[index].ToCharArray()){ 
            textDisplay.text += letter;
            //click.Play();
            yield return new WaitForSeconds(typingSpeed[index]);
        }

    }
}
