using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonTween : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool clickAnimation = false;
    public float tweenTime = 0.15f;
    public float scaleSize = 1.1f;
    public Vector3 defaultSize;
    public Vector3 defaultPosition;
    public Vector3 pointPos;

    public bool buttonAnimation = false;
    public bool backgroundAnimation = false;
    public bool headerAnimation = false;
    public bool gradientAnimation = false;
    public bool indicatorAnimation = false;
    public bool helpAnimation = false;
    bool onceStart = true;

    public void Start() {
        if (buttonAnimation)
        {
            StartCoroutine(StartButtonAnimation());
        }
        if (backgroundAnimation)
        {
            LeanTween.scale(this.gameObject,new Vector3(1.2f,1.2f,1.2f), 15f).setEaseInOutSine().setLoopPingPong();
        }
        if (headerAnimation)
        {
            StartHeaderAnimation();
        }
        if (gradientAnimation)
        {
            LeanTween.scale(this.gameObject, new Vector3(1.5f,1.5f,1.5f), 8f).setEaseInOutQuart().setLoopPingPong();
            LeanTween.rotateAround(this.gameObject, new Vector3(0,0,1), 360f, 10f).setLoopPingPong();
        }
    }

    IEnumerator Kokot(Vector3 defaultPosition)
    {
        bool once = true;
        while (true)
        {
            if (once)
            {
                yield return new WaitForSeconds(0.4f); 
                once = !once;
            }
            yield return new WaitForSeconds(0.1f); 
            LeanTween.moveLocalY(this.gameObject, defaultPosition.y + 40, .9f).setEaseOutCubic();
            yield return new WaitForSeconds(0.9f); 
            LeanTween.moveLocalY(this.gameObject, defaultPosition.y, 0f);
        }
    }

    private void OnEnable() {
        if (indicatorAnimation)
        {
            LeanTween.rotateAround(this.gameObject, new Vector3(0,0,1), 360, 2).setEaseInOutBack().setLoopPingPong();
        }
        if (helpAnimation)
        {
            if (this.gameObject.name == "Point")
            {
                this.transform.localPosition = pointPos;
                Vector3 defaultPosition = this.transform.localPosition;
                StartCoroutine(Kokot(defaultPosition));
            }
            else
            {
                StartCoroutine(HelpAnimation());
            }
        }
        if (buttonAnimation)
        {
            StartCoroutine(IdleButton());

        }
    }

    IEnumerator HelpAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 newSize = defaultSize - new Vector3(0.2f, 0.2f, 0.2f);
        Vector3 defaultPosition = this.transform.localPosition;
        if (this.gameObject.name == "Ball")
        {
            LeanTween.scale(this.gameObject, newSize, 0.5f).setLoopPingPong().setEaseOutCubic().setDelay(0.25f);
            LeanTween.scale(this.gameObject, defaultSize, 0.5f).setDelay(0.75f).setEaseOutCubic().setLoopPingPong();
        }
        if (this.gameObject.name == "Hand")
        {
            LeanTween.moveLocalY(this.gameObject, defaultPosition.y - 5, 0.5f).setEaseInCubic().setLoopPingPong();
        }
    }

    IEnumerator IdleButton()
    {
        if (onceStart)
        {
            yield return new WaitForSeconds(2.5f);
            onceStart = !onceStart;
        }
        
        int i = 0;
        int ringsAmount = this.transform.childCount;
        int spin = 360;
        float spinTime = 8f;
        foreach (Transform ring in this.gameObject.transform)
        {
            i++;
            if (i != ringsAmount)
            {
                LeanTween.rotateAroundLocal(ring.gameObject, new Vector3(0, 0, 1), spin, spinTime).setEaseInOutSine().setLoopPingPong();
            }
            if (i % 2 == 1)
            {
                spin = -60;
            }
            else
            {
                spin = 60;
            }
        }
    }

    private void OnDisable() {
        StopCoroutine(Kokot(defaultPosition));
    }

    void StartHeaderAnimation()
    {
        Vector3 defaultPosition = this.transform.localPosition;
        this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+380, transform.position.z);
        LeanTween.moveLocalY(this.gameObject, defaultPosition.y, 2f).setEaseInOutBack().setDelay(0.1f);
    }

    IEnumerator StartButtonAnimation()
    {
        GetComponent<Button>().interactable = false;
        Vector3 thisSize = this.transform.localScale;
        this.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 1);
        LeanTween.scale(this.gameObject,thisSize,1f).setEaseInOutElastic();
        yield return new WaitForSeconds(0.6f);
        int ringsAmount = this.transform.childCount;
        int spin = -240;
        float spinTime = 1.0f;
        int i = 0;
        foreach (Transform ring in this.gameObject.transform)
        {
            i++;
            if (i != ringsAmount)
            {
                LeanTween.rotateAroundLocal(ring.gameObject, new Vector3(0, 0, 1), spin, spinTime).setEaseInOutCubic();
                spinTime += 0.5f;
            }
            if (i % 2 == 1)
            {
                spin = -480;
            }
            else
            {
                spin = 480;
            }
        }
        yield return new WaitForSeconds(1.9f);
        GetComponent<Button>().interactable = true;
    }

    public void OnPointerDown(PointerEventData data)
    {
        Tween();
    }
 
    public void OnPointerUp(PointerEventData data)
    {
        this.gameObject.transform.localScale = defaultSize;
    }

    private void Awake() {
        LeanTween.reset();
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Time.timeScale = 1;
        }
        defaultSize = this.gameObject.transform.localScale;
    }

    public void Tween()
    {
        //LeanTween.cancel(gameObject);

        transform.localScale = defaultSize;

        LeanTween.scale(gameObject, defaultSize * scaleSize, tweenTime).setEaseInCubic();
        
    }
}
