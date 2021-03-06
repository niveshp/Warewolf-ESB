
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2014 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


using System;
using Dev2.DataList.Contract;
using Dev2.DynamicServices.Objects;
using Dev2.Services.Execution;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Execution
{
    /// <summary>
    /// Database Execution Container
    /// </summary>
    public class DatabaseServiceContainer : EsbExecutionContainer
    {
        readonly IServiceExecution _databaseServiceExecution;

        #region Constuctors

        public DatabaseServiceContainer(ServiceAction sa, IDSFDataObject dataObj, IWorkspace workspace, IEsbChannel esbChannel)
            : base(sa, dataObj, workspace, esbChannel)
        {
            _databaseServiceExecution = new DatabaseServiceExecution(dataObj);
        }
        public DatabaseServiceContainer(IServiceExecution databaseServiceExecution)
        {
            _databaseServiceExecution = databaseServiceExecution;
        }

        #endregion

        #region Execute

        public override Guid Execute(out ErrorResultTO errors)
        {
            errors = new ErrorResultTO();
            _databaseServiceExecution.BeforeExecution(errors);

            var databaseServiceExecution = _databaseServiceExecution as DatabaseServiceExecution;
            if(databaseServiceExecution != null)
            {
                databaseServiceExecution.InstanceOutputDefintions = InstanceOutputDefinition;
            }

            var result = _databaseServiceExecution.Execute(out errors);
            _databaseServiceExecution.AfterExecution(errors);
            return result;
        }

        #endregion
    }
}
