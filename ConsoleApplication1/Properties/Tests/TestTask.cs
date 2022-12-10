using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using NUnit.Framework;


namespace ConsoleApplication1.Properties.Tests
{
    public class TestTask
    {
        [Test]
        public void TestsJustProgram()
        {
            var cTrader =
                Application.Launch(
                    @"C:\Users\USER\Desktop\JustProgram\TestTask.Wpf.exe");

            var mainWindow = cTrader.GetMainWindow(new UIA3Automation());

            var cf = new ConditionFactory(new UIA3PropertyLibrary());

            mainWindow.FindFirstDescendant(cf.ByAutomationId("PART_EditableTextBox")).AsComboBox().Select(3);
            //mainWindow.FindFirstDescendant(cf.ByAutomationId("PART_EditableTextBox")).AsComboBox().Select("5000");
        }
        
    }
}