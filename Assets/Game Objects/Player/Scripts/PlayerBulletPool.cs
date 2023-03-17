using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{

    // Zotov, A., 2020. [online] Available at: https://www.youtube.com/watch?v=Mq2zYk5tW_E&t=437s 

    // Bullet pool helps declutter the scene by providing the player
    // with a limit to how many bullets are spawned inside the scene
    // At first the bullets populate the scene and then turn off after some seconds
    // Then the game uses those bullets spawned in the scene if they are enough and sets them
    // active when needed then back to inactive.
    // Thus we are going to recycle the bullets and keep using the same ones over and over
    // as there is no point to keep creating new ones

    public static PlayerBulletPool PlayerbulletPoolInstanse;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        PlayerbulletPoolInstanse = this;
    }




    // We create a game object list where we keep the bullets
    void Start()
    {
        bullets = new List<GameObject>();
    }


    public GameObject GetBullet()
    {
        if (bullets.Count > 0) // we check if there are bullets in scene
        {
            for (int i = 0; i < bullets.Count; i++)  // for each one we return 1
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];

                }
            }
        }

        if (notEnoughBulletsInPool) // if there are not enough bullets ( we are spawning too many )
        {// then we spawn more inside the scene to use
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;

        }

        return null;
    }


}

