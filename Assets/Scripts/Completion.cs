using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Completion : MonoBehaviour
{
    private bool isGameOver = false;
    private bool isOnKey = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Return)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        CheckForRaycastHit();
    }

    void CheckForRaycastHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            if (hit.collider.CompareTag("key"))
            {
                isOnKey = true;
                if (Input.GetKey(KeyCode.E))
                {
                    isGameOver = true;
                }

            }
            else { isOnKey = false; }

        }
    }
    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 150, 140, 50), "Find the key");


        if (isOnKey)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Press E");
        }
     

        if (isGameOver)
        {
            Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 280, 50);
            if (GUI.Button(startButton, "You escaped! Press enter to restart."))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}