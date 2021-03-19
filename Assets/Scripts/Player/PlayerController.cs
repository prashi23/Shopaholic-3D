using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float playerSpeed = 4f;
    [SerializeField]
    private UI_InventoryHandler uiInventoryHandler;

    public float turnSmoothTime = 0.2f;
    private Transform mainCamera;
    float turnSmoothVelocity;

    private bool groundedPlayer;
    private float g = -9.8f;
    private Vector3 playerVelocity;

    private float inputHorizontal, inputVertical;
    private CharacterController charController;
    private Animator animator;

    private Inventory playerInventory;
    [SerializeField]
    private GameObject inventoryUI;
    [SerializeField]
    private TextMeshProUGUI itemAddedMessage;

    private bool itemBuyCondition = false;
    private Item currBuyItem;

    void Awake() {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main.transform;
        itemAddedMessage.CrossFadeAlpha(0.0f, 0f, false);

    }

    void Start() {
        playerInventory = new Inventory();
        uiInventoryHandler.SetInventory(playerInventory);
    }

    // Update is called once per frame
    void Update() {
        groundedPlayer = charController.isGrounded;
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(inputHorizontal, 0, inputVertical).normalized;

        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }

            if (move.magnitude>= 0.1f) {
            float targetAngle = Mathf.Atan2(move.x, move.z)*Mathf.Rad2Deg+ mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;

            animator.SetFloat("Horizontal", inputHorizontal);
            animator.SetFloat("Vertical", inputVertical);
            charController.Move(moveDir.normalized * playerSpeed * Time.deltaTime);

        }

        playerVelocity.y += g * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);

        ShowOrHideInventory();
        BuyItem();

    }

    public void AddItemToInventory(Item item) {
        playerInventory.AddItem(item);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("ShopTrigger")) {
            itemBuyCondition = true;
            currBuyItem = other.gameObject.GetComponent<TriggerController>().GetItem();
        }
        if(other.gameObject.CompareTag("Finish")) {
            GameManager.instance.GameWin();
            Debug.Log("Game Win");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("ShopTrigger")) {
            itemBuyCondition = false;
            currBuyItem = null;
        }
    }

    private void BuyItem() {
        if(Input.GetKeyDown(KeyCode.E) && itemBuyCondition) {
            if ((GameManager.instance.GetPlayerMoney - currBuyItem.itemPrice) < 0) {
                itemAddedMessage.text = "Insufficient Balance";
                itemAddedMessage.color = Color.red;
                itemAddedMessage.CrossFadeAlpha(1.0f, 0f, false);
                itemAddedMessage.CrossFadeAlpha(0.0f, 2f, false);
                return;
            }
            Debug.Log("Item Buy");
            playerInventory.AddItem(currBuyItem);
            AudioManager.instance.PlayPickSound();
            itemAddedMessage.color = new Color(0f, 0.9716981f, 0.2934147f);
            itemAddedMessage.text = "Item Added To Inventory";
            itemAddedMessage.CrossFadeAlpha(1.0f, 0f, false);
            itemAddedMessage.CrossFadeAlpha(0.0f, 2f, false);

        }
    }

    public void ShowOrHideInventory() {
        if(Input.GetKeyDown(KeyCode.I)) {
            if (inventoryUI.activeSelf) {
                inventoryUI.SetActive(false);
                Time.timeScale = 1;
            }
                
            else {
                Time.timeScale = 0;
                inventoryUI.SetActive(true);
            }
                
        }
    }

    
}
