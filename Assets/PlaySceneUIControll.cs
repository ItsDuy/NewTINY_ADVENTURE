using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaySceneUIControll : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Canvas mainMenuCanvas;
    public Canvas PauseCanvas;
    public void OnClickPause()
    {
      
        Time.timeScale = 0; // Pause the game
        
    }
}
