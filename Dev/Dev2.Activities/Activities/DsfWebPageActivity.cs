﻿//#define PARALLEL

using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Dev2.Common;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2;
using Dev2.Network.Execution;
using Unlimited.Framework;
using Dev2.DynamicServices;

namespace Unlimited.Applications.BusinessDesignStudio.Activities
{
    public sealed class DsfWebPageActivity : DsfActivity
    {
        private string _xmlConfig = "<WebParts/>";
        private string _websiteServiceName = "Default Master Page";
        private string _formEncodingType = "application/x-www-form-urlencoded";
        private string _metaTags = string.Empty;


        /// <summary>
        /// The XML data containing the configuration data for the web page
        /// </summary>
        public string XMLConfiguration
        {
            get
            {
                return _xmlConfig;
            }
            set
            {
                _xmlConfig = value;
            }
        }

        /// <summary>
        /// The website that that contains the structure that the webpage will render into
        /// </summary>
        public string WebsiteServiceName
        {
            get
            {
                return _websiteServiceName;
            }
            set
            {
                _websiteServiceName = value;
            }
        }

        /// <summary>
        /// The region in the website that will contain this web page
        /// </summary>
        public string WebsiteRegionName { get; set; }

        /// <summary>
        /// Indicates whether this activity is in Preview Mode or not, if so
        /// then bookmarks will not be created
        /// </summary>
        public bool IsPreview { get; set; }

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// The enctype of the html form that will be generated by this activity
        /// </summary>
        public string FormEncodingType
        {
            get
            {
                return _formEncodingType;
            }
            set
            {

                if(!value.Equals("application/x-www-form-urlencoded") && !value.Equals("multipart/form-data") && !value.Equals("text/plain"))
                {
                    throw new ArgumentException(string.Format("'{0}' is an invalid form encoding type", value), "FormEncodingType");
                }
                _formEncodingType = value;

            }

        }

        /// <summary>
        /// The meta tags to associate with this page
        /// </summary>
        public string MetaTags
        {
            get
            {
                return _metaTags;
            }
            set
            {
                _metaTags = value;
            }
        }


        public DsfWebPageActivity()
        {
            DisplayName = "Webpage";
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            //metadata.AddDelegate(_delegate);
        }

        protected override void OnExecute(NativeActivityContext context)
        {

            List<LayoutObject> layoutObjects = new List<LayoutObject>();

            //IDataListCompiler compiler = context.GetExtension<IDataListCompiler>();
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            var errors = new ErrorResultTO();
            ErrorResultTO allErrors = new ErrorResultTO();

            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();

            if(IsPreview)
            {
                try
                {
                    //string webpageValue = compiler.EvaluateFromDataList("[[Dev2WebPage]]", fakeDataListShape, fakeCurrentDataList, fakeCurrentDataList);
                    string webpageValue = compiler.EvaluateSystemEntry(dataObject.DataListID, enSystemTag.Dev2WebPage, out errors);
                    if(errors.HasErrors())
                    {
                        allErrors.MergeErrors(errors);
                    }
                    
                    XMLConfiguration = "<WebPage>" + webpageValue + "</WebPage>";
                }
                catch(Exception) { }
            }

            Guid parentId = dataObject.DataListID;
            Guid executionId = compiler.Shape(dataObject.DataListID, enDev2ArgumentType.Input, InputMapping, out errors);
            dataObject.DataListID = executionId;

            if(errors.HasErrors())
            {
                allErrors.MergeErrors(errors);
            }

            string xmlConfiguration = XMLConfiguration;
            string websiteService = WebsiteServiceName;

            if(string.IsNullOrEmpty(websiteService))
            {
                websiteService = "Default Master Page";
            }

            if(!string.IsNullOrEmpty(WebsiteServiceName))
            {
                websiteService = compiler.Evaluate(dataObject.DataListID, Dev2.DataList.Contract.enActionType.User, WebsiteServiceName, false, out errors).FetchScalar().TheValue;
                if(errors.HasErrors())
                {
                    allErrors.MergeErrors(errors);
                }
            }

            string server = compiler.EvaluateSystemEntry(executionId, enSystemTag.Dev2WebServer, out errors);
            if(errors.HasErrors())
            {
                allErrors.MergeErrors(errors);
            }
            
            //string properWebServer = "<Dev2WebServer>" + server + "</Dev2WebServer>";

            string masterPageTemplate = @"
<html>
    <head>
        <title><Dev2WebpageTitle/></title>
    </head>
    <body>    
        <Dev2WebForm/>
        <Dev2HTML Type=""Form""/>
    </body>
</html>            
";

            IEsbChannel dsfChannel = context.GetExtension<IEsbChannel>();
            Guid dialoutID;

            // 2012.12.03 - Travis.Frisinger :  Strip instance ID and Bookmark

            string instanceId = compiler.EvaluateSystemEntry(dataObject.DataListID, enSystemTag.ParentWorkflowInstanceId, out errors);
            allErrors.MergeErrors(errors);
            dataObject.ParentWorkflowInstanceId = instanceId;
            dataObject.ParentServiceName = dataObject.ServiceName;

            compiler.UpsertSystemTag(dataObject.DataListID, enSystemTag.InstanceId, string.Empty, out errors);
            allErrors.MergeErrors(errors);
            compiler.UpsertSystemTag(dataObject.DataListID, enSystemTag.Bookmark, string.Empty, out errors);
            allErrors.MergeErrors(errors);


            if(!string.IsNullOrEmpty(websiteService))
            {
               
                // PBI 7913 - FIX
                //string exeResult = string.Empty;
                string tmpServiceName = dataObject.ServiceName;
                dataObject.ServiceName = websiteService; // set up for sub-exection ;)
                ErrorResultTO tmpErrors;
                dialoutID = dsfChannel.ExecuteTransactionallyScopedRequest(dataObject, dataObject.WorkspaceID, out tmpErrors);
                dataObject.ServiceName = tmpServiceName;
                //string exeResult = dsfChannel.ExecuteCommand(instruction, dataObject.WorkspaceID, dataObject.DataListID);

                if(!compiler.HasErrors(dialoutID))
                {
                    string val = compiler.EvaluateSystemEntry(executionId, enSystemTag.FormView, out errors);

                    if(val != string.Empty)
                    {
                        var masterPage = val;
                        masterPage = DataListUtil.CDATAUnwrapHTML(masterPage);
                        var masterPageHeader = masterPage.Replace("<FormView>", "").Replace("</FormView>", "");
                        masterPageTemplate = masterPageHeader;
                    }
                    else
                    {
                        masterPageTemplate = @"
                                                <html>
                                                    <head>
                                                        <title><dev2html type=""pagetitle""/></title>
                                                        <dev2html type=""meta""/>
                                                    </head>
                                                    <body>    
                                                        <dev2html type=""form""/>
                                                    </body>
                                                </html>            
                                                ";
                    }
                }
                else
                {
                    throw new Exception("Invalid execution state!");
                }
            }

            masterPageTemplate = masterPageTemplate.ToLower();

            var data = UnlimitedObject.GetStringXmlDataAsUnlimitedObject(xmlConfiguration);

            int rows = 0;
            int cols = 0;
            string webPageName = string.Empty;

            webPageName = data.GetValue("WebPageServiceName");
            int.TryParse(data.GetValue("Rows"), out rows);
            int.TryParse(data.GetValue("Cols"), out cols);

            var s = Stopwatch.StartNew();
            foreach(var item in data.GetAllElements("WebPart"))
            {
                int rowIndex = 0;
                int colIndex = 0;
                int colSpan = 1;
                int rowSpan = 1;


                int.TryParse(item.GetValue("RowIndex"), out rowIndex);
                int.TryParse(item.GetValue("ColumnIndex"), out colIndex);
                int.TryParse(item.GetValue("ColumnSpan"), out colSpan);
                int.TryParse(item.GetValue("RowSpan"), out rowSpan);

                var layoutObj = new LayoutObject();
                layoutObj.WebPartServiceName = item.GetValue("WebPartServiceName");
                layoutObj.RowIndex = rowIndex;
                layoutObj.ColumnIndex = colIndex;
                layoutObj.ColumnSpan = colSpan;
                layoutObj.RowSpan = rowSpan;
                layoutObj.XmlConfiguration = item;

                layoutObjects.Add(layoutObj);
            }

            compiler.UpsertSystemTag(executionId, enSystemTag.Dev2UIServiceOutput, string.Empty, out errors);
            allErrors.MergeErrors(errors);
            compiler.UpsertSystemTag(executionId, enSystemTag.WebPage, string.Empty, out errors);
            allErrors.MergeErrors(errors);

            compiler.UpsertSystemTag(executionId, enSystemTag.InstanceId, string.Empty, out errors);
            allErrors.MergeErrors(errors);

            compiler.UpsertSystemTag(executionId, enSystemTag.Bookmark, string.Empty, out errors);
            allErrors.MergeErrors(errors);

            compiler.UpsertSystemTag(executionId, enSystemTag.BDSDebugMode, string.Empty, out errors);
            allErrors.MergeErrors(errors);

            compiler.UpsertSystemTag(executionId, enSystemTag.Service, webPageName, out errors);
            allErrors.MergeErrors(errors);

            StringBuilder sb = new StringBuilder();
            string formstring = string.Format(@"<form action=""/services/@WebPageServiceName/instances/@WebpageInstance/bookmarks/dsfResumption"" method=""post"" onsubmit=""return checkRequired()"" id=""uiForm"" enctype=""{0}"">", FormEncodingType);
            formstring = formstring.Replace("@WebpageInstance", context.WorkflowInstanceId.ToString()).Replace("@WebPageServiceName", webPageName);
            sb.Append(formstring);
            sb.Append("<table>");

            Dictionary<Guid, string> res = new Dictionary<Guid, string>();
            //int cellRenderCnt = 0;

            // 25.07.2012 - Travis.Frisinger : Check for design mode binding
            //string serviceName = Compiler.ExtractSystemTag(enSystemTag.Service, preExecuteADL);
            string serviceName = compiler.EvaluateSystemEntry(executionId, enSystemTag.Service, out errors);
            allErrors.MergeErrors(errors);         

            string parentService = compiler.EvaluateSystemEntry(executionId, enSystemTag.ParentServiceName, out errors);
            allErrors.MergeErrors(errors);

            bool designTimeBinding = DataListUtil.RequiresDesignTimeBindingSupport(serviceName, parentService);

            //List<Guid> toRemoveDL = new List<Guid>();

            for(int row = 0; row < rows + 1; row++)
            {
                sb.Append("<tr>");
                for(int col = 0; col < cols + 1; col++)
                {
                    sb.Append("<td>");
                    var cell = layoutObjects.FirstOrDefault(c => c.RowIndex == row && c.ColumnIndex == col && !string.IsNullOrEmpty(c.WebPartServiceName));
                    if(cell != null && cell.WebPartServiceName != string.Empty)
                    {
                        var tmpConfig = new UnlimitedObject(GlobalConstants.DataListRootTag);

                        // 25.07.2012 - Travis.Frisinger : Inject design time flag for carry over ;)
                        if(designTimeBinding)
                        {
                            var designBinding = new XElement(enSystemTag.Dev2DesignTimeBinding.ToString());
                            designBinding.Value = "true";
                            tmpConfig.Add(designBinding);
                        }

                        // Travis.Frisinger : 18.10.2012 - Dev2WebServer var issue as it is embeded in all webparts!
                        // Bug : 5995
                        //properWebServer
                        cell.XmlConfiguration.RemoveElementsByTagName("Dev2WebServer");
                        tmpConfig.Add(cell.XmlConfiguration);

                        // TODO : Merge executionID into new tmpDLID for binding...
                        string inst = DataListUtil.StripCrap(tmpConfig.XmlString);
                        IBinaryDataListEntry evaluatedPayload = compiler.Evaluate(parentId, Dev2.DataList.Contract.enActionType.User, inst, false, out errors);
                        allErrors.MergeErrors(errors);

                        if (evaluatedPayload != null)
                        {
                            string payload = evaluatedPayload.FetchScalar().TheValue;

                            IDSFDataObject cellServiceObj = new DsfDataObject(payload, GlobalConstants.NullDataListID);
                            cellServiceObj.ServiceName = cell.WebPartServiceName;
                            

                            ErrorResultTO invokeErrors;
                            Guid currentGuid = dsfChannel.ExecuteTransactionallyScopedRequest(cellServiceObj, dataObject.WorkspaceID, out invokeErrors);
                            allErrors.MergeErrors(invokeErrors);


                            if (currentGuid == cellServiceObj.DataListID)
                            {

                                // 25.07.2012 : Travis.Frisinger - correctly bind variables 
                                // At this point, I need to re-bind vars in the stream to ensure recursive binding happens correctly
                                // since with webpages there is a very real possiblity that recursivly bound var is not in the 
                                // sub activities DL and would cause a blank instead of proper binding ;)

                                //string fragment = Compiler.ExtractSystemTag(enSystemTag.Fragment, result);
                                string fragment = compiler.EvaluateSystemEntry(currentGuid, enSystemTag.Fragment, out errors);
                                if (errors.HasErrors())
                                {
                                    allErrors.MergeErrors(errors);
                                }

                                res.Add(currentGuid, fragment);
                                sb.Append(currentGuid.ToString());

                                // now clean up the tmp dataList
                                compiler.ForceDeleteDataListByID(currentGuid);
                                //toRemoveDL.Add(currentGuid);
                                //executionID = masterExecutionID;

                            }
                            else
                            {
                                res.Add(currentGuid, GlobalConstants.WebpartRenderError);
                            }
                        }
                    }

                    sb.Append("</td>");

                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("</form>");

            string ui = sb.ToString();

            res
                .ToList()
                .ForEach(c =>
                {

                    try
                    {
                        ui = ui.Replace(c.Key.ToString(), c.Value);
                    }
                    catch(Exception)
                    {
                        ui = ui.Replace(c.Key.ToString(), "Part Fetch Error");
                    }
                });
            // Remove encoding to compare and replace objects&amp;gt;
            ui = DataListUtil.RemoveHTMLEncoding(ui);
            masterPageTemplate = DataListUtil.RemoveHTMLEncoding(masterPageTemplate);

            // Travis.Frisinger : Evaluate Title from DataList - Must remain swapped with pre and current ADL to properly eval
            //string evaluatedTitle = Compiler.EvaluateFromDataList(DisplayName, DataObject.DataList, preExecuteADL, DataObject.XmlData);
            string evaluatedTitle = compiler.Evaluate(executionId, Dev2.DataList.Contract.enActionType.User, DisplayName, false, out errors).FetchScalar().TheValue;
            if(errors.HasErrors())
            {
                allErrors.MergeErrors(errors);
            }


            masterPageTemplate = masterPageTemplate.Replace(@"<dev2html type=""pagetitle""/>", evaluatedTitle);

            masterPageTemplate = masterPageTemplate.Replace(@"<dev2html type=""meta""/>", MetaTags);

            masterPageTemplate = masterPageTemplate.Replace(@"<dev2html type=""form""/>", ui);

            masterPageTemplate = masterPageTemplate.Replace("lt;", "<").Replace("gt;", ">");

            // Travis.Frisinger - 13.08.2012 - Inject the wizard script here ;)
            if(designTimeBinding)
            { // We have a wizard :)
                masterPageTemplate = InjectWizardInjectionScript(masterPageTemplate);
            }

            compiler.UpsertSystemTag(executionId, enSystemTag.FormView, masterPageTemplate, out errors);

            if(!IsPreview)
            {
                // DO NOT REMOVE THIS - it is required to resume a workflow.
                dataObject.WorkflowResumeable = true;
                context.CreateBookmark("dsfResumption", Resumed);

                // Signal DataList server to persist the data ;)
                compiler.PersistResumableDataListChain(parentId);

                // Set DataListID to parentID, execution is all done so we need to  clean up an push back against the master DL

                compiler.Shape(executionId, enDev2ArgumentType.Output, OutputMapping, out errors);

                //GCWriter.WriteData(compiler.ConvertFrom(executionID, DataListFormat.CreateFormat(GlobalConstants._XML), enTranslationDepth.Data, out errors));
                
                compiler.ForceDeleteDataListByID(executionId);
                //Guid outshapeIDToRemove = DataListExecutionID.Get(context);

                dataObject.ForceDeleteAtNextNativeActivityCleanup = true; // flag to native activity cleansup correctly ;)

                //compiler.ForceDeleteDataListByID(outshapeIDToRemove);
                dataObject.DataListID = parentId;

                compiler.ConditionalMerge(DataListMergeFrequency.Always | DataListMergeFrequency.OnBookmark,
                    dataObject.DatalistOutMergeID, dataObject.DataListID, dataObject.DatalistOutMergeFrequency, dataObject.DatalistOutMergeType, dataObject.DatalistOutMergeDepth);
                ExecutionStatusCallbackDispatcher.Instance.Post(dataObject.BookmarkExecutionCallbackID, ExecutionStatusCallbackMessageType.BookmarkedCallback);
            }
            else
            {
                // clean up ;)
                compiler.Shape(executionId, enDev2ArgumentType.Output, OutputMapping, out errors);
                allErrors.MergeErrors(errors);

                // reset DataListID
                dataObject.DataListID = parentId;

                // Handle Errors
                if(allErrors.HasErrors())
                {
                    DisplayAndWriteError(webPageName, allErrors);
                    compiler.UpsertSystemTag(dataObject.DataListID, enSystemTag.Error, allErrors.MakeDataListReady(), out errors);
                }

                // clean up all the sub DataList ;) 
                // -- TODO : Figure out why data is not transfering correctly from sub DL into this DL ;(
                //foreach (Guid dlID in toRemoveDL.Where(compiler.DeleteDataListByID))
                //{
                //    compiler.ForceDeleteDataListByID(dlID);
                //}

                // clean up
                compiler.ForceDeleteDataListByID(executionId);
            }
        }

        // Travis.Frisinger - 13.08.2012 : Inject the wizard helper script server side now ;)
        private string InjectWizardInjectionScript(string template)
        {
            //string toInject = "<script type=\"text/javascript\">$(document).ready(function () { $('form').submit(function () { var formPostData = $(this).serialize(); if(isValidForm) { window.external.Dev2Set(formPostData, document.forms[0].action); } return false; }); $('input[type=button]').click(function () { var item = $('input[id ^= \"dev2hidden\"]').remove(); $('form').remove('input[id ^= \"dev2hidden\"]'); $('form').append('<input type=\"hidden\" name=\"' + this.name + '\" id=\"dev2hidden' + this.id + '\"' + ' value=\"' + this.value + '\"/>'); $('form').submit(); }) $('input[type=submit]').click(function () { var item = $('input[id ^= \"dev2hidden\"]').remove(); $('form').remove('input[id ^= \"dev2hidden\"]'); $('form').append('<input type=\"hidden\" name=\"' + this.name + '\" id=\"dev2hidden' + this.id + '\"' + ' value=\"' + this.value + '\"/>'); }) }); </script>";
            const string toInject = @"<script type=""text/javascript"">
                    $(document).ready(function () {
                        $('form').submit(function (event) {
                                var formPostData = $(this).serialize();
                                if(isValidForm) {
                                   Dev2Awesomium.Dev2Set(formPostData, document.forms[0].action);
                                }
                                return false;                    
                        });
                    });
                </script>";

            int idx = template.IndexOf("</head>", StringComparison.Ordinal);
            string result = template.Insert(idx, toInject);

            return result;
        }

        private sealed class WebSiteActivityPayload : IEsbActivityInstruction
        {
            private string _instruction;
            private string _result;

            public int Index;
            //2013.01.16 Brendon.Page Commented out because HashCode was never being used. This was causing a compiler warning.
            //public int HashCode;
            public string Instruction { get { return _instruction; } }
            public string Result { get { return _result; } set { _result = value; } }
            public Guid ID;
            public Guid DataListID { get; set; }

            public void SetInstruction(string value)
            {
                _instruction = value;
            }
        }

        private sealed class WSAPayloadComparer : IEqualityComparer<WebSiteActivityPayload>
        {
            public static readonly WSAPayloadComparer Comparer = new WSAPayloadComparer();

            public bool Equals(WebSiteActivityPayload x, WebSiteActivityPayload y)
            {
                //if (x.InstructionLength != y.InstructionLength) return false;
                //if (x.HashCode != y.HashCode) return false;
                if(String.Equals(x.Instruction, y.Instruction, StringComparison.OrdinalIgnoreCase))
                {
                    if(x.Index == -1)
                    {
                        x.Index = y.Index;
                        x.ID = y.ID;
                    }
                    else if(y.Index == -1)
                    {
                        y.Index = x.Index;
                        y.ID = x.ID;
                    }
                    return true;
                }

                return false;
            }

            public int GetHashCode(WebSiteActivityPayload obj)
            {
                return GetHashCode();
                //2013.01.16 Brendon.Page Commented out because HashCode was nbever being set. This was causing a compiler warning.
                //return obj.HashCode;
            }
        }

        //        // Travis.Frisinger - 13.08.2012 : Inject the wizard helper script server side now ;)
        //        private string InjectStandardWebpageInjectionScript(string template) {
        //            //string toInject = "<script type=\"text/javascript\">$(document).ready(function () { $('form').submit(function () { var formPostData = $(this).serialize(); if(isValidForm) { window.external.Dev2Set(formPostData, document.forms[0].action); } return false; }); $('input[type=button]').click(function () { var item = $('input[id ^= \"dev2hidden\"]').remove(); $('form').remove('input[id ^= \"dev2hidden\"]'); $('form').append('<input type=\"hidden\" name=\"' + this.name + '\" id=\"dev2hidden' + this.id + '\"' + ' value=\"' + this.value + '\"/>'); $('form').submit(); }) $('input[type=submit]').click(function () { var item = $('input[id ^= \"dev2hidden\"]').remove(); $('form').remove('input[id ^= \"dev2hidden\"]'); $('form').append('<input type=\"hidden\" name=\"' + this.name + '\" id=\"dev2hidden' + this.id + '\"' + ' value=\"' + this.value + '\"/>'); }) }); </script>";
        //            string toInject = @"
        //         
        //                <script type=""text/javascript"">
        //                    $(document).ready(function () {
        //                        $('form').submit(function (event) {
        //                                var result = false; 
        //                                if(checkRequired(event)){
        //                                    result = true;
        //                                }else{
        //                                    event.preventDefault(); 
        //                                }
        //                                return result;                    
        //                        });
        //                    });
        //                </script>";

        //            int idx = template.IndexOf("</head>");
        //            string result = template.Insert(idx, toInject);

        //            return result;
        //        }       
    }
}
