﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Dev2.CodedUI.Tests.UIMaps.DeployViewUIMapClasses
{
    using Dev2.Studio.UI.Tests;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using System.CodeDom.Compiler;


    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class DeployViewUIMap
    {
        private UITestControl DestinationServerTreeviewExplorer(UITestControl theTab)
        {
            UITestControlCollection allChildren = DeployTabsChildren(theTab);
            UITestControl targetNavigationView = new UITestControl();
            foreach(UITestControl theControl in allChildren)
            {
                if (theControl.GetProperty("AutomationId").ToString() == "TargetNavigationView")
                {
                    targetNavigationView = theControl;
                    break;
                }
            }

            return targetNavigationView.GetChildren()[0];
        }

        private UITestControlCollection DeployTabsChildren(UITestControl theTab)
        {
            return GetDeployUserControlChildren(theTab);
        }

        private UITestControl GetSourceServerList(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach (UITestControl theControl in requiredChildren)
            {
                if (theControl.GetProperty("AutomationId").ToString() == "ConnectUserControl")
                {
                    foreach (UITestControl tC in theControl.GetChildren())
                    {
                        if (tC.GetProperty("AutomationId").ToString() == "UI_SourceServercbx_AutoID")
                        {
                            return tC;

                        }
                    }

                }
            }
            return null;
        }

        private WpfEdit GetSourceServerFilterBox(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach (UITestControl theControl in requiredChildren)
            {
                var autoID = theControl.GetProperty("AutomationId").ToString();
                if (autoID == "SourceNavigationView")
                {
                    foreach (var child in theControl.GetChildren())
                    {
                        var childAutoID = child.GetProperty("AutomationId").ToString();
                        if (childAutoID == "FilterTextBox")
                        {
                            return (WpfEdit)theControl.GetChildren()[0];
                        }
                    }
                }
            }

            return null;
        }

        private WpfEdit GetDestinationServerFilterBox(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach (UITestControl theControl in requiredChildren)
            {
                var autoID = theControl.GetProperty("AutomationId").ToString();
                if(autoID == "TargetNavigationView")
                {
                    foreach(var child in theControl.GetChildren())
                    {
                        var childAutoID = child.GetProperty("AutomationId").ToString();
                        if(childAutoID == "FilterTextBox")
                        {
                            return (WpfEdit)theControl.GetChildren()[0];
                        }
                    }
                }
            }

            return null;
        }

        private UITestControl GetDestinationServerList(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach (UITestControl theControl in requiredChildren)
            {
                if (theControl.GetProperty("AutomationId").ToString() == "ConnectUserControl")
                {
                    foreach (UITestControl tC in theControl.GetChildren())
                    {
                        if (tC.GetProperty("AutomationId").ToString() == "UI_DestinationServercbx_AutoID")
                        {
                            return tC;
                            
                        }
                    }
                    
                }
            }
            return null;
        }

        private int GetSelectedDeployCount(UITestControl theTab)
        {
            int totalCount = 0;
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            for (int j = 0; j < requiredChildren.Count; j++)
            {
                UITestControl theControl = requiredChildren[j];
                if (theControl.GetProperty("Name") != null)
                {
                    string nameProperty = theControl.GetProperty("Name").ToString();
                    if ((nameProperty == "Services  : ") || (nameProperty == "Workflows  : ") || (nameProperty == "Sources  : "))
                    {
                        WpfText textControl = (WpfText)requiredChildren[j + 1];

                        int count = int.Parse(textControl.DisplayText);
                        totalCount += count;
                    }
                }
            }
            return totalCount;
        }

        private int GetSelectedDeploySummaryCount(UITestControl theTab)
        {
            int totalCount = 0;
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            for (int j = 0; j < requiredChildren.Count; j++)
            {
                UITestControl theControl = requiredChildren[j];
                if (theControl.GetProperty("Name") != null)
                {
                    string nameProperty = theControl.GetProperty("Name").ToString();
                    if ((nameProperty == "New Resources  : ") || (nameProperty == "Override  : "))
                    {
                        WpfText textControl = (WpfText)requiredChildren[j + 1];

                        int count = int.Parse(textControl.DisplayText);
                        totalCount += count;
                    }
                }
            }
            return totalCount;
        }

        private UITestControlCollection GetDeployUserControlChildren(UITestControl theTab)
        {
            UITestControlCollection theCollection = theTab.GetChildren();
            UITestControl splurtControl = theCollection[6];
            var uiTestControl = splurtControl.GetChildren()[0];
            UITestControlCollection DeployUserControlChildren = uiTestControl.GetChildren();
            return DeployUserControlChildren;

        }

        private WpfButton GetDeployButton(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach (UITestControl theControl in requiredChildren)
            {
                if (theControl.GetProperty("AutomationId") != null)
                {
                    if (theControl.GetProperty("AutomationId").ToString() == "UI_Deploybtn_AutoID")
                    {
                        return (WpfButton)theControl;
                    }
                }
            }
            return null;
        }

        public virtual Environment_Wizards_Workflow_EnterSampleWorkflowDetailsParams Environment_Wizards_Workflow_EnterSampleWorkflowDetailsParams
        {
            get
            {
                if ((this.mEnvironment_Wizards_Workflow_EnterSampleWorkflowDetailsParams == null))
                {
                    this.mEnvironment_Wizards_Workflow_EnterSampleWorkflowDetailsParams = new Environment_Wizards_Workflow_EnterSampleWorkflowDetailsParams();
                }
                return this.mEnvironment_Wizards_Workflow_EnterSampleWorkflowDetailsParams;
            }
        }

        public virtual AssertForWorkflowDesignerExpectedValues AssertForWorkflowDesignerExpectedValues
        {
            get
            {
                if ((this.mAssertForWorkflowDesignerExpectedValues == null))
                {
                    this.mAssertForWorkflowDesignerExpectedValues = new AssertForWorkflowDesignerExpectedValues();
                }
                return this.mAssertForWorkflowDesignerExpectedValues;
            }
        }

        public virtual someMethodForDeployTabParams someMethodForDeployTabParams
        {
            get
            {
                if ((this.msomeMethodForDeployTabParams == null))
                {
                    this.msomeMethodForDeployTabParams = new someMethodForDeployTabParams();
                }
                return this.msomeMethodForDeployTabParams;
            }
        }

        public virtual DeployTabSomeStuffItDoesParams DeployTabSomeStuffItDoesParams
        {
            get
            {
                if ((this.mDeployTabSomeStuffItDoesParams == null))
                {
                    this.mDeployTabSomeStuffItDoesParams = new DeployTabSomeStuffItDoesParams();
                }
                return this.mDeployTabSomeStuffItDoesParams;
            }
        }

        public UIBusinessDesignStudioWindow UIBusinessDesignStudioWindow
        {
            get
            {
                if ((this.mUIBusinessDesignStudioWindow == null))
                {
                    this.mUIBusinessDesignStudioWindow = new UIBusinessDesignStudioWindow();
                }
                return this.mUIBusinessDesignStudioWindow;
            }
        }


        public UIServiceDetailsWindow UIServiceDetailsWindow
        {
            get
            {
                if ((this.mUIServiceDetailsWindow == null))
                {
                    this.mUIServiceDetailsWindow = new UIServiceDetailsWindow();
                }
                return this.mUIServiceDetailsWindow;
            }
        }

        public UIServiceDetailsWindow1 UIServiceDetailsWindow1
        {
            get
            {
                if ((this.mUIServiceDetailsWindow1 == null))
                {
                    this.mUIServiceDetailsWindow1 = new UIServiceDetailsWindow1();
                }
                return this.mUIServiceDetailsWindow1;
            }
        }

        public UIBusinessDesignStudioWindow2 UIBusinessDesignStudioWindow2
        {
            get
            {
                if ((this.mUIBusinessDesignStudioWindow2 == null))
                {
                    this.mUIBusinessDesignStudioWindow2 = new UIBusinessDesignStudioWindow2();
                }
                return this.mUIBusinessDesignStudioWindow2;
            }
        }


        #region Fields

        private Environment_Wizards_Workflow_EnterSampleWorkflowDetailsParams mEnvironment_Wizards_Workflow_EnterSampleWorkflowDetailsParams;

        private AssertForWorkflowDesignerExpectedValues mAssertForWorkflowDesignerExpectedValues;

        private someMethodForDeployTabParams msomeMethodForDeployTabParams;

        private DeployTabSomeStuffItDoesParams mDeployTabSomeStuffItDoesParams;

        private UIBusinessDesignStudioWindow mUIBusinessDesignStudioWindow;

        private UIBusinessDesignStudioWindow1 mUIBusinessDesignStudioWindow1;

        private UIServiceDetailsWindow mUIServiceDetailsWindow;

        private UIServiceDetailsWindow1 mUIServiceDetailsWindow1;

        private UIBusinessDesignStudioWindow2 mUIBusinessDesignStudioWindow2;

        private UIBusinessDesignStudioWindow11 mUIBusinessDesignStudioWindow11;
        #endregion
    }

    #region UI Window

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIBusinessDesignStudioWindow : WpfWindow
    {

        public UIBusinessDesignStudioWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = TestBase.GetStudioWindowName();
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UITargetNavigationViewCustom UITargetNavigationViewCustom
        {
            get
            {
                if ((this.mUITargetNavigationViewCustom == null))
                {
                    this.mUITargetNavigationViewCustom = new UITargetNavigationViewCustom(this);
                }
                return this.mUITargetNavigationViewCustom;
            }
        }
        #endregion

        #region Fields
        private UITargetNavigationViewCustom mUITargetNavigationViewCustom;
        #endregion
    }


    #endregion UI Window

    #region Destination Server Navigation View

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UITargetNavigationViewCustom : WpfCustom
    {

        public UITargetNavigationViewCustom(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.NavigationView";
            this.SearchProperties["AutomationId"] = "TargetNavigationView";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UITvExplorerTree UITvExplorerTree
        {
            get
            {
                if ((this.mUITvExplorerTree == null))
                {
                    this.mUITvExplorerTree = new UITvExplorerTree(this);
                }
                return this.mUITvExplorerTree;
            }
        }
        #endregion

        #region Fields
        private UITvExplorerTree mUITvExplorerTree;
        #endregion
    }

    #endregion Destination Server Navigation View

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UITvExplorerTree : WpfTree
    {

        public UITvExplorerTree(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTree.PropertyNames.AutomationId] = "tvExplorer";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UIDev2StudioCoreViewMoTreeItem UIDev2StudioCoreViewMoTreeItem
        {
            get
            {
                if ((this.mUIDev2StudioCoreViewMoTreeItem == null))
                {
                    this.mUIDev2StudioCoreViewMoTreeItem = new UIDev2StudioCoreViewMoTreeItem(this);
                }
                return this.mUIDev2StudioCoreViewMoTreeItem;
            }
        }
        #endregion

        #region Fields
        private UIDev2StudioCoreViewMoTreeItem mUIDev2StudioCoreViewMoTreeItem;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIDev2StudioCoreViewMoTreeItem : WpfTreeItem
    {

        public UIDev2StudioCoreViewMoTreeItem(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTreeItem.PropertyNames.AutomationId] = "UI_DestinationServer_tfsbld (http://rsaklfsvrtfsbld:77/dsf)_AutoID";
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public UIDev2StudioCoreViewMoTreeItem1 UIDev2StudioCoreViewMoTreeItem1
        {
            get
            {
                if ((this.mUIDev2StudioCoreViewMoTreeItem1 == null))
                {
                    this.mUIDev2StudioCoreViewMoTreeItem1 = new UIDev2StudioCoreViewMoTreeItem1(this);
                }
                return this.mUIDev2StudioCoreViewMoTreeItem1;
            }
        }
        #endregion

        #region Fields
        private UIDev2StudioCoreViewMoTreeItem1 mUIDev2StudioCoreViewMoTreeItem1;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIDev2StudioCoreViewMoTreeItem1 : WpfTreeItem
    {

        public UIDev2StudioCoreViewMoTreeItem1(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTreeItem.PropertyNames.AutomationId] = "UI_DestinationServer_WORKFLOW SERVICES_AutoID";
            this.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
            this.WindowTitles.Add(TestBase.GetStudioWindowName());
            #endregion
        }

        #region Properties
        public WpfTreeItem UIDev2StudioCoreViewMoTreeItem
        {
            get
            {
                if ((this.mUIDev2StudioCoreViewMoTreeItem == null))
                {
                    this.mUIDev2StudioCoreViewMoTreeItem = new WpfTreeItem(this);
                    #region Search Criteria
                    this.mUIDev2StudioCoreViewMoTreeItem.SearchProperties[WpfTreeItem.PropertyNames.AutomationId] = "UI_DestinationServer_MO_AutoID";
                    this.mUIDev2StudioCoreViewMoTreeItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIDev2StudioCoreViewMoTreeItem.WindowTitles.Add(TestBase.GetStudioWindowName());
                    #endregion
                }
                return this.mUIDev2StudioCoreViewMoTreeItem;
            }
        }
        #endregion

        #region Fields
        private WpfTreeItem mUIDev2StudioCoreViewMoTreeItem;
        #endregion
    }
}
