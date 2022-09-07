using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transitionBreach;
    public float transitionTime = 1f;


    private void Start()
    {
    
        FindObjectOfType<AudioManager>().PlaySound("FondoMuestra");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {

            StartCoroutine(OpenTransition());
            //transitionBreach.SetTrigger("Abrir");
            FindObjectOfType<AudioManager>().PlaySound("PortalAbierto");

        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {


            StartCoroutine(CloseTransition());
            //transitionBreach.SetTrigger("Cerrar");
            FindObjectOfType<AudioManager>().PlaySound("PortalAbierto");

        }

    }

   IEnumerator OpenTransition()
    {
        
        yield return new WaitForSeconds(transitionTime * Time.deltaTime);
        transitionBreach.SetTrigger("Abrir");
    }

    IEnumerator CloseTransition()
    {
        
        yield return new WaitForSeconds(transitionTime * Time.deltaTime);
        transitionBreach.SetTrigger("Cerrar");
    }

}
