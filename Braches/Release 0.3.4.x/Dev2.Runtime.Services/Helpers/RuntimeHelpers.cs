﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev2.Common;
using Dev2.Data.ServiceModel.Helper;
using Dev2.DataList.Contract;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;

namespace Dev2.Runtime.Helpers
{
    public class RuntimeHelpers
    {
        public virtual Guid GetCorrectDataList(IDSFDataObject dataObject, Guid workspaceID, ErrorResultTO errors, IDataListCompiler compiler)
        {
            string theShape;
            ErrorResultTO invokeErrors;
            // Account for silly webpages...

            // If no DLID, we need to make it based upon the request ;)
            if (dataObject.DataListID == GlobalConstants.NullDataListID)
            {
                theShape = FindServiceShape(workspaceID, dataObject.ServiceName, true);
                dataObject.DataListID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML),
                    dataObject.RawPayload, theShape, out invokeErrors);
                errors.MergeErrors(invokeErrors);
                dataObject.RawPayload = string.Empty;
            }

            // local non-scoped execution ;)


            //if (!dataObject.IsDataListScoped && isLocal)
            //{
            //    theShape = FindServiceShape(workspaceID, dataObject.ServiceName, true);
            //    innerDatalistID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML),
            //                                         dataObject.RawPayload, theShape, out invokeErrors);
            //    errors.MergeErrors(invokeErrors);
            //    var mergedID = compiler.Merge(innerDatalistID, dataObject.DataListID,
            //                                  enDataListMergeTypes.Union, enTranslationDepth.Data_With_Blank_OverWrite,
            //                                  true, out invokeErrors);
            //    errors.MergeErrors(invokeErrors);
            //    oldID = dataObject.DataListID;
            //    dataObject.DataListID = mergedID;
            //}
            //else
            //{
            // force all items to exist in the DL ;)
            theShape = FindServiceShape(workspaceID, dataObject.ServiceName, true);
            var innerDatalistID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML),
                string.Empty, theShape, out invokeErrors);
            errors.MergeErrors(invokeErrors);

            // Add left to right
            var left = compiler.FetchBinaryDataList(dataObject.DataListID, out invokeErrors);
            errors.MergeErrors(invokeErrors);
            var right = compiler.FetchBinaryDataList(innerDatalistID, out invokeErrors);
            errors.MergeErrors(invokeErrors);

            DataListUtil.AddMissingFromRight(left, right, out invokeErrors);
            errors.MergeErrors(invokeErrors);
            compiler.PushBinaryDataList(left.UID, left, out invokeErrors);
            errors.MergeErrors(invokeErrors);

            //var mergedID = compiler.Merge(dataObject.DataListID, innerDatalistID, 
            //                              enDataListMergeTypes.Union, enTranslationDepth.Data,
            //                              false, out invokeErrors);
            errors.MergeErrors(invokeErrors);
            //oldID = dataObject.DataListID;
            //dataObject.DataListID = mergedID;

            //}
            return innerDatalistID;
        }

        /// <summary>
        /// Finds the service shape.
        /// </summary>
        /// <param name="workspaceID">The workspace ID.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns></returns>
        public string FindServiceShape(Guid workspaceID, string serviceName, bool serviceInputs)
        {
            var services = ResourceCatalog.Instance.GetDynamicObjects<DynamicService>(workspaceID, serviceName);

            var tmp = services.FirstOrDefault();
            const string baseResult = "<ADL></ADL>";
            var result = "<DataList></DataList>";

            if (tmp != null)
            {
                result = tmp.DataListSpecification;

                // Handle services ;)
                if (result == baseResult && tmp.OutputSpecification == null)
                {
                    var serviceDef = tmp.ResourceDefinition;

                    ErrorResultTO errors;
                    if (!serviceInputs)
                    {
                        var outputMappings = ServiceUtils.ExtractOutputMapping(serviceDef);
                        result = DataListUtil.ShapeDefinitionsToDataList(outputMappings, enDev2ArgumentType.Output,
                                                                         out errors);
                    }
                    else
                    {
                        var inputMappings = ServiceUtils.ExtractInputMapping(serviceDef);
                        result = DataListUtil.ShapeDefinitionsToDataList(inputMappings, enDev2ArgumentType.Input,
                                                                         out errors);
                    }
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                result = "<DataList></DataList>";
            }

            return result;
        }
    }
}
