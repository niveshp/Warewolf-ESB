﻿using System.ComponentModel.Composition;
using Caliburn.Micro;
using Dev2.Composition;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.ViewModels;
using Dev2.Studio.ViewModels.Diagnostics;
using Dev2.Studio.Views.Diagnostics;
using Infragistics.Windows.DockManager.Events;
using Microsoft.Windows.Controls.Ribbon;
using System.Windows;
using System.Windows.Controls;

namespace Dev2.Studio.Views
{

    public partial class MainView : RibbonWindow
    {
        #region Constructor

        public MainView()
        {
            InitializeComponent();
            ImportService.SatisfyImports(this);
            InitializeDebugOutputWindow();
            //SetUpTextEditor();
            //Mediator.RegisterToReceiveMessage(MediatorMessages.ShowDataInOutputWindow, ShowDataInOutputWindow);
            //Mediator.RegisterToReceiveMessage(MediatorMessages.AppendDataToOutputWindow, AppendDataToOutputWindow );
            //Mediator.RegisterToReceiveMessage(MediatorMessages.ClearOutputWindow, ClearOutputWindow);
        }

        #endregion Constructor

        #region Properties

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        #endregion Properties

        #region Private Methods

        private void InitializeDebugOutputWindow()
        {
            DebugOutputView debugOutputWindow = new DebugOutputView();
            DebugOutputViewModel debugTreeViewModel = new DebugOutputViewModel();
            debugOutputWindow.DataContext = debugTreeViewModel;
            OutputPane.Content = debugOutputWindow;
        }

        #endregion Private Methods

        #region Event Handlers

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {

            IMainViewModel dataContext = DataContext as IMainViewModel;

            if (dataContext != null)
            {
                //Push up dependencies to the ViewModel
                //dataContext.UserInterfaceLayoutProvider.Manager = dockManager;
                dataContext.UserInterfaceLayoutProvider.Value.Manager = TabManager;
                dataContext.UserInterfaceLayoutProvider.Value.OutputPane = OutputPane;
                dataContext.UserInterfaceLayoutProvider.Value.NavigationPane = Explorer;
                // TODO PBI 8291
                //dataContext.UserInterfaceLayoutProvider.Value.PropertyPane = Properties;
                //dataContext.UserInterfaceLayoutProvider.Value.DataMappingPane = Mapping;
                dataContext.UserInterfaceLayoutProvider.Value.DataListPane = Variables;
                dataContext.LoadExplorerPage();
                dataContext.AddStartTabs();
            }
        }

        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainViewModel data = this.DataContext as MainViewModel;
            data.UserInterfaceLayoutProvider.Value.PersistTabs(TabManager.Items);
            Application.Current.Shutdown();
        }

        private void ContentPane_Closing(object sender, PaneClosingEventArgs e)
        {
            ContentControl documentToClose = sender as ContentControl;
            if (documentToClose != null)
            {
                MainViewModel data = this.DataContext as MainViewModel;
                e.Cancel = (!data.UserInterfaceLayoutProvider.Value.RemoveDocument(documentToClose.DataContext));
            }

            EventAggregator.Publish(new TabClosedMessage(documentToClose.Content));
        }

        #endregion Event Handlers
    }
}
