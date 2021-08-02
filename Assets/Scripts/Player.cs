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

    private bool touching = false;
    private bool toLeft, toRight, leftToCenter, rightToCenter = false;


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
            level.sceneIndex++;
            uI.LevelEnd.SetActive(true);
            Time.timeScale = 0;
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
            transform.position = smoothToLeft;
            temp = layerScript.leftLayer;
            StartCoroutine(DelayStatementExit(delayTime));
        }
        else if (toRight)
        {
            transform.position = smoothToRight;
            temp = layerScript.rightLayer;
            StartCoroutine(DelayStatementExit(delayTime));
        }
        else if (rightToCenter)
        {
            transform.position = smoothToCenter;
            temp = layerScript.center;
            StartCoroutine(DelayStatementExit(delayTime));
        }
        else if (leftToCenter)
        {
            transform.position = smoothToCenter;
            temp = layerScript.center;
            StartCoroutine(DelayStatementExit(delayTime));
        }
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
        if (toLeft)
            toLeft = false;
        if (toRight)
            toRight = false;
        if (rightToCenter)
            rightToCenter = false;
        if (leftToCenter)
            leftToCenter = false;
    }
}
