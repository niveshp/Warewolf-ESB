
// JJD 8/28/02 - Added support for runtime string customizations
// This class needs to be outside the namespace
using System.Globalization;
using Infragistics.Shared;
internal class ResourceCustomizerLocator
{
	private ResourceCustomizerLocator()
	{
	}

	internal static readonly Infragistics.Shared.ResourceCustomizer Customizer = new Infragistics.Shared.ResourceCustomizer();
}

//-----------------------------------------------------------------
// Note: The only code that needs to be changed is the namespace
//       below, which should be the name of the primary namespace
//       of the assembly. However, no 2 assemblies should have an
//       instance of this file with the same namespace specified 
//       below.
//-----------------------------------------------------------------
namespace Infragistics.Windows // change this line only to the unigue namespace of this assembly
{
	/// <summary>
	/// Exposes a <see cref="Infragistics.Shared.ResourceCustomizer"/> instance for this assembly. 
	/// </summary>
	/// <seealso cref="Customizer"/> 
	/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/> 
	public sealed class Resources
	{
		// AS 1/8/03 - FxCop
		// Added private ctor so we don't get a default public one.
		private Resources(){}

		/// <summary>
		/// Returns the <see cref="Infragistics.Shared.ResourceCustomizer"/> for this assembly.
		/// </summary>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/> 
		public static Infragistics.Shared.ResourceCustomizer Customizer { get { return ResourceCustomizerLocator.Customizer; } }

		// AS 7/15/05
		// Provide a way for the customer to get the resolved resource
		// string/object that the assembly has access to.
		//
		#region GetString
		/// <summary>
		/// Returns the resource string using the specified name and default culture.
		/// </summary>
		/// <param name="name">Name of the string resource to return.</param>
		/// <param name="args">Arguments supplied to the string.Format method when formatting the string.</param>
		public static string GetString(string name, params object[] args)
		{
			return SR.GetString(name, args);
		}

		/// <summary>
		/// Returns the resource string using the specified resource name and default culture. The string is then formatted using the arguments specified.
		/// </summary>
		/// <param name="name">Name of the string resource to return.</param>
		public static string GetString(string name)
		{
			return SR.GetString(name);
		}

		#endregion //GetString


		#region GetDynamicResourceString

		// JJD 3/07/07
		// Added support for DynamicResourceStrings

		/// <summary>
		/// Returns a DynamicResourceString object that tracks customization changes to a resource and raises an event when the resource value is changed.
		/// </summary>
		/// <param name="name">Name of the string resource to return.</param>
		/// <returns>A <see cref="Infragistics.Shared.DynamicResourceString"/> object to track changes in the resource customizations.</returns>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.SetCustomizedString"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.ResetCustomizedString"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.ResetAllCustomizedStrings"/>
		public static Infragistics.Shared.DynamicResourceString GetDynamicResourceString(string name)
		{
			return SR.GetDynamicResourceString(name, null, null);
		}

		/// <summary>
		/// Returns a DynamicResourceString object that tracks customization changes to a resource and raises an event when the resource value is changed.
		/// </summary>
		/// <param name="name">Name of the string resource to return.</param>
		/// <param name="args">Arguments supplied to the string.Format method when formatting the string.</param>
		/// <returns>A <see cref="Infragistics.Shared.DynamicResourceString"/> object to track changes in the resource customizations.</returns>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.SetCustomizedString"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.ResetCustomizedString"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.ResetAllCustomizedStrings"/>
		public static Infragistics.Shared.DynamicResourceString GetDynamicResourceString(string name, object[] args)
		{
			return SR.GetDynamicResourceString(name, args, null);
		}

		/// <summary>
		/// Returns a DynamicResourceString object that tracks customization changes to a resource and raises an event when the resource value is changed.
		/// </summary>
		/// <param name="name">Name of the string resource to return.</param>
		/// <param name="args">Arguments supplied to the string.Format method when formatting the string.</param>
		/// <param name="culture">Culture whose resource should loaded. The resource will go through a fallback process to locate the appropriate resources.</param>
		/// <returns>A <see cref="Infragistics.Shared.DynamicResourceString"/> object to track changes in the resource customizations.</returns>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.SetCustomizedString"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.ResetCustomizedString"/>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer.ResetAllCustomizedStrings"/>
		public static Infragistics.Shared.DynamicResourceString GetDynamicResourceString(string name, object[] args, CultureInfo culture)
		{
			return SR.GetDynamicResourceString(name, args, null);
		}

			#endregion //GetDynamicResourceString


		#region GetObject
		/// <summary>
		/// Returns the resource object using the specified name.
		/// </summary>
		/// <param name="name">Name of the resource item</param>
		/// <returns>An object containing the specified resource</returns>
		public static object GetObject(string name)
		{
			return SR.GetObject(name);
		}
		#endregion //GetObject

		#region DynamicResourceString properties

		/// <summary>
		/// Returns a <see cref="DynamicResourceString"/> instance that contains the localized resource for the tooltip of the close button in the <see cref="Infragistics.Windows.Controls.ToolWindow"/>
		/// </summary>
		public static DynamicResourceString CloseButtonToolTip
		{
			get { return GetDynamicResourceString("CloseButtonToolTip"); }
		}

		// AS 1/26/11 NA 2011 Vol 1 - Min/Max/Taskbar
		/// <summary>
		/// Returns a <see cref="DynamicResourceString"/> instance that contains the localized resource for the tooltip of the maximize button in the <see cref="Infragistics.Windows.Controls.ToolWindow"/>
		/// </summary>
		public static DynamicResourceString MaximizeButtonToolTip
		{
			get { return GetDynamicResourceString("MaximizeButtonToolTip"); }
		}

		/// <summary>
		/// Returns a <see cref="DynamicResourceString"/> instance that contains the localized resource for the tooltip of the minimize button in the <see cref="Infragistics.Windows.Controls.ToolWindow"/>
		/// </summary>
		public static DynamicResourceString MinimizeButtonToolTip
		{
			get { return GetDynamicResourceString("MinimizeButtonToolTip"); }
		}

		/// <summary>
		/// Returns a <see cref="DynamicResourceString"/> instance that contains the localized resource for the tooltip of the restore up button in the <see cref="Infragistics.Windows.Controls.ToolWindow"/>
		/// </summary>
		public static DynamicResourceString RestoreUpButtonToolTip
		{
			get { return GetDynamicResourceString("RestoreUpButtonToolTip"); }
		}

		/// <summary>
		/// Returns a <see cref="DynamicResourceString"/> instance that contains the localized resource for the tooltip of the restore down button in the <see cref="Infragistics.Windows.Controls.ToolWindow"/>
		/// </summary>
		public static DynamicResourceString RestoreDownButtonToolTip
		{
			get { return GetDynamicResourceString("RestoreDownButtonToolTip"); }
		}


		#endregion //DynamicResourceString properties

	}
}


#region Copyright (c) 2001-2012 Infragistics, Inc. All Rights Reserved
/* ---------------------------------------------------------------------*
*                           Infragistics, Inc.                          *
*              Copyright (c) 2001-2012 All Rights reserved               *
*                                                                       *
*                                                                       *
* This file and its contents are protected by United States and         *
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
* TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
* TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
* CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
* THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF INFRAGISTICS, INC. *
*                                                                       *
* UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
* PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
* SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY INFRAGISTICS PRODUCT.    *
*                                                                       *
* THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
* CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF INFRAGISTICS,      *
* INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
* INSURE ITS CONFIDENTIALITY.                                           *
*                                                                       *
* THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
* PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
* EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
* THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
* SOURCE CODE CONTAINED HEREIN.                                         *
*                                                                       *
* THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2001-2012 Infragistics, Inc. All Rights Reserved