using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] GameObject loopText;
    [SerializeField] GameObject queueText;
    [SerializeField] GameObject funcText;
    [SerializeField] GameObject victoryText;
    [SerializeField] GameObject lossText;
    [SerializeField] int levelID;


    static float queuePos;
    static bool canExecute = true;
    static Queue<Image> orderImages = new Queue<Image>();
    static Queue<MoveOrder> orders = new Queue<MoveOrder>();
    static Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    static int currentX;
    static int currentY;
    static int currentDir;
    static Image player;
    private MoveOrder allowedCommand;
    private bool ifActive = false;
    private CaseTile fwdCase;
    private CaseTile leftCase;
    private CaseTile rightCase;
    private bool switchActive = false;
    private MoveOrder loopCommand;
    private int loopAmount;
    private bool loopActive = false;
    private int queueAmount;
    private bool queueActive = false;
    private bool funcActive = false;

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
        Image tempImage;
        bool changedTile = false;
        foreach (MoveOrder m in orders)
        {
            changedTile = false;
            if (funcActive)
            {
                tempImage = orderImages.Dequeue();
                tempImage.transform.localPosition = new Vector3(tempImage.transform.localPosition.x - (.5f * 100 * (1920 / Screen.width)), tempImage.transform.localPosition.y, tempImage.transform.localPosition.z);
                foreach (Image i in orderImages)
                {
                    i.transform.localPosition = new Vector3(i.transform.localPosition.x - (.1f * 100 * (1920 / Screen.width)), i.transform.localPosition.y, i.transform.localPosition.z);
                }
                Destroy(tempImage.gameObject);

                switch (m)
                {
                    case MoveOrder.forward:
                        transform.position = new Vector3(transform.position.x + (directions[currentDir].x * 20), transform.position.y, transform.position.z + (directions[currentDir].y * 20));
                        changedTile = true;
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

                changedTile = true;
            }
            if (queueActive)
            {
                if (orderImages.Count <= 0)
                {
                    queueActive = false;
                    queueAmount = 0;
                    continue;
                }

                tempImage = orderImages.Dequeue();
                tempImage.transform.localPosition = new Vector3(tempImage.transform.localPosition.x - (.5f * 100 * (1920 / Screen.width)), tempImage.transform.localPosition.y, tempImage.transform.localPosition.z);
                foreach (Image i in orderImages)
                {
                    i.transform.localPosition = new Vector3(i.transform.localPosition.x - (.1f * 100 * (1920 / Screen.width)), i.transform.localPosition.y, i.transform.localPosition.z);
                }
                Destroy(tempImage.gameObject);

                queueAmount--;

                if (queueAmount <= 0) queueActive = false;
                UpdateQueueUI();
            }
            if (switchActive)
            {
                tempImage = orderImages.Dequeue();
                tempImage.transform.localPosition = new Vector3(tempImage.transform.localPosition.x - (.5f * 100 * (1920 / Screen.width)), tempImage.transform.localPosition.y, tempImage.transform.localPosition.z);
                foreach (Image i in orderImages)
                {
                    i.transform.localPosition = new Vector3(i.transform.localPosition.x - (.1f * 100 * (1920 / Screen.width)), i.transform.localPosition.y, i.transform.localPosition.z);
                }
                Destroy(tempImage.gameObject);

                switch (m)
                {
                    case MoveOrder.forward:
                        transform.position = new Vector3(fwdCase.transform.position.x, transform.position.y, fwdCase.transform.position.z);
                        break;
                    case MoveOrder.left:
                        transform.position = new Vector3(leftCase.transform.position.x, transform.position.y, leftCase.transform.position.z);
                        break;
                    case MoveOrder.right:
                        transform.position = new Vector3(rightCase.transform.position.x, transform.position.y, rightCase.transform.position.z);
                        break;
                }
                changedTile = true;
                switchActive = false;
            }

            if (loopActive)
            {
                while (loopAmount > 0)
                {
                    switch (loopCommand)
                    {
                        case MoveOrder.forward:
                            transform.position = new Vector3(transform.position.x + (directions[currentDir].x * 10), transform.position.y, transform.position.z + (directions[currentDir].y * 10));
                            changedTile = true;
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

                    loopAmount--;
                    UpdateLoopUI();
                    yield return Wait();
                }
                loopActive = false;

            }

            if (ifActive)
            {
                if (m == allowedCommand)
                {
                    ifActive = false;
                }
                else
                {
                    tempImage = orderImages.Dequeue();
                    tempImage.transform.localPosition = new Vector3(tempImage.transform.localPosition.x - (.5f * 100 * (1920 / Screen.width)), tempImage.transform.localPosition.y, tempImage.transform.localPosition.z);
                    foreach (Image i in orderImages)
                    {
                        i.transform.localPosition = new Vector3(i.transform.localPosition.x - (.1f * 100 * (1920 / Screen.width)), i.transform.localPosition.y, i.transform.localPosition.z);
                    }
                    Destroy(tempImage.gameObject);
                    continue;
                }
            }

            if (!switchActive || !loopActive || !funcActive || !queueActive)
            {
                tempImage = orderImages.Dequeue();
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
                        changedTile = true;
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

                changedTile = true;
            }

            if (!changedTile) continue;

            GameObject currentTile = GameObject.Find(GetCurrentCoords());

            if (currentTile == null || currentTile.GetComponent<NullTile>() != null || (currentTile.GetComponent<LockTile>() != null && currentTile.GetComponent<LockTile>().isOpen()))
            {
                // Lose, restart
                lossText.SetActive(true);
                break;
            }
            else if (currentTile.GetComponent<GoalTile>() != null)
            {
                // Win
                GameObject.Find("SystemData").GetComponent<SystemData>().solvedBot[levelID] = true;
                victoryText.SetActive(true);
            }
            else if (currentTile.GetComponent<IfTile>() != null)
            {
                allowedCommand = currentTile.GetComponent<IfTile>().getAllowedCommand();
                ifActive = true;
            }
            else if (currentTile.GetComponent<SwitchTile>() != null)
            {
                fwdCase = currentTile.GetComponent<SwitchTile>().getFwdCase();
                leftCase = currentTile.GetComponent<SwitchTile>().getLeftCase();
                rightCase = currentTile.GetComponent<SwitchTile>().getRightCase();
                switchActive = true;
            }
            else if (currentTile.GetComponent<LoopTile>() != null)
            {
                loopCommand = currentTile.GetComponent<LoopTile>().getLoopCommand();
                loopAmount = currentTile.GetComponent<LoopTile>().getLoopAmount();
                loopActive = true;
                UpdateLoopUI();
            }
            else if (currentTile.GetComponent<KeyTile>() != null)
            {
                currentTile.GetComponent<KeyTile>().ChangeLock();
            }
            else if (currentTile.GetComponent<QueueTile>() != null)
            {
                queueActive = true;
                queueAmount = currentTile.GetComponent<QueueTile>().GetAmount();
            }
            else if (currentTile.GetComponent<FunctionTile>() != null)
            {
                funcActive = currentTile.GetComponent<FunctionTile>().isActive();
            }
            yield return Wait();
        }
        resetQueue();
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.25f);
    }

    public void resetQueue()
    {
        foreach (Image i in orderImages) Destroy(i.gameObject);
        orderImages = new Queue<Image>();
        orders = new Queue<MoveOrder>();
        queuePos = 0.0f;
        canExecute = true;
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

    public void UpdateLoopUI()
    {
        switch (loopCommand)
        {
            case MoveOrder.forward:
                loopText.GetComponent<Image>().sprite = forward.sprite;
                break;
            case MoveOrder.left:
                loopText.GetComponent<Image>().sprite = left.sprite;
                break;
            case MoveOrder.right:
                loopText.GetComponent<Image>().sprite = right.sprite;
                break;
        }
        loopText.SetActive(loopActive);
        loopText.GetComponentInChildren<TextMeshProUGUI>().text = loopAmount.ToString();
    }

    public void UpdateQueueUI()
    {
        queueText.SetActive(queueActive);
        queueText.GetComponentInChildren<TextMeshProUGUI>().text = queueAmount.ToString();
    }

    public void UpdateFuncUI()
    {
        funcText.SetActive(funcActive);
    }
}
