using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void ConfirmClick(int num)
    {
        if (num == 1)
        {
            sceneName = "Level1";
        }
        else if (num == 2)
        {
            sceneName = "Level2";
        }
        else if (num == 3)
        {
            sceneName = "Level3";
        }
        else if (num == 4)
        {
            sceneName= "Level4";
        }
        else if (num == 5)
        {
            sceneName = "Level5";
        }
        else if (num == 6)
        {
            sceneName = "Level6";
        }
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
