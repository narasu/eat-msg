using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void GotoStartScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GotoPlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
