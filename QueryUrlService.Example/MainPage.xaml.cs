using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QueryUrlService.Example.Resources;
using WhallaLabs.Services.QueryUrlService;

namespace QueryUrlService.Example
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Create object to convert
            var data = new FirstTestClass() { TestInt = 2, TestString = "test", IgnoredProperty = 1 };
            
            //Create query from object
            var query = QueryUrlBuilder.CreateQuery(data);

            //Add another parameter to query...
            query.AddParameter("added", true);

            //...and another one
            query.AddParameter("mode", "testMode");

            ResultTextBlock.Text = query.ToQueryString();
        }

       
    }
}