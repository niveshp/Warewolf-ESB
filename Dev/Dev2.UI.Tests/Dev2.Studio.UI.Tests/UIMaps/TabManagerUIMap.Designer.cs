﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

using Dev2.Studio.UI.Tests;

namespace Dev2.CodedUI.Tests.TabManagerUIMapClasses
{
    using System.CodeDom.Compiler;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;


    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class TabManagerUIMap : UIMapBase
    {

        private UITestControl mainPane;

        public UITestControl GetManager()
        {
            if(mainPane == null)
            {
                mainPane = DockManagerUIMap.GetMainPane();
            }

            if(mainPane != null)
            {
                return mainPane.GetChildren()[0].GetChildren()[0];
            }

            return null;
        }

        public UITestControl FindTabByName(string name, int waitAmt = 0)
        {
            UITestControl control = _tabManager.GetTab(name);
            Playback.Wait(waitAmt);
            return control;
        }

        private int GetChildrenCount()
        {
            int childCount = 0;
            if(_tabManager != null)
            {
                foreach(var child in _tabManager.GetChildren())
                {
                    if(child.ControlType.Name == "TabPage")
                    {
                        childCount = _tabManager.GetChildren().Count;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return childCount;
        }

        private UITestControlCollection GetWorkflowNotSavedButtons(string windowTitle = "Workflow not saved...")
        {
            // Workflow not saved...
            UITestControl theWindow = new UITestControl();
            theWindow.TechnologyName = "MSAA";
            theWindow.SearchProperties["Name"] = windowTitle;
            theWindow.SearchProperties["ControlType"] = "Window";
            theWindow.Find();
            UITestControlCollection firstChildren = theWindow.GetChildren();

            var ctrls = firstChildren.Where(c => c.ClassName == "Uia.Button");

            UITestControlCollection saveDialogButtons = new UITestControlCollection();
            foreach(UITestControl control in ctrls)
            {
                saveDialogButtons.Add(control);
            }

            return saveDialogButtons;
        }

        public class UIUI_TabManager : WpfTabList
        {
            public UIUI_TabManager(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
            {
                #region Search Criteria
                this.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "UI_TabManager_AutoID";
                this.WindowTitles.Add(TestBase.GetStudioWindowName());
                #endregion

                //_tabMgr = VisualTreeWalker.GetControl(new string[] { "UI_DocManager_AutoID" });

            }

            public UITestControl GetTab(string childAutomationID)
            {
                WpfTabList theList = (WpfTabList)this;
                UITestControlCollection tabList = theList.Tabs; // This lags for some reason
                foreach(WpfTabPage currentTapPage in tabList)
                {
                    UITestControlCollection tabChildren = currentTapPage.GetChildren();
                    foreach(var tabChild in tabChildren)
                    {
                        if(tabChild.FriendlyName.Contains(childAutomationID))
                        {
                            return currentTapPage;
                        }
                    }
                }
                return null;
            }
        }
    }
}
