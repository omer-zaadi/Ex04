namespace Ex04.Menus.Interfaces
{
    public  interface IMenuItem
    {
        string Title { get; }
        void Execute(); // פעולה שתבוצע כאשר בוחרים את הפריט
        bool HasSubItems { get; }
        List<IMenuItem> SubItems { get; }
    }
}