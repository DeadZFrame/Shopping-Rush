using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    LayerScript layerScript;
    ObjectSpawner @object;
    NextLevelUI uI;
    LevelLoader level;

    private RaycastHit hit;

    public float speed;
    public float smoothSpeed = 0.125f;
    public float delayTime = 1f;

    private Transform temp; //swipe için temporary deðer
    public GameObject cube;

    private bool touching = false;
    private bool toLeft, toRight, leftToCenter, rightToCenter = false;
    private bool left = false, right = false, center = false;


    private Vector2 startpos, direction; //Touch kontrol için dokunma baþlangýcý ve bitiþ deðerleri
    private float touchDirection;

    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    
    private void Start()
    {
        temp = layerScript.center;
    }

    private void Awake()
    {
        layerScript = GameObject.Find("Layers").GetComponent<LayerScript>();
        @object = GameObject.Find("Item Assets").GetComponent<ObjectSpawner>();
        uI = GameObject.Find("LevelManager").GetComponent<NextLevelUI>();
        level = GameObject.Find("LevelManager").GetComponent<LevelLoader>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        if (!uI.levelStart.activeInHierarchy)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
        TouchControls();
        //RayCast();
    }

    private void FixedUpdate()
    {
        Swipe();
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }

        if (other.name.Equals("Finish"))
        {
            FindObjectOfType<AudioManager>().Play("kaching");
            level.sceneIndex++;
            uI.LevelEnd.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.tag.Equals("Stand"))
        {
            for(float i = 0; i < 1.2f; i += 0.3f)
            {
                StartCoroutine(DelayAlphaChange(i));
            }
            
        }
        if(other.tag.Equals("item") && level.sceneIndex==0)
        {
            other.gameObject.SetActive(false);
        }
    }

    public void TouchControls()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startpos = touch.position;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startpos;
                    touchDirection = direction.x;
                    if (touchDirection < -50f && temp == layerScript.center && !touching && !leftToCenter && !rightToCenter && !toLeft && !toRight)
                    {
                        touching = true;
                        toLeft = true;
                    }
                    else if (touchDirection > 50f && temp == layerScript.center && !touching && !leftToCenter && !rightToCenter && !toLeft && !toRight)
                    {
                        touching = true;
                        toRight = true;
                    }
                    else if(touchDirection < -50f && temp == layerScript.rightLayer && !touching && !leftToCenter && !rightToCenter && !toLeft && !toRight)
                    {
                        touching = true;
                        rightToCenter = true;
                    }
                    else if(touchDirection > 50f && temp == layerScript.leftLayer && !touching && !leftToCenter && !rightToCenter && !toLeft && !toRight)
                    {
                        touching = true;
                        leftToCenter = true;
                    }
                    break;

                case TouchPhase.Ended:
                    touching = false;
                    break;
            }
        }
    }

    public void Swipe()
    {
        Vector3 cartPosition = transform.position;

        Vector3 smoothToLeft = Vector3.Lerp(cartPosition, layerScript.leftLayer.position, smoothSpeed);
        Vector3 smoothToRight = Vector3.Lerp(cartPosition, layerScript.rightLayer.position, smoothSpeed);
        Vector3 smoothToCenter = Vector3.Lerp(cartPosition, layerScript.center.position, smoothSpeed);

        if (toLeft)
        {
            temp = layerScript.leftLayer;
            StartCoroutine(DelayStatementExit(delayTime));
            toLeft = false;
            left = true;
            center = false;
        }
        else if (toRight)
        {
            temp = layerScript.rightLayer;
            StartCoroutine(DelayStatementExit(delayTime));
            toRight = false;
            right = true;
            center = false;
        }
        else if (rightToCenter)
        {
            temp = layerScript.center;
            StartCoroutine(DelayStatementExit(delayTime));
            rightToCenter = false;
            center = true;
            left = false; right = false;
        }
        else if (leftToCenter)
        {
            temp = layerScript.center;
            StartCoroutine(DelayStatementExit(delayTime));
            leftToCenter = false;
            center = true;
            left = false; right = false;
        }

        if(left)
            transform.position = smoothToLeft;
        if(right)
            transform.position = smoothToRight;
        if(center)
            transform.position = smoothToCenter;
    }

    public void RayCast()
    {
        var ray = new Ray(transform.position, transform.forward*190);
        Physics.Raycast(ray);
        Debug.DrawRay(transform.position, transform.forward * 190, Color.green);
        if (Physics.Raycast(ray, out hit, 200))
        {
            @object.spawned = false;
            if (!@object._fixed)
                @object.IntersectFix();
            StartCoroutine(@object.DelayAction(0.2f));
        }
    }

    IEnumerator DelayStatementExit(float time)
    {
        yield return new WaitForSeconds(time);
        if (right)
            right = false;
        if (left)
            left = false;
        if (center)
            center = false;
    }

    IEnumerator DelayAlphaChange(float time)
    {
        yield return new WaitForSeconds(time);
        if(!cube.activeInHierarchy)
        {
            cube.SetActive(true);
        }
        else
        {
            cube.SetActive(false);
        }
    }
}
