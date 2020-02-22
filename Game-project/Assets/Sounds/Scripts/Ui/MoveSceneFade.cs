using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneFadeButton : MonoBehaviour
{

    public Animator animator;
    public int movedScene;
    private int sceneToload;
    // Update is called once per frame
    public void ButtonMoveScene(string sceneName) {
        FadeToScene(movedScene);
    }

    public void FadeToScene(int sceneName) {
        sceneToload = sceneName;
        animator.SetTrigger("FadeOut");
    }
    public void onFadeComplete() {
        SceneManager.LoadScene(sceneToload);
    }
}
