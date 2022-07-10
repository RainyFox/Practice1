using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
