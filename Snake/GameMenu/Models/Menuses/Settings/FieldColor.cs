namespace GameMenu.Models.Menuses.Settings
{
    using GameMenu.Models.Menuses.Settings.Interfaces;
    using Interfaces;

    internal class FieldColor : Menu, ISettings
    {
        private const int Number = 2;
        private const string ColorSubfolder = "GameMenu.Models.Menuses.Settings.ColorSubFolder";

        public FieldColor(int row, int col)
            : base(Number, row, col)
        {
        }

        public override string GetName()
        {
            return "Field Color";
        }
        public override Type Execute()
        {
            InterfaceRepository<Type>.Push(typeof(IColor));
            return InterfaceRepository<Type>.Peek(); 
        }
    }
}
