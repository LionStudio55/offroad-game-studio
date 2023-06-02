//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Purchasing;
//using UnityEngine.Purchasing.Security;


//[Serializable]
//public class InAppItem{
//	public string InAppName;
//	public string InAppString;
//	public ProductType producttype;

//}

//public class InApp_Manager : MonoBehaviour, IStoreListener
//{
//	public static InApp_Manager instance_;
//	public static InApp_Manager instance{
//		get{
//			if (!instance_)
//				instance_ = GameObject.FindObjectOfType<InApp_Manager> ();

//			return instance_;
//		}
//	}
//	public InAppItem[] InAppIds=null;
//	public static event EventHandler consumable_events;
//	private static IStoreController m_StoreController;          // The Unity Purchasing system.
//	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
//	public static bool check_Unlockall=false;
//	public static string No_AdsInGame ="noads";  
//	public static string UnlockAll="unlocklevel";
//	public static string UnlockPlayer="unlockplayer";
//	public static string Mega="megapack";
//    //public static string UnlockAllAll = "combooffers"; //waseem Added
//    //public static string UnlockCars="unlockcars";
//    private static string kProductNameAppleSubscription =  "com.unity3d.subscription.new";
//	private static string kProductNameGooglePlaySubscription =  "com.unity3d.subscription.original";

//    CrossPlatformValidator m_Validator = null;


//    void Awake(){
//		//		instance = this;
//		DontDestroyOnLoad (instance);
//	}
//	void Start()
//	{
//		if (m_StoreController == null)
//		{
//			//Invoke ("InitializePurchasing",3f);
//			//print("dasda");
//			InitializePurchasing();
//            InitializeValidator();

//        }
//	}

//    static bool IsCurrentStoreSupportedByValidator()
//    {
//        //The CrossPlatform validator only supports the GooglePlayStore and Apple's App Stores.
//        return IsGooglePlayStoreSelected() || IsAppleAppStoreSelected();
//    }

//    static bool IsGooglePlayStoreSelected()
//    {
//        var currentAppStore = StandardPurchasingModule.Instance().appStore;
//        return currentAppStore == AppStore.GooglePlay;
//    }

//    static bool IsAppleAppStoreSelected()
//    {
//        var currentAppStore = StandardPurchasingModule.Instance().appStore;
//        return currentAppStore == AppStore.AppleAppStore ||
//               currentAppStore == AppStore.MacAppStore;
//    }

//    public void Buy_Removeads()
//    {
//        Buy_Product(0);
//    }

//    public void Buy_UnlockAll_Levels()
//    {
//        Buy_Product(1);
//    }

//    public void Buy_UnlockAll_Players()
//    {
//        Buy_Product(2);
//    }



//    public void Buy_UnlockAll_All()
//    {
//        Buy_Product(3);
//    }

//    public void InitializePurchasing() 
//	{
//		if (IsInitialized())
//		{

//			// ... we are done here.
//			return;
//		}


//		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

//		//builder.AddProduct(No_AdsInGame, ProductType.NonConsumable);
//		//builder.AddProduct(UnlockAll, ProductType.NonConsumable);
//        //builder.AddProduct(UnlockAllAll, ProductType.NonConsumable);
//        for (int i = 0; i < InApp_Manager.instance.InAppIds.Length; i++)
//		{
//			builder.AddProduct(InApp_Manager.instance.InAppIds[i].InAppString, InApp_Manager.instance.InAppIds[i].producttype);
//		}
//		UnityPurchasing.Initialize(this, builder);
//	}


//	public bool IsInitialized()
//	{
//		print ("Pass");
//		return m_StoreController != null && m_StoreExtensionProvider != null;
//	}

//    void InitializeValidator()
//    {
//        if (IsCurrentStoreSupportedByValidator())
//        {
//#if !UNITY_EDITOR
               
//                m_Validator = new CrossPlatformValidator(GooglePlayTangle.Data(), null, Application.identifier);
//#endif
//        }
//        else
//        {
//           // userWarning.WarnInvalidStore(StandardPurchasingModule.Instance().appStore);
//        }
//    }

//    public void Buy_noAds()
//	{
//		print ("Buy_noAds");
//		if (IsInitialized()) {
//			print ("IsInitialized*****************");

//			if (!CheckProductID_Status (No_AdsInGame)) {
//				BuyProductID (No_AdsInGame);
//			}
//		}
//	}
//	public void Buy_unlockall(){
//		if (IsInitialized()) {
//			if (!CheckProductID_Status (UnlockAll)) {
//				BuyProductID (UnlockAll);
//			}
//		}

//	}
    

//    static void LogReceipts(IEnumerable<IPurchaseReceipt> receipts)
//    {
//        Debug.Log("Receipt is valid. Contents:");
//        foreach (var receipt in receipts)
//        {
//            LogReceipt(receipt);
//        }
//    }

//    static void LogReceipt(IPurchaseReceipt receipt)
//    {
//        Debug.Log($"Product ID: {receipt.productID}\n" +
//                  $"Purchase Date: {receipt.purchaseDate}\n" +
//                  $"Transaction ID: {receipt.transactionID}");

//        if (receipt is GooglePlayReceipt googleReceipt)
//        {
//            Debug.Log($"Purchase State: {googleReceipt.purchaseState}\n" +
//                      $"Purchase Token: {googleReceipt.purchaseToken}");
//        }

//        if (receipt is AppleInAppPurchaseReceipt appleReceipt)
//        {
//            Debug.Log($"Original Transaction ID: {appleReceipt.originalTransactionIdentifier}\n" +
//                      $"Subscription Expiration Date: {appleReceipt.subscriptionExpirationDate}\n" +
//                      $"Cancellation Date: {appleReceipt.cancellationDate}\n" +
//                      $"Quantity: {appleReceipt.quantity}");
//        }
//    }

//    public void Buy_Product(int iapID){
//		if (IsInitialized ()) {
//			if (InApp_Manager.instance.InAppIds[iapID].producttype == ProductType.NonConsumable) {
//				if (!CheckProductID_Status (InApp_Manager.instance.InAppIds[iapID].InAppString)) {
//					BuyProductID (InApp_Manager.instance.InAppIds[iapID].InAppString);
//				}
//			} else {
//				BuyProductID (InApp_Manager.instance.InAppIds[iapID].InAppString);
//			}
//		}
//	}

//	public bool CheckProductID_Status(string productId){
//		Product product = m_StoreController.products.WithID(productId);
//		if (product != null && product.hasReceipt) {

//			return true;
//		} else {
//			return false;
//		}
//	}

//	void BuyProductID(string productId)
//	{
//		if (IsInitialized())
//		{
//			Product product = m_StoreController.products.WithID(productId);
//			if (product != null && product.availableToPurchase)
//			{
//				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
//				m_StoreController.InitiatePurchase(product);
//			}
//			else
//			{
//				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//			}
//		}

//		else
//		{
//			Debug.Log("BuyProductID FAIL. Not initialized.");
//		}
//	}



//	public void RestorePurchases()
//	{

//		if (!IsInitialized())
//		{
//			Debug.Log("RestorePurchases FAIL. Not initialized.");
//			return;
//		}


//		if (Application.platform == RuntimePlatform.IPhonePlayer || 
//			Application.platform == RuntimePlatform.OSXPlayer)
//		{

//			Debug.Log("RestorePurchases started ...");


//			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

//			apple.RestoreTransactions((result) => {

//				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
//			});
//		}

//		else
//		{

//			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
//		}
//	}


//	//  
//	// --- IStoreListener
//	//

//	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//	{
//		m_StoreController = controller;

//		m_StoreExtensionProvider = extensions;
//		if (IsInitialized ()) {
//			if (CheckProductID_Status (No_AdsInGame)) {
//				//Tenlogiclocal.Ads_purchase = true;
//				//	Debug.Log ("ads are purchase");
//			} 

//			if (CheckProductID_Status (UnlockAll)) {
//				check_Unlockall = true;
//				//	Debug.Log ("ads are purchase");
//			} 
//		}
//	}


//	public void OnInitializeFailed(InitializationFailureReason error)
//	{

//		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//	}


//	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
//	{
//        //Retrieve the purchased product
//        var product = args.purchasedProduct;

//        var isPurchaseValid = IsPurchaseValid(product);

//        if (isPurchaseValid)
//        {
//            //Add the purchased product to the players inventory
//          //  UnlockContent(product);
//            Debug.Log("Valid receipt, unlocking content.");

//            if (String.Equals(args.purchasedProduct.definition.id, No_AdsInGame, StringComparison.Ordinal))
//            {
//                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

//                //AdsMainManagerController.instance.hide_Banner ();
//                //.Ads_purchase=true;

//            }
//            else if (String.Equals(args.purchasedProduct.definition.id, InApp_Manager.instance.InAppIds[0].InAppString, StringComparison.Ordinal))//CarrierLevels
//            {
//                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//                PlayerPrefManager.Instance.RemoveAds();
//            }
//            else if (String.Equals(args.purchasedProduct.definition.id, InApp_Manager.instance.InAppIds[1].InAppString, StringComparison.Ordinal))//cars
//            {
//                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//                PlayerPrefManager.Instance.UnlockAllLevels();
//            }

//            else if (String.Equals(args.purchasedProduct.definition.id, InApp_Manager.instance.InAppIds[2].InAppString, StringComparison.Ordinal))//cars
//            {
//                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
//                PlayerPrefManager.Instance.UnlockAllWeapons();

//            }
//            else if (String.Equals(args.purchasedProduct.definition.id, InApp_Manager.instance.InAppIds[3].InAppString, StringComparison.Ordinal))//cars
//            {
//                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

//                PlayerPrefs.SetInt("AllInApp", 1);

//                PlayerPrefManager.Instance.RemoveAds();
//                PlayerPrefManager.Instance.UnlockAllLevels();
//                PlayerPrefManager.Instance.UnlockAllWeapons();
//            }



//            // Or ... an unknown product has been purchased by this user. Fill in additional products here....
//            else
//            {
//                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
//            }

//        }
//        else
//        {
//            Debug.Log("Invalid receipt, not unlocking content.");
//        }


      
       
//		return PurchaseProcessingResult.Complete;
       
//    }

//    bool IsPurchaseValid(Product product)
//    {
//        //If we the validator doesn't support the current store, we assume the purchase is valid
//        if (IsCurrentStoreSupportedByValidator())
//        {
//            try
//            {
//                var result = m_Validator.Validate(product.receipt);
//                //The validator returns parsed receipts.
//                LogReceipts(result);
//            }
//            //If the purchase is deemed invalid, the validator throws an IAPSecurityException.
//            catch (IAPSecurityException reason)
//            {
//                Debug.Log($"Invalid receipt: {reason}");
//                return false;
//            }
//        }

//        return true;
//    }


//    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//	{

//		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
//	}

//	public void give_CosumeEvent(){
//		if (consumable_events != null)
//			consumable_events (null, null);
//	}

//	public void removeall_ConsumeEvent(){
//		consumable_events = null;
//	}
//}

