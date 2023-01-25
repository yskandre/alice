using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DocWriter : MonoBehaviour
{
    [SerializeField] GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        SystemData sys = GameObject.Find("SystemData").GetComponent<SystemData>();
        GameObject button;

        bg.SetActive(true);

        //bob
        button = GameObject.Find("Doc1");
        button.GetComponent<Image>().color = sys.solvedCode[0] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[0];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = sys.solvedCode[5] ?
            @"void Init() {
    commands = new Queue<Command>();
    position = startingPosition;
    rotation = startingRotation;
}
void moveForward(Vector2 movement) {
    position.x += movement.x;
    position.y += movement.y;
}
void turnLeft() { rotation -= 90; }
void turnRight() { rotation += 90; }
void skip(int j) { while(i > 0) { commands.dequeue(); j--; } }" : sys.solvedCode[1] ?
            @"void Init() {
    commands = new Queue<Command>();
    position = startingPosition;
    rotation = startingRotation;
}
void moveForward(Vector2 movement) {
    position.x += movement.x;
    position.y += movement.y;
}
void turnLeft() { rotation -= 90; }
void turnRight() { rotation += 90; }" : sys.solvedCode[0] ? @"void Init() {
    commands = new Queue<Command>();
    position = startingPosition;
    rotation = startingRotation;
}
void moveForward(Vector2 movement) {
    position.x += movement.x;
    position.y += movement.y;
}" : "";

        //cond
        button = GameObject.Find("Doc2");
        button.GetComponent<Image>().color = sys.solvedCode[2] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[2];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = sys.solvedCode[4] ?
            @"bool checkCondition(Command cmd) {
    nextMove = commands.dequeue();
    if (nextMove == cmd) {
        return true;
    }
}
void Execute(Command cmd) {
    switch(cmd) {
        case forward: moveForward(); break;
        case left: turnLeft(); break;
        case right: turnRight(); break;
    }
}" : sys.solvedCode[2] ?
            @"bool checkCondition(Command cmd) {
    nextMove = commands.dequeue();
    if (nextMove == cmd) {
        return true;
    }
}" : "";

        //loop
        button = GameObject.Find("Doc3");
        button.GetComponent<Image>().color = sys.solvedCode[3] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[3];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = sys.solvedCode[3] ?
            @"void repeat(Command cmd, int j) {
    for(int i = 0; i < j; i++) {
        cmd.execute();
    }
}" : "";

        //func
        button = GameObject.Find("Doc4");
        button.GetComponent<Image>().color = sys.solvedCode[6] ? new Color32(158, 158, 158, 255) : new Color32(101, 101, 101, 255);
        button.GetComponent<Button>().enabled = sys.solvedCode[6];
        button.transform.Find("DocCode").GetComponent<TextMeshProUGUI>().text = sys.solvedCode[7] ? @"override void moveForward(Vector2 movement) {
    position.x += movement.x * 2;
    position.y += movement.y * 2;
}
void toggleLock(DoorTile lock) {
    if(lock.isOpen()) {
        lock.setOpen(false);
    } else {
        lock.setOpen(true);
    }
}" : sys.solvedCode[6] ? @"override void moveForward(Vector2 movement) {
    position.x += movement.x * 2;
    position.y += movement.y * 2;
}" : "";

        bg.SetActive(false);
    }
}
