﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VendingMachine.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VendingMachine.Resources.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please take your change:{0}.
        /// </summary>
        public static string ChangeText {
            get {
                return ResourceManager.GetString("ChangeText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to the Vending Help Center.
        /// </summary>
        public static string HelpText {
            get {
                return ResourceManager.GetString("HelpText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT COIN.
        /// </summary>
        public static string InsertCoin {
            get {
                return ResourceManager.GetString("InsertCoin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Amount entered: {0}.
        /// </summary>
        public static string InsertSuccess {
            get {
                return ResourceManager.GetString("InsertSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter valid coins.
        /// </summary>
        public static string InvalidCoins {
            get {
                return ResourceManager.GetString("InvalidCoins", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Product Number.
        /// </summary>
        public static string InvalidProduct {
            get {
                return ResourceManager.GetString("InvalidProduct", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Item Left.
        /// </summary>
        public static string ItemLeft {
            get {
                return ResourceManager.GetString("ItemLeft", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Price is .
        /// </summary>
        public static string PriceText {
            get {
                return ResourceManager.GetString("PriceText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The product is dispensed.
        /// </summary>
        public static string ProductPurchased {
            get {
                return ResourceManager.GetString("ProductPurchased", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SOLD OUT.
        /// </summary>
        public static string SoldOut {
            get {
                return ResourceManager.GetString("SoldOut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank You.
        /// </summary>
        public static string ThankYou {
            get {
                return ResourceManager.GetString("ThankYou", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome To our Vending Machine.
        /// </summary>
        public static string WelcomeText {
            get {
                return ResourceManager.GetString("WelcomeText", resourceCulture);
            }
        }
    }
}
