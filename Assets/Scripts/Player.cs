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
    public ShoppingListManager shoppingListManager;
    public UI_Inventory uI_Inventory;

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
        shoppingListManager = FindObjectOfType<ShoppingListManager>();
    }

    private void Update()
    {
        if (!uI.levelStart.activeInHierarchy)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
        TouchControls();
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
            
            uI.LevelEnd.SetActive(true);
            Time.timeScale = 0;
            //if(shoppingListManager.money<0)
            //{
            //    uI.nextLevel.gameObject.SetActive(false);
            //    uI.restartButton.gameObject.SetActive(true);
            //}
            //else
            //{
            //    uI.nextLevel.gameObject.SetActive(true);
            //    uI.restartButton.gameObject.SetActive(false);
            //    level.sceneIndex++;
            //}
           
            if (level.sceneIndex == 0)
            {
                if(shoppingListManager.amounts[shoppingListManager.apple] == 0 && shoppingListManager.amounts[shoppingListManager.strawberry] == 0 && shoppingListManager.money >= 0)
                {
                    uI.nextLevel.gameObject.SetActive(true);
                    uI.restartButton.gameObject.SetActive(false);
                }
                else
                {
                    uI.nextLevel.gameObject.SetActive(false);
                    uI.restartButton.gameObject.SetActive(true);
                }
            }
            if (level.sceneIndex == 1)
            {
                if (shoppingListManager.amounts[shoppingListManager.potato] == 0 && shoppingListManager.amounts[shoppingListManager.waterMelon] == 0 && shoppingListManager.amounts[shoppingListManager.donut] == 0 && shoppingListManager.money >= 0)
                {
                    uI.nextLevel.gameObject.SetActive(true);
                    uI.restartButton.gameObject.SetActive(false);
                }
                else
                {
                    uI.nextLevel.gameObject.SetActive(false);
                    uI.restartButton.gameObject.SetActive(true);

                }
            }

            if (level.sceneIndex == 2)
            {
                if (shoppingListManager.amounts[shoppingListManager.pork] == 0 && shoppingListManager.amounts[shoppingListManager.mango] == 0 && shoppingListManager.amounts[shoppingListManager.coffee] == 0 &&
                    shoppingListManager.amounts[shoppingListManager.milk] == 0 && shoppingListManager.money >= 0)
                {
                    uI.nextLevel.gameObject.SetActive(true);
                    uI.restartButton.gameObject.SetActive(false);
                }
                else
                {
                    uI.nextLevel.gameObject.SetActive(false);
                    uI.restartButton.gameObject.SetActive(true);

                }
            }
            if (level.sceneIndex == 3)
            {
                if (shoppingListManager.amounts[shoppingListManager.energyDrink] == 0 && shoppingListManager.amounts[shoppingListManager.cookie] == 0 && shoppingListManager.amounts[shoppingListManager.blueberries] == 0 &&
                    shoppingListManager.amounts[shoppingListManager.cheese] == 0 && shoppingListManager.money >= 0)
                {
                    uI.nextLevel.gameObject.SetActive(true);
                    uI.restartButton.gameObject.SetActive(false);
                }
                else
                {
                    uI.nextLevel.gameObject.SetActive(false);
                    uI.restartButton.gameObject.SetActive(true);

                }
            }
            if (level.sceneIndex == 4)
            {
                if (shoppingListManager.amounts[shoppingListManager.coke] == 0 && shoppingListManager.amounts[shoppingListManager.cupcake] == 0 && shoppingListManager.amounts[shoppingListManager.onion] == 0 &&
                    shoppingListManager.amounts[shoppingListManager.chicken] == 0 && shoppingListManager.money >= 0)
                {
                    uI.nextLevel.gameObject.SetActive(true);
                    uI.restartButton.gameObject.SetActive(false);
                }
                else
                {
                    uI.nextLevel.gameObject.SetActive(false);
                    uI.restartButton.gameObject.SetActive(true);

                }
            }


        }
        if (other.tag.Equals("Stand"))
        {
            for(float i = 0; i < 1.2f; i += 0.3f)
            {
                StartCoroutine(DelayAlphaChange(i));
            }
            shoppingListManager.price = 1f;
        }
        if(other.tag.Equals("item") && level.sceneIndex==0 || other.tag.Equals("item") && level.sceneIndex == 1 || other.tag.Equals("item") && level.sceneIndex == 2)
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
