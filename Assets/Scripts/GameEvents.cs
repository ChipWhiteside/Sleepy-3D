using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one GameEvents instance exists");
        }
        instance = this;
    }

    public event Action onUpdateInv;
    public void UpdateInv()
    {
        if (onUpdateInv != null)
        {
            onUpdateInv();
        }
    }

    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }

    //public event Action onItemInteract;
    //public void ItemInteract()
    //{
    //    if (onItemInteract != null)
    //    {
    //        onItemInteract();
    //    }
    //}

    //public event Action<Item> onPickupItem;
    //public void PickupItem(Item item)
    //{
    //    if (onPickupItem != null)
    //    {
    //        onPickupItem(item);
    //    }
    //}

    ////public event Action<int, Item> onPickupItem;
    ////public void PickupItem(int addSlotId, Item item)
    ////{
    ////    if (onPickupItem != null)
    ////    {
    ////        onPickupItem(addSlotId, item);
    ////    }
    ////}

    //public event Action<Item> onPickupItemSuccess;
    //public void PickupItemSuccess(Item itemTD)
    //{
    //    if (onPickupItemSuccess != null)
    //    {
    //        onPickupItemSuccess(itemTD);
    //    }
    //}

    //public event Action onPickupItemFail;
    //public void PickupItemFail()
    //{
    //    if (onPickupItemFail != null)
    //    {
    //        onPickupItemFail();
    //    }
    //}

    //public event Action<int, int> onInvSlotSelect;
    //public void InvSlotSelect(int invid, int slotId)
    //{
    //    if (onInvSlotSelect != null)
    //    {
    //        onInvSlotSelect(invid, slotId);
    //    }
    //}

    //public event Action<int> onInvSlotDrop;
    //public void InvSlotDrop(int slotId)
    //{
    //    if (onInvSlotDrop != null)
    //    {
    //        onInvSlotDrop(slotId);
    //    }
    //}

    //public event Action<int> onInvSlotSwap;
    //public void InvSlotSwap(int slotId)
    //{
    //    if (onInvSlotSwap != null)
    //    {
    //        onInvSlotSwap(slotId);
    //    }
    //}

    //public event Action<int> onClearInvSlot;
    //public void ClearInvSlot(int slotId)
    //{
    //    if (onClearInvSlot != null)
    //    {
    //        onClearInvSlot(slotId);
    //    }
    //}

    //public event Action<int, Item> onAddInvSlot;
    //public void AddInvSlot(int slotId, Item item)
    //{
    //    if (onAddInvSlot != null)
    //    {
    //        onAddInvSlot(slotId, item);
    //    }
    //}

    //public event Action onInvMenuPressed;
    //public void InvMenuPressed()
    //{
    //    if (onInvMenuPressed != null)
    //    {
    //        onInvMenuPressed();
    //    }
    //}

    //public event Action onInvMenuOpen;
    //public void InvMenuOpen()
    //{
    //    if (onInvMenuOpen != null)
    //    {
    //        onInvMenuOpen();
    //    }
    //}

    //public event Action onInvMenuClose;
    //public void InvMenuClose()
    //{
    //    if (onInvMenuClose != null)
    //    {
    //        onInvMenuClose();
    //    }
    //}

    //public event Action onStartMenuPressed;
    //public void StartMenuPressed()
    //{
    //    if (onStartMenuPressed != null)
    //    {
    //        onStartMenuPressed();
    //    }
    //}

    //public event Action onStartMenuOpen;
    //public void StartMenuOpen()
    //{
    //    if (onStartMenuOpen != null)
    //    {
    //        onStartMenuOpen();
    //    }
    //}

    //public event Action onStartMenuClose;
    //public void StartMenuClose()
    //{
    //    if (onStartMenuClose != null)
    //    {
    //        onStartMenuClose();
    //    }
    //}

    //public event Action onUpdateInvUI;
    //public void UpdateInvUI()
    //{
    //    if (onUpdateInvUI != null)
    //    {
    //        onUpdateInvUI();
    //    }
    //}







    ////public event Action onTreeGrow;
    ////public void GrowTrees()
    ////{
    ////    if (onTreeGrow != null)
    ////    {
    ////        onTreeGrow();
    ////    }
    ////}

    ////public event Action<int> onChopTree;
    ////public void ChopTree(int treeid)
    ////{
    ////    if (onChopTree != null)
    ////    {
    ////        onChopTree(treeid);
    ////    }
    ////}

    ////public event Action<int> onActionButtonPressed;
    ////public void ActionButtonPressed(int toolid)
    ////{
    ////    if (onActionButtonPressed != null)
    ////    {
    ////        onActionButtonPressed(toolid);
    ////    }
    ////}

    ////public event Action onInventoryItemChanged;
    ////public void InventoryItemChanged()
    ////{
    ////    if (onInventoryItemChanged != null)
    ////    {
    ////        onInventoryItemChanged();
    ////    }
    ////}

    ////public event Action<int> onItemDropButton;
    ////public void ItemDropButton(int slotToDrop)
    ////{
    ////    if (onItemDropButton != null)
    ////    {
    ////        onItemDropButton(slotToDrop);
    ////    }
    ////}

    ////public event Action<int> onItemEquipButton;
    ////public void ItemEquipButton(int slotToEquip)
    ////{
    ////    if (onItemEquipButton != null)
    ////    {
    ////        onItemEquipButton(slotToEquip);
    ////    }
    ////}

    ////public event Action onInventoryPressed;
    ////public void InventoryPressed()
    ////{
    ////    if (onInventoryPressed != null)
    ////    {
    ////        onInventoryPressed();
    ////    }
    ////}

    ////public event Action onInventoryOpened;
    ////public void InventoryOpened()
    ////{
    ////    if (onInventoryOpened != null)
    ////    {
    ////        onInventoryOpened();
    ////    }
    ////}

    ////public event Action onInventoryClosed;
    ////public void InventoryClosed()
    ////{
    ////    if (onInventoryClosed != null)
    ////    {
    ////        onInventoryClosed();
    ////    }
    ////}

    ////public event Action onStartPressed;
    ////public void StartPressed()
    ////{
    ////    if (onStartPressed != null)
    ////    {
    ////        onStartPressed();
    ////    }
    ////}

    ////public event Action onStartOpened;
    ////public void StartOpened()
    ////{
    ////    if (onStartOpened != null)
    ////    {
    ////        onStartOpened();
    ////    }
    ////}

    ////public event Action onStartClosed;
    ////public void StartClosed()
    ////{
    ////    if (onStartClosed != null)
    ////    {
    ////        onStartClosed();
    ////    }
    ////}

    ////public event Action onDropItem;
    ////public void DropItem()
    ////{
    ////    if (onDropItem != null)
    ////    {
    ////        onDropItem();
    ////    }
    ////}

    ////public event Action onManipulatingItem;
    ////public void ManipulatingItem()
    ////{
    ////    if (onManipulatingItem != null)
    ////    {
    ////        onManipulatingItem();
    ////    }
    ////}
}
