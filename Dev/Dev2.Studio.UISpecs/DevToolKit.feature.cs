﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Studio.UI.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class SpecFlowFeature1Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DevToolKit.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFlowFeature1", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SpecFlowFeature1")))
            {
                Dev2.Studio.UI.Specs.SpecFlowFeature1Feature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TshepoPermissionsExample")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFlowFeature1")]
        public virtual void TshepoPermissionsExample()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TshepoPermissionsExample", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 161
testRunner.Given("\"WINDOWDEBUG\" is visible within \"5\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TshepoDesignerExample")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFlowFeature1")]
        public virtual void TshepoDesignerExample()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TshepoDesignerExample", ((string[])(null)));
#line 164
this.ScenarioSetup(scenarioInfo);
#line 178
 testRunner.Given("\"EXPLORERFOLDERS,UI_EXAMPLES_AutoID,UI_Recordset - Records Length_AutoID,v.1*\" is" +
                    " visible within \"2\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TshepoDragandDropExample")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFlowFeature1")]
        public virtual void TshepoDragandDropExample()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TshepoDragandDropExample", ((string[])(null)));
#line 180
this.ScenarioSetup(scenarioInfo);
#line 207
     testRunner.Given("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 208
    testRunner.Given("I click \"EXPLORER,UI_localhost_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 210
    testRunner.And("I click \"RIBBONSETTINGS\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
    testRunner.Given("I click \"SETTINGSRESOURCEROW1,UI_AddRemovebtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 213
    testRunner.And("I click \"SECURITYSAVE\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
     testRunner.Given("I click \"SETTINGSRESOURECESELECT\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 216
       testRunner.And("I double click \"RESOURCEPICKERFOLDERS,UI_BARNEY_AutoID,UI_Decision Testing_AutoID" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 217
    testRunner.Given("I click \"UI_SelectServiceWindow_AutoID,UI_SelectServiceOKButton_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 218
    testRunner.And("I send \"{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 219
    testRunner.And("I send \"UI Testing Group\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 220
       testRunner.And("I click \"SETTINGSRESOURCEROW1,UI__ContributePermissionCheckBox_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 221
       testRunner.And("I click \"SECURITYSAVE\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 223
    testRunner.Given("I click \"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_BARNEY_" +
                    "AutoID,UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 224
    testRunner.Then("I double click \"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_" +
                    "BARNEY_AutoID,UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 225
    testRunner.And("\"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_BARNEY_AutoID,U" +
                    "I_Decision Testing_AutoID\" is visible within \"7\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 226
    testRunner.Given("I click \"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_BARNEY_" +
                    "AutoID,UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 227
    testRunner.Then("\"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_BARNEY_AutoID,U" +
                    "I_Decision Testing_AutoID,UI_CanEdit_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 228
    testRunner.Then("\"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_BARNEY_AutoID,U" +
                    "I_Decision Testing_AutoID,UI_CanExecute_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 230
    testRunner.Then("I double click \"EXPLORER,UI_TestingPermisions (http://localhost:3142/)_AutoID,UI_" +
                    "BARNEY_AutoID,UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 231
    testRunner.And("\"WORKFLOWDESIGNER,Decision Testing(FlowchartDesigner)\" is visible within \"7\" seco" +
                    "nds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 233
    testRunner.Then("\"RIBBONSETTINGS\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 234
    testRunner.Then("\"RIBBONNEWDATABASECONNECTOR\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 235
    testRunner.Then("\"RIBBONSCHEDULE\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 236
    testRunner.Then("\"RIBBONNEWPLUGINCONNECTOR\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 237
    testRunner.Then("\"RIBBONNEWWEBCONNECTOR\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 238
    testRunner.Then("\"RIBBONSAVE\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 239
    testRunner.Then("\"RIBBONDEPLOY\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 240
    testRunner.Then("\"RIBBONDEBUG\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 242
     testRunner.Given("I click \"RIBBONDEPLOY\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 243
       testRunner.Given("I click \"ACTIVETAB,DeployUserControl,UI_DestinationServercbx_AutoID,U_UI_Destinat" +
                    "ionServercbx_AutoID_TestingPermisions\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 244
       testRunner.Given("\"DEPLOYDESTINATION,TestingPermisions*,UI_Unautherized_DeployToText_AutoID\" is vis" +
                    "ible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 245
       testRunner.Then("I click \"ACTIVETAB,DeployUserControl,UI_SourceServercbx_AutoID,U_UI_SourceServerc" +
                    "bx_AutoID_TestingPermisions\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 246
       testRunner.Then("\"DEPLOYSOURCE,UI_Unautherized_DeployFrom_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
