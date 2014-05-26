﻿
namespace Dev2.Services.Security.MoqInstallerActions
{
    public class MoqInstallerActionFactory
    {

        public static IMoqInstallerActions CreateInstallerActions()
        {
            return new InstallerActionsForDevelopment();
        }

        public static IWarewolfSecurityOperations CreateSecurityOperationsObject()
        {
            return new WarewolfSecurityOperationsImpl();
        }
    }
}