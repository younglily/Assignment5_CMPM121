using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Move : MonoBehaviour
{
    private float speed;
    private CharacterController character;
    private int snowballsCollected;
    private bool hasKey;
    public Text totalSnowballs;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        character = GetComponent<CharacterController>();
        snowballsCollected = 0;
        totalSnowballs.text = "";
        anim = GetComponent<Animator>();

        hasKey = false;
    }

    //reset total score
    void totalSnowballsCollected()
    {
        totalSnowballs.text = "You've merged with " + snowballsCollected.ToString() + " snowballs!";
    }

    //collecting snowballs
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Merge"))
        {
            other.gameObject.SetActive(false);
            snowballsCollected += 1;
            totalSnowballsCollected();

            //gets bigger
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            GetComponent<ParticleSystem>().Play();
        }

        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            GetComponent<ParticleSystem>().Play();

            //open the door
            hasKey = true;
        }

        if (other.gameObject.CompareTag("Door"))
        {
            if (hasKey == true)
            {
                //opendoor 
                other.gameObject.transform.position = transform.position + new Vector3(10,0,0);
            } 
        }

        if (other.gameObject.CompareTag("Stage2"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
    
        character.Move(movement);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (null != anim)
            {
                anim.Play("Walking");
            }
        }
    }

 
}
