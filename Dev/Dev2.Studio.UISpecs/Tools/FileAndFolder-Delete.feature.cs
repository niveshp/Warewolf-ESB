﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Studio.UI.Specs.Tools
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class FileAndFolder_DeleteFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FileAndFolder-Delete.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FileAndFolder-Delete", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "FileAndFolder-Delete")))
            {
                Dev2.Studio.UI.Specs.Tools.FileAndFolder_DeleteFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete Tool Large View And Invalid Variables Expected Error On Done Button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "FileAndFolder-Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DeleteFolder")]
        public virtual void DeleteToolLargeViewAndInvalidVariablesExpectedErrorOnDoneButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Tool Large View And Invalid Variables Expected Error On Done Button", new string[] {
                        "DeleteFolder"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I click \"EXPLORER,UI_localhost_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I click \"RIBBONNEWENDPOINT\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Given("I send \"Delete\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
    testRunner.Given("I drag \"TOOLFILEDELETE\" onto \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.Given("I double click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesign" +
                    "er)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Given("I type \"[[rec@(1).a]]\" in \"WORKSURFACE,Delete(DeleteDesigner),LargeViewContent,UI" +
                    "__FileOrFoldertxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesigner),Don" +
                    "eButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.Given("I type \"[[rec(1).#]]\" in \"WORKSURFACE,Delete(DeleteDesigner),LargeViewContent,UI_" +
                    "_FileOrFoldertxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesigner),Don" +
                    "eButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.Given("I type \"[[rec(1).a]]\" in \"WORKSURFACE,Delete(DeleteDesigner),LargeViewContent,UI_" +
                    "_FileOrFoldertxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesigner),Don" +
                    "eButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is invisible within \"1\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.Given("\"WORKSURFACE,Delete(DeleteDesigner),SmallViewContent\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.Given("I double click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesign" +
                    "er)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.Given("I type \"TestingDelete\" in \"WORKSURFACE,Delete(DeleteDesigner),LargeViewContent,UI" +
                    "__UserNametxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesigner),Don" +
                    "eButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.Given("I send \"{TAB}\" to \"WORKSURFACE,Delete(DeleteDesigner),LargeViewContent,UI__UserNa" +
                    "metxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.Given("I send \"Password\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("I click \"WORKFLOWDESIGNER,Unsaved 1(FlowchartDesigner),Delete(DeleteDesigner),Don" +
                    "eButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.Given("\"WORKSURFACE,UI_Error0_AutoID\" is invisible within \"1\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.Given("\"WORKSURFACE,Delete(DeleteDesigner),SmallViewContent\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
