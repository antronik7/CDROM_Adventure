using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    [SerializeField] bool playSFX = false;
    [SerializeField] AudioClip sfx;
    [SerializeField] bool activateObjects = false;
    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] GameObject[] objectsToDeactivate;

    private AudioSource soundPlayer;

    private void Awake()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (playSFX)
            GameManager.instance.PlaySFX(sfx);

        if (activateObjects)
            ActivateObjects();
    }

    void ActivateObjects()
    {
        foreach (GameObject item in objectsToActivate)
            item.SetActive(true);

        foreach (GameObject item in objectsToDeactivate)
            item.SetActive(false);
    }

    public void ResetObjectsActivation()
    {
        foreach (GameObject item in objectsToActivate)
            item.SetActive(false);

        foreach (GameObject item in objectsToDeactivate)
            item.SetActive(true);
    }
}
