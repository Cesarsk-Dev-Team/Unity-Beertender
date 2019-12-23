using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    static MenuManager instance;

    private void Awake()
    {
        //Handling Singleton D.P.
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void MoreButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Cesarsk+Dev+Team");
    }
}