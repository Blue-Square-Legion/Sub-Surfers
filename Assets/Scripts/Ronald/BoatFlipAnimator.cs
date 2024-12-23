using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFlipAnimator : MonoBehaviour
{
    public int maxPlays;

    private Animator animator;
    private int playCount = 0;
    public bool flipReady = false;

    private GameObject shakeTrigger;
    private GameObject boatFlipRightTrigger;
    private GameObject boatFlipLeftTrigger;

    // Start is called before the first frame update
    void Awake()
    {
        animator = transform.GetComponent<Animator>();
        // Find child triggers by name
        shakeTrigger = transform.Find("ShakeTrigger")?.gameObject;
        boatFlipRightTrigger = transform.Find("BoatFlipTriggerRight")?.gameObject;
        boatFlipLeftTrigger = transform.Find("BoatFlipTriggerLeft")?.gameObject;

        // Log to ensure the triggers are correctly found
        if (shakeTrigger != null) Debug.Log("Found ShakeTrigger.");
        if (boatFlipRightTrigger != null) Debug.Log("Found BoatFlipTriggerRight.");
        if (boatFlipLeftTrigger != null) Debug.Log("Found BoatFlipTriggerLeft.");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        //Debug.Log($"Triggered by: {other.gameObject.name} (Tag: {other.tag})");

        // Check which trigger this script is attached to
        if (other.gameObject.name == ("Player") && shakeTrigger && !flipReady)
        {

            //Debug.Log("ShakeTrigger activated by Player."); 
            StartCoroutine(ShakeBoat());
        }

        //flip boat to right
        else if (other.gameObject.name == ("Player") && boatFlipRightTrigger && flipReady)
        {
            Debug.Log("Flip Right");
            animator.SetTrigger("flipRight");
        }

        //flip boat to left
        else if (other.gameObject.name == ("Player") && boatFlipLeftTrigger && flipReady)
        {
            Debug.Log("Flip Left");
            animator.SetTrigger("flipLeft");
        }
        else
        {
            Debug.Log("No valid trigger hit.");
        }
    }

    //shake the boat if the player runs into the shake trigger
    private IEnumerator ShakeBoat()
    {
       
        for (int i = playCount; i < maxPlays; i++)
        {
            animator.SetTrigger("Shake");
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            float animationLength = stateInfo.length;
            yield return new WaitForSeconds(animationLength);
            Debug.Log("Played " + i + " times");
        }
        flipReady = true;

    }
}
