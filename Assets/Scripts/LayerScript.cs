using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScript : MonoBehaviour
{
    public Transform leftLayer, rightLayer, center, cart;
    public Vector3 offset;
    Vector3 centerPos, leftLayerPos, rightLayerPos;

    private void LateUpdate()
    {
        centerPos = center.position;
        leftLayerPos = centerPos + offset;
        rightLayerPos = centerPos + -offset;

        float cartX = cart.position.x;
        float cartY = cart.position.y;

        center.position = new Vector3(cartX, cartY, 0);
        leftLayer.position = leftLayerPos;
        rightLayer.position = rightLayerPos;
    }
}
