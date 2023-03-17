using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{

    // ---------------------- Explosion ----------------------

    public float explosionTimerDelay = 3; // Determines the cooldown of the explosion ability (should be bigger than explosion circle last !)
    public float explosionCircleLast = 2; // Determines how much time the explosion circle persists in the scene

    private GameObject ExplosionCircle; // Used to store the game object that represents the explosion circle
    private float explosionTimer; // Counter for the ability cooldown 
    private float timeUntillast; // Counts how much time has passed until the last use of the explosion ability. Counter for how much the circle should persist

    // ------------------------------------------------------- 


    // ---------------------- Shooting ----------------------

    public float shootingCooldown = 2; // Shooting cooldown
    public float bulletSpeed = 10; // Variable to set the bullet speed
    [SerializeField]
    private Transform bulletSpawnPoint; // Location of where the bullet should spawn
    [SerializeField]
    private GameObject bulletPrefab; // Bullet prefab to use

    private float shootingTimer; // Counter for the shooting cooldown
    private bool dir; // Stores the player direction

    // ------------------------------------------------------ 


    // ---------------------- Other ----------------------

    private GameObject player; // Store the player in a variable
    private PlayerMovementScript script; // Store the movement script for easier access to required variables
    private SpriteRenderer SpriteRenderer; // Store the SpriteRenderer component in a variable
    private bool refreshAbilities; // Checks if it's the begining of the game and will refresh the ability cooldowns on start 

    // --------------------------------------------------- 


    // ---------------------- HUD ---------------------- 
    [SerializeField]
    public TMP_Text counterTextCooldown_shoot, // Text for the shooting cooldown
                    counterTextCooldown_explode;// Text for the explosion cooldown
    [SerializeField]
    public Image shootCooldownImage,// Image for the shooting cooldown
                 explodeCooldownImage; // Image for the explosion cooldown


    private int counterHUD_shoot; // Counter to update the text from the HUD for the shooting cooldown
    private int counterHUD_explode; // Counter to update the text from the HUD for the explosion cooldown

    // ------------------------------------------------- 


    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player"); // Find and get the player
        ExplosionCircle = GameObject.FindGameObjectWithTag("ExplosionCircle"); // Find and get the explosion circle
        ExplosionCircle.SetActive(false); // Disable the explosion circle by default
        SpriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer component
        refreshAbilities = true; // Sets the check for the start of the game to true
        script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>(); // Get the movement script
        

    }

    // Update is called once per frame
    void Update()
    {
        if (refreshAbilities) // Reset the cooldowns when the game starts
        {
            shootingTimer = 10; // Resets cooldown for shooting
            timeUntillast = 10; // Resets cooldown for explosion
            explosionTimer = 10; // Resets cooldown for explosion
        }

        refreshAbilities = false; // Sets the refresh ability check to false for the rest of the game

        dir = player.GetComponent<PlayerMovementScript>().PlayerDirection(); // Store the player direction each tick for future use
        // True - the player is facing right
        // False - the player is facing left

        // Begin counting
        timeUntillast += Time.deltaTime; // explosion cooldown
        explosionTimer += Time.deltaTime; // explosion cooldown
        shootingTimer += Time.deltaTime; // shooting cooldown


        if (Input.GetKey(KeyCode.Q)) // Shooting
        {
            if (shootingTimer > shootingCooldown) // Check if the player can shoot
            {
                shootingTimer = 0; // Reset the shooting timer to count the cooldown
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Spawn the bullet
                

                if (dir == true) // If the player is facing right
                { bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed; // Direct the bullet twoards the direction the player is facing in this case right
                   
                }
                else
                { bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.right * bulletSpeed; // Direct the bullet twoards the direction the player is facing in this case left

                }
                AudioManager.playFireSound();
            }
        }

        // Begin the cooldown HUD logic for shooting
        counterHUD_shoot =(int)shootingCooldown - (int)shootingTimer; // Store the time in a simple int that is easy to read
        if (counterHUD_shoot < 0.7f) // We check 0.7 instead of a variable as this is a sweet spot that allows the timer to be hidden right before the player can shoot again. This is a personal preference.
        { counterTextCooldown_shoot.alpha = 0f; // We hide the HUD text if the value is less then 0.7
            shootCooldownImage.gameObject.SetActive(false); // We hide the image representing shooting
        }
        if (counterHUD_shoot > 0) // If the cooldown count has started we show the cooldown HUD
        {
            counterTextCooldown_shoot.alpha = 1f; // We show the HUD text
            counterTextCooldown_shoot.text = "Shooting: " + counterHUD_shoot.ToString(); // We update the text with the according timer
            shootCooldownImage.gameObject.SetActive(true); // We show the image representing shooting 
        } 

        if (Input.GetKey(KeyCode.F)) // exploding
            if(explosionTimer > explosionTimerDelay) // We check if the ability is on cooldown
        {
                timeUntillast = 0; // We reset the timer for when the last explosion hapened
                explosionTimer = 0; // We reset the cooldown
                ExplosionCircle.SetActive(true); // We activate the explosion circle to check for enemy collisions
                AudioManager.playExplosion();
        }

        if (timeUntillast >= explosionCircleLast) // We check when the last explosion happened and we compare it to how much the explosion should last
        {
            ExplosionCircle.SetActive(false); // If the explosion circle has lasted as long as explosionCircleLast determines we deactivate them
        }

        // Begin the cooldown HUD logic for explosion
        counterHUD_explode = (int)explosionTimerDelay - (int)explosionTimer; // Store the time in a simple int that is easy to read
        if (counterHUD_explode < 0.8) // Same as shooting but now the 0.8 seems to be the sweet spot
        { counterTextCooldown_explode.alpha = 0f; // We hide the HUD text if the value is less then 0.7
            explodeCooldownImage.gameObject.SetActive(false); // We hide the image representing exploding
        }
        if (counterHUD_explode > 0) // If the cooldown count has started we show the cooldown HUD
        {
            counterTextCooldown_explode.alpha = 1f; // We show the HUD text
            explodeCooldownImage.gameObject.SetActive(true); // We update the text with the according timer
            counterTextCooldown_explode.text = "Explosion: " + counterHUD_explode.ToString(); // We show the image representing exploding 

        }

        if (Input.GetKey(KeyCode.R)) // Reset the player to the last checkpoint
            player.GetComponent<PlayerMovementScript>().resetToCheckpointNoCount();
    }
    public void PowerUp() // Power Up function. When player picks up the Power Up item the cooldowns are reduced as followss:
    {
        shootingCooldown = 0.5f; // We set the shooting cooldown to 0.5 sec
        explosionTimerDelay = 1f; // We set the explosion cooldown to 1 sec
        SpriteRenderer.color = new Color32(255, 50, 50, 255); // We modify the player color in oreder to make it visible that the power up is active
        script.dashingCooldown = 0.2f; // We reduce the dashing cooldown
    }


}