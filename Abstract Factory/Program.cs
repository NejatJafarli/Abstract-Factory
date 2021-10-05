using System;

namespace Abstract_Factory
{
    public class Program
    {
        interface IButton
        {
            void Paint();
        }
        interface ICheckBox
        {
            void Paint();
        }

        class WinBtn : IButton
        {
            public void Paint()
            {
                Console.WriteLine("Windows Button Painted");
            }
        }

        class WinCb : ICheckBox
        {
            public void Paint()
            {
                Console.WriteLine("Windows CheckBox Painted");
            }
        }

        class MacBtn : IButton
        {
            public void Paint()
            {
                Console.WriteLine("Mac Button Painted");
            }
        }
        class MacCb : ICheckBox
        {
            public void Paint()
            {
                Console.WriteLine("Mac CheckBox Painted");
            }
        }

        interface IGuiFactory
        {
            IButton CreateButton();
            ICheckBox CreateCheckBox();
        }

        class WinFactory : IGuiFactory
        {
            public IButton CreateButton() => new WinBtn();

            public ICheckBox CreateCheckBox() => new WinCb();
        }
        class MacFactory : IGuiFactory
        {
            public IButton CreateButton() => new MacBtn();

            public ICheckBox CreateCheckBox() => new MacCb();
        }

        class Application
        {
            private IGuiFactory _factory;
            private IButton _button;
            private ICheckBox _checkBox;
            public Application(IGuiFactory guiFactory)
            {
                _factory = guiFactory;
            }

            public void CreateUI()
            {
                _button = _factory.CreateButton();
                _checkBox = _factory.CreateCheckBox();
                Console.WriteLine("Controllers UI Created\n");
            }
            public void Paint()
            {
                _button.Paint();
                _checkBox.Paint();
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Application AppWin = new Application(new WinFactory());
            AppWin.CreateUI();
            AppWin.Paint();


            Application AppMac = new Application(new MacFactory());
            AppMac.CreateUI();
            AppMac.Paint();


        }
    }
}
