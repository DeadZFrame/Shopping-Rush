using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.itemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private BoxCollider coll;
    private Transform trans;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
        trans = GetComponent<Transform>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        meshFilter.sharedMesh = item.GetGameObject().GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.sharedMaterials = item.GetGameObject().GetComponent<MeshRenderer>().sharedMaterials;
        trans.localScale = item.GetGameObject().GetComponent<Transform>().localScale;
        trans.rotation = item.GetGameObject().GetComponent<Transform>().rotation;
        coll.size= item.GetGameObject().GetComponent<BoxCollider>().size;
        Rename();

        //meshFilter.sharedMesh = item.GetStand().GetComponent<MeshFilter>().sharedMesh;                    !!!BÜyÜcÜlÜk kodudur!!! Lütfen açmayýnýz!
        //meshRenderer.sharedMaterials = item.GetStand().GetComponent<MeshRenderer>().sharedMaterials;
        //trans.localScale = item.GetStand().GetComponent<Transform>().localScale;
        //trans.rotation = item.GetStand().GetComponent<Transform>().rotation;
        

        //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x-90, gameObject.transform.eulerAngles.y+180, gameObject.transform.eulerAngles.z+15);
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void Rename()
    {
        meshFilter = item.GetGameObject().GetComponent<MeshFilter>();
        var meshName = meshFilter.sharedMesh;
        if (meshName.name.Equals("egg"))
            coll.name = "Egg";
        if (meshName.name.Equals("chicken"))
            coll.name = "Chicken";
        if (meshName.name.Equals("sausage"))
            coll.name = "Sausage";
        if (meshName.name.Equals("bacon"))
            coll.name = "Bacon";
        if (meshName.name.Equals("pork"))
            coll.name = "Pork";
        if (meshName.name.Equals("steak"))
            coll.name = "Steak";

        if (meshName.name.Equals("coffee"))
            coll.name = "Coffee";
        if (meshName.name.Equals("coke"))
            coll.name = "Coke";
        if (meshName.name.Equals("energydrink"))
            coll.name = "Energy Drink";
        if (meshName.name.Equals("icetea"))
            coll.name = "Ice Tea";
        if (meshName.name.Equals("soda"))
            coll.name = "Soda";
        if (meshName.name.Equals("water"))
            coll.name = "Water";

        if (meshName.name.Equals("bread"))
            coll.name = "Bread";
        if (meshName.name.Equals("breadsticks"))
            coll.name = "Breadsticks";
        if (meshName.name.Equals("cookie"))
            coll.name = "Cookie";
        if (meshName.name.Equals("cupcake"))
            coll.name = "Cupcake";
        if (meshName.name.Equals("donut"))
            coll.name = "Donut";
        if (meshName.name.Equals("floursack"))
            coll.name = "Flour Sack";

        if (meshName.name.Equals("apple"))
            coll.name = "Apple";
        if (meshName.name.Equals("banana"))
            coll.name = "Banana";
        if (meshName.name.Equals("mango"))
            coll.name = "Mango";
        if (meshName.name.Equals("strawberry"))
            coll.name = "Strawberry";
        if (meshName.name.Equals("watermelon"))
            coll.name = "Watermelon";
        if (meshName.name.Equals("blueberry"))
            coll.name = "Blueberry";


        if (meshName.name.Equals("cheese"))
            coll.name = "Cheese";
        if (meshName.name.Equals("chomilk"))
            coll.name = "Chocolate Milk";
        if (meshName.name.Equals("fruityogurt"))
            coll.name = "Fruit Yogurt";
        if (meshName.name.Equals("icecream"))
            coll.name = "Ice Cream";
        if (meshName.name.Equals("milk"))
            coll.name = "Milk";
        if (meshName.name.Equals("pudding"))
            coll.name = "Pudding";

        if (meshName.name.Equals("cabbage"))
            coll.name = "Cabbage";
        if (meshName.name.Equals("carrot"))
            coll.name = "Carrot";
        if (meshName.name.Equals("eggplant"))
            coll.name = "Eggplant";
        if (meshName.name.Equals("onion"))
            coll.name = "Onion";
        if (meshName.name.Equals("tomato"))
            coll.name = "Tomato";
        if (meshName.name.Equals("potato"))
            coll.name = "Potato";
    }
}
