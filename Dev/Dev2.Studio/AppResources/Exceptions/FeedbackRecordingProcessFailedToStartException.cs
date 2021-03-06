
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

//2013.02.06: Ashley Lewis - Bug 8611
// ReSharper disable once CheckNamespace
namespace Dev2.Studio.AppResources.Exceptions
{
    public class FeedbackRecordingProcessFailedToStartException : Exception
    {
        public FeedbackRecordingProcessFailedToStartException()
        {

        }

        public FeedbackRecordingProcessFailedToStartException(string message)
            : base(message)
        {

        }
    }
}
