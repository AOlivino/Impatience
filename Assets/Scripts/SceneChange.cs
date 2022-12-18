using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneChange : MonoBehaviour
{

    public string sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !other.isTrigger) {
        //GetComponent<BlackBox>().FadeIn();
        SceneManager.LoadScene(sceneToLoad); //the string above tells each instance of this which scene to load
        }
    }
        [YarnCommand("toparlor")]
        public static void SceneSwitch() {
        SceneManager.LoadScene("Parlor"); //we're just loading the parlor
        }
        
        [YarnCommand("resetgame")]
        public static void ResetGame() {
        SceneManager.LoadScene("Title Screen");
        Time.timeScale = 1f;
        }

    }

