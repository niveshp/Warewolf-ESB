﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev2.Studio.Core.Interfaces;

namespace Dev2.Studio.Core.Messages
{
    public class DeleteResourceMessage : AbstractResourceMessage
    {
        public DeleteResourceMessage(IResourceModel resourceModel, bool showDialog) : base(resourceModel)
        {
            ShowDialog = showDialog;
        }

        public bool ShowDialog;
    }
}
