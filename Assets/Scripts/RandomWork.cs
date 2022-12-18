using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RandomWork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [YarnFunction("randomizemakeup1")]
    public static string Randomizer()
    {
    string[] color1 = new string[] {"blue", "gold", "purple", "green", "red", "dark", "flesh-colored", "shimmering"}; //defines items in array
     int index = Random.Range(0, color1.Length - 1); //random.range is what chooses it randomly. 0 is defined at the start, 
     string Choosecolor = color1[index]; //= will make makeup equivalant to index, defined above as random
     return Choosecolor;
    }

    [YarnFunction("randomizemakeup2")]
    public static string Randomizer2()
    {
    string[] makeup1 = new string[] {"eyeliner", "eyeshadow", "lipstick", "lipgloss", "blush", "mascara", "blush"}; //defines items in array
     int index = Random.Range(0, makeup1.Length - 1); //random.range is what chooses it randomly. 0 is defined at the start, 
     string Choosemakeup = makeup1[index]; //= will make makeup equivalant to index, defined above as random
     return Choosemakeup;
    }

    [YarnFunction("randomizemakeup3")]
    public static string Randomizer3()
    {
    string[] personality = new string[] {"very impatient", "very ugly", "sour", "very arrogant", "pushy", "racist", "very angry", "bitter", "conceited", "pompous", "self-important"}; //defines items in array
     int index = Random.Range(0, personality.Length - 1); //random.range is what chooses it randomly. 0 is defined at the start, 
     string Choosetrait = personality[index]; //= will make makeup equivalant to index, defined above as random
     return Choosetrait;
    }

        [YarnFunction("randomizemakeup4")]
    public static string Randomizer4()
    {
    string[] talking = new string[] {"Not bad... for a half-breed.", "Terrible. Is this how half-elves do makeup?", "Can't believe they allow half-breeds to work here.", "You're lucky I'd allow your filthy hands to touch my beautiful face.", "Passable. But I bet your human co-workers would do a better job.", "That'll be enough, half-breed.", "To think they'd allow your kind to work here.", "Awful.", "A half-elf as a makeup artist? How quaint."}; //defines items in array
     int index = Random.Range(0, talking.Length - 1); //random.range is what chooses it randomly. 0 is defined at the start, 
     string Choosecomment = talking[index]; //= will make makeup equivalant to index, defined above as random
     return Choosecomment;
    }

}
