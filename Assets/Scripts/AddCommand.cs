using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoveOrder
{
    forward,
    left,
    right
}

public class AddCommand : MonoBehaviour
{

    [SerializeField] Transform parent;
    [SerializeField] int startingX;
    [SerializeField] int startingZ;
    [SerializeField] Image forward;
    [SerializeField] Image left;
    [SerializeField] Image right;
    [SerializeField] Canvas canvas;

    static float queuePos;
    static bool canExecute = true;
    static Queue<Image> orderImages = new Queue<Image>();
    static Queue<MoveOrder> orders = new Queue<MoveOrder>();
    static Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    static int currentX;
    static int currentY;
    static int currentDir;
    static Image player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddForwardOrder()
    {
        if (canExecute)
        {
            Image orderImage = Instantiate(forward, new Vector3(0f, 0f, 0f), Quaternion.identity, parent);
            orderImage.transform.localPosition = new Vector3((100 + (queuePos * 150f)) * (1920 / Screen.width), 200 * (1080 / Screen.height), 0);
            orderImages.Enqueue(orderImage);
            orders.Enqueue(MoveOrder.forward);
            queuePos += .1f;
        }
    }

    public void AddLeftOrder()
    {
        if (canExecute)
        {
            Image orderImage = Instantiate(left, new Vector3(0f, 0f, 0f), Quaternion.identity, parent);
            orderImage.transform.localPosition = new Vector3((100 + (queuePos * 150f)) * (1920 / Screen.width), 200 * (1080 / Screen.height), 0);
            orderImages.Enqueue(orderImage);
            orders.Enqueue(MoveOrder.left);
            queuePos += .1f;
        }
    }

    public void AddRightOrder()
    {
        if (canExecute)
        {
            Image orderImage = Instantiate(right, new Vector3(0f, 0f, 0f), Quaternion.identity, parent);
            orderImage.transform.localPosition = new Vector3((100 + (queuePos * 150f)) * (1920 / Screen.width), 200 * (1080 / Screen.height), 0);
            orderImages.Enqueue(orderImage);
            orders.Enqueue(MoveOrder.right);
            queuePos += .1f;
        }
    }

    public void Execute()
    {
        if (canExecute)
        {
            canExecute = false;
            StartCoroutine(ExecuteMoves());
        }
    }

    public System.Collections.IEnumerator ExecuteMoves()
    {
        foreach (MoveOrder m in orders)
        {
            Image tempImage = orderImages.Dequeue();
            tempImage.transform.localPosition = new Vector3(tempImage.transform.localPosition.x - (.5f * 100 * (1920 / Screen.width)), tempImage.transform.localPosition.y, tempImage.transform.localPosition.z);
            foreach (Image i in orderImages)
            {
                i.transform.localPosition = new Vector3(i.transform.localPosition.x - (.1f * 100 * (1920 / Screen.width)), i.transform.localPosition.y, i.transform.localPosition.z);
            }
            Destroy(tempImage.gameObject);

            switch (m)
            {
                case MoveOrder.forward:
                    transform.position = new Vector3(transform.position.x + (directions[currentDir].x * 10), transform.position.y, transform.position.z + (directions[currentDir].y * 10));
                    break;
                case MoveOrder.left:
                    currentDir = (currentDir + 3) % 4;
                    transform.Rotate(0, -90, 0);
                    break;
                case MoveOrder.right:
                    currentDir = (currentDir + 1) % 4;
                    transform.Rotate(0, 90, 0);
                    break;
            }

            GameObject currentTile = GameObject.Find(GetCurrentCoords());

            if (currentTile == null)
            {
                // Lose, restart
                init();
                break;
            }
            else if (currentTile.GetComponent<GoalTile>() != null)
            {
                // Win
            }
            else if (currentTile.GetComponent<SwitchTile>() != null)
            {

            }
            else if (currentTile.GetComponent<LoopTile>() != null)
            {

            }
            yield return Wait();
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.25f);
    }

    public void init()
    {
        foreach (Image i in orderImages) Destroy(i.gameObject);
        orderImages = new Queue<Image>();
        orders = new Queue<MoveOrder>();
        queuePos = 0.0f;
        canExecute = true;
        currentDir = 0;
        transform.position = new Vector3(startingX, transform.position.y, startingZ);
        transform.rotation = Quaternion.identity;
    }

    string GetCurrentCoords()
    {
        Vector2Int coords = new Vector2Int();

        coords.x = Mathf.RoundToInt(transform.position.x / 10);
        coords.y = Mathf.RoundToInt(transform.position.z / 10);

        return coords.ToString();
    }

}
