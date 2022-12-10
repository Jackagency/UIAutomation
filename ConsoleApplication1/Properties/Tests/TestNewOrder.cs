using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using NUnit.Framework;

namespace ConsoleApplication1.Properties.Tests
{
  
    public class TestNewOrder
    {
        [Test]
        public void TestsCtrader()
        {
            var cTrader =
                Application.Launch(
                    @"C:\Users\USER\AppData\Local\Spotware\cTrader\abb70432efbee65d18af69e79fe8efe1\cTrader.exe");
            

            var _mainWindow = cTrader.GetMainWindow(new UIA3Automation());

            var cf = new ConditionFactory(new UIA3PropertyLibrary());
            
            var tradeWatchPannel = WaitForElement(() => _mainWindow.FindFirstDescendant(cf.ByAutomationId("TradeWatchTabControl_AId")));

            var exampleButton = WaitForElement(() => tradeWatchPannel.FindFirstDescendant(cf.ByAutomationId("CreateNewMarketOrderButton_AId")));
            exampleButton.AsButton().Click();
            _mainWindow.FindFirstDescendant(cf.ByAutomationId("SpinnerContent_AId")).AsTextBox().Enter("1400");
            _mainWindow.FindFirstDescendant(cf.ByAutomationId("QuantityOrVolumeTextBox_AId")).AsTextBox().Enter("5");
            _mainWindow.FindFirstDescendant(cf.ByAutomationId("CheckBoxStopLoss_AId")).AsCheckBox().Click();
            _mainWindow.FindFirstDescendant(cf.ByAutomationId("CheckBoxTakeProfit_AId")).AsCheckBox().Click();
            _mainWindow.FindFirstDescendant(cf.ByName("Place Order")).AsButton().Click();

        }
        private T WaitForElement<T>(Func<T> getter)
        {
            var retry = Retry.WhileNull<T>(
                () => getter(),
                TimeSpan.FromMilliseconds(20000));

            if (!retry.Success)
            {
                Assert.Fail("Failed to get an element within a wait timeout");
            }

            return retry.Result;
        }
    }
}