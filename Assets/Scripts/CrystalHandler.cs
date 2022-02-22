using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrystalHandler : MonoBehaviour
{
    private bool alreadyCollected;
    private Tween a, b, c;
    // Start is called before the first frame update
    void Start()
    {
        Rotate();
    }

    private void Rotate(){
        a = transform.DORotate(new Vector3(0.0f, 180f, 0.0f), 1f).SetLoops(-1, LoopType.Incremental);
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(alreadyCollected) return;
        alreadyCollected = true;

        try{
            var collectClip = Resources.Load<AudioClip>("Sounds/collect");
            FindObjectOfType<AudioSource>().PlayOneShot(collectClip);
        }
        catch(System.Exception e){
            Debug.LogException(e);
        }
        FindObjectOfType<GameManager>().CrystalGained();
        GetComponent<Collider>().enabled = false;
        StartCoroutine(Animation());
    }

    IEnumerator Animation(){
        float punchTime = 0.5f;
        float scaleTime = 0.3f;
        b = transform.DOPunchScale(Vector3.one * 1.5f, punchTime, 2, 1f);
        yield return new WaitForSeconds(punchTime);
        c = transform.DOScale(Vector3.zero, scaleTime);
        yield return new WaitForSeconds(scaleTime);
        Kill();
    }
    public void Kill(){
        a.Kill();
        b.Kill();
        c.Kill();
        Destroy(gameObject);
    }
}
