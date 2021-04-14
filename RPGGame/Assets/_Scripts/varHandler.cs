using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class varHandler : MonoBehaviour
{
    public static int r1points;
    public static int r2points;
    public static bool ratKing;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        r1points = 0;
        r2points = 0;
        ratKing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(playerController.ratKing) {
            ratKing = playerController.ratKing;
        }

        if(scene.name == "Tutorial") {
            r1points = playerController.points + playerAttack.points;
        }

        if(scene.name == "Castle") {
            r2points = playerController.points + playerAttack.points;
        }
    }
}
