using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] AudioSource soundPlayer;
    [SerializeField] GameObject currentPoV;

    // Use this for initialization
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Move(currentPoV);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip sfx)
    {
        soundPlayer.clip = sfx;
        soundPlayer.Play();
    }

    public void Move(GameObject targetPoV)
    {
        foreach (Transform child in currentPoV.transform)
        {
            InteractableController interactable = child.GetComponent<InteractableController>();
            if (interactable)
                interactable.ResetObjectsActivation();
        }

        currentPoV = targetPoV;
        Vector3 targetPosition = currentPoV.transform.position + new Vector3(0f, 0f, -10f);
        Camera.main.transform.position = targetPosition;
    }
}
